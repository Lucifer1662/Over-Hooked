Shader "Custom/Water1Shader"
{
	Properties
	{
		_Colour("Light Color", Color) = (1,1,1,1)
		_DarkColour("Dark Color", Color) = (1,1,1,1)
		_MainTex("Texture", 2D) = "white" {}
		_DisplacementTex("Displacement Texture", 2D) = "white" {}
		_Ambient("Ambient", Range(0,1)) = 0.5
		_NoiseIntensity("Noise Intensity", Range(0,100)) = 1
		_NoiseDisplacementScale("Noise Displacement Scale", Range(0,100)) = 1
		_NoiseDisplacementSpeed("_Noise Displacement Direction", Vector) = (0.1,1,-0.1)
		_DiffuseFactor("Diffuse Factor", Range(0,1)) = 0.9
		_FoamScale("Foam Scale", Range(0.0001, 10)) = 0.3


	}
		SubShader
		{
			Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				// make fog work
				#pragma multi_compile_fog

				#include "UnityCG.cginc"
				#include "UnityLightingCommon.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
					float3 normal: NORMAL;
				};

				struct v2g
				{
					float4 vertex : SV_POSITION;
					float2 uv : TEXCOORD0;
					float3 vertexWoldPosition :TEXCOORD1;

					UNITY_FOG_COORDS(2)
				};

				#include "BCCNoise8.hlsl"
				sampler2D _MainTex;
				sampler2D _DisplacementTex;
				float4 _Colour;
				float4 _DarkColour;
				float4 _MainTex_ST;
				float _NoiseIntensity;
				float3 _NoiseDisplacementSpeed;
				float _NoiseDisplacementScale;
				float _DiffuseFactor;
				float _Ambient;
				float _FoamScale;

				float noiseAt(float3 pos) {
					return tex2D(_DisplacementTex, pos.xz / 100).r;
					//return ((Bcc8NoiseClassic((pos + (float3(_NoiseDisplacementSpeed.x, _NoiseDisplacementSpeed.y, _NoiseDisplacementSpeed.z) * _Time.y)) / _NoiseDisplacementScale) + 1.0f) / 2.0f) * _NoiseIntensity;
				}

				float noiseAtVert(float3 pos) {
					return ((Bcc8NoiseClassic((pos + (float3(_NoiseDisplacementSpeed.x, _NoiseDisplacementSpeed.y, _NoiseDisplacementSpeed.z) * _Time.y)) / _NoiseDisplacementScale) + 1.0f) / 2.0f) * _NoiseIntensity;
				}


				v2g vert(appdata v)
				{
					v2g o;
					v.vertex.xyz += v.normal *noiseAtVert(v.vertex);
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					o.vertexWoldPosition = v.vertex;
					return o;
				}

				float3 getNormal(float3 pos) {
					float dx = 0.1f;
					float3 noise = noiseAt(pos);
					float3 v1 = normalize(float3(dx, noise.x, 0));
					float3 v2 = normalize(float3(0, noise.z, dx));
					float3 n = cross(v1, v2);
					n = normalize(n);
					return n;
				}



				fixed4 frag(v2g i) : SV_Target
				{

				float depth = 1 - tex2D(_MainTex, i.uv).r;


				float3 normal = getNormal(i.vertexWoldPosition);
				/*
				half3 worldNormal = UnityObjectToWorldNormal(-normal);
				half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));*/
				float diffuse = normal.x;// nl* _LightColor0* _DiffuseFactor;

				// sample the texture
				fixed4 col = lerp(_Colour,_DarkColour, depth) * saturate(_Ambient + diffuse);
				col.a = lerp(_Colour, _DarkColour, depth).a;

				//float r = ((Bcc8NoiseClassic(float3(i.vertexWoldPosition.x, _Time.y * 0.03f + i.vertexWoldPosition.y, i.vertexWoldPosition.z) / _FoamScale) + 1.0f) / 2.0f);
				float r = tex2D(_DisplacementTex, float2(i.vertexWoldPosition.x, i.vertexWoldPosition.z) / _FoamScale).r; 

				float d1 = saturate(1 - abs((min(1 - depth, 1.0f)) * 2 - 1));
				float d = min(1 - depth + i.vertexWoldPosition.y / 5, 1);
				//d = d * r;
				float foam = r;
				// d = (r > 0.6f && r<0.7f) * d;
				float offset = 0.05;
				float start = 0.0;
				float maxFinish = 1.5;
				float negOffset = 0.2;
				float t = fmod(_Time.y/20, negOffset);
				
				float f = 0;
				float g = 0;
				while(g < 1){
					if (d > fmod(start + t + g, maxFinish)  && d < fmod(start + offset + t + g, maxFinish)) {
						f = foam;
					}
					g += negOffset;
				}
				f *= saturate(pow(d1, 13));
				 //if (d < start || d > finish) {
					// /*d = 0;*/
					// foam = 0;
				 //}
				 /*d = saturate(d);*/


				 /*float foam = saturate(pow(d, 13)) / 3.0f;*/
				/*float foam = ((tex2D(_DisplacementTex, float2(i.vertexWoldPosition.x, i.vertexWoldPosition.z) / _FoamScale) + 1.0f) / 2.0f).r;*/

				 col = lerp(col, float4(1, 1, 1, 1), f);


				 return col;
			 }
		 ENDCG
	 }

		}
			FallBack "Custom/Water"
}