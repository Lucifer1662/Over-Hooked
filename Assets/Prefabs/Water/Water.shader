Shader "Custom/Water"
{
	Properties
	{

		_Colour("Light Color", Color) = (1,1,1,1)
		_DarkColour("Dark Color", Color) = (1,1,1,1)
		_MainTex("Texture", 2D) = "white" {}
		_Ambient("Ambient", Range(0,1)) = 0.5
		_NoiseIntensity("Noise Intensity", Range(0,100)) = 1
		_NoiseDisplacementScale("Noise Displacement Scale", Range(0,100)) = 1
		_NoiseDisplacementSpeed("_Noise Displacement Direction", Vector) = (0.1,1,-0.1)
		_DiffuseFactor("Diffuse Factor", Range(0,1)) = 0.9
	}
		SubShader
		{
			Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
			LOD 200


			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf Standard fullforwardshadows vertex:vert alpha   
			 
			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0

					#include "BCCNoise8.hlsl"
		

			struct Input
			{
				float4 vertex : SV_POSITION;
				float2 uv_MainTex;
			};

			sampler2D _MainTex;
			float4 _Colour;
			float4 _DarkColour;
			float4 _MainTex_ST;
			float _NoiseIntensity;
			float3 _NoiseDisplacementSpeed;
			float _NoiseDisplacementScale;
			float _DiffuseFactor;
			float _Ambient;

			float noiseAt(float3 pos) {
				//float height = sin(_Time.y + pos.x * _WaveDirection.x / _WaveFrequency + pos.z * _WaveDirection.z / _WaveFrequency);// +v.vertex.z / _WaveFrequency);

				return ((Bcc8NoiseClassic((pos + (float3(_NoiseDisplacementSpeed.x, _NoiseDisplacementSpeed.y, _NoiseDisplacementSpeed.z) * _Time.y)) / _NoiseDisplacementScale) + 1.0f) / 2.0f) * _NoiseIntensity;
			}

			float3 getNormal(float3 pos) {
				float dx = 0.01f;
				float dz = 0.01f;
				float dydx = (noiseAt(pos + float3(dx, 0, 0)) - noiseAt(pos - float3(dx, 0, 0))) / 2;
				float dydz = (noiseAt(pos + float3(0, 0, dz)) - noiseAt(pos - float3(0, 0, dz))) / 2;
				float3 v1 = normalize(float3(dx, dydx, 0));
				float3 v2 = normalize(float3(0, dydz, dz));
				float3 n = cross(v1, v2);
				n = normalize(n);
				return n;
			}


			void vert(inout appdata_full v) {
				v.vertex.y += noiseAt(v.vertex);
				
				v.normal = -getNormal(v.vertex);
			}

			

			
		

			// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
			// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
			// #pragma instancing_options assumeuniformscaling
			UNITY_INSTANCING_BUFFER_START(Props)
				// put more per-instance properties here
			UNITY_INSTANCING_BUFFER_END(Props)

			void surf(Input IN, inout SurfaceOutputStandard o)
			{

				float depth = 1 - tex2D(_MainTex, i.uv).r;


				// sample the texture
				fixed4 col = lerp(_Colour, _DarkColour, depth);
				col.a = lerp(_Colour, _DarkColour, depth).a;

				// Albedo comes from a texture tinted by color
				fixed4 c = col;
				o.Albedo = c.rgb;
				


				// Metallic and smoothness come from slider variables
				o.Metallic = 0;
				o.Smoothness = 0;
				o.Alpha = c.a;
			}
			ENDCG
		}
			FallBack "Diffuse"
}
