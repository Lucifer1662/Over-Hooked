// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/WiggleVertColour"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_WiggleDirection("Wiggel Direction", Vector) = (0,0,1)
		_WiggleSpeed("Wiggle Speed", Range(0,10)) = 0.1
		_WiggleFrequency("Wiggle Frequency", Range(0.00000000001, 5)) = 1
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert 

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0



		struct Input
			{
				float4 vertex : SV_POSITION;
				float2 uv_MainTex;
			};

		fixed4 _Color;
		float3 _WiggleDirection;
		float _WiggleSpeed;
		float _WiggleFrequency;


		void vert(inout appdata_full v) {
			//v.vertex.xyz += _WiggleDirection * sin(_Time.y + v.vertex.x + +v.vertex.y + +v.vertex.z) * 10;
			/*v.vertex.z += _WiggleDirection.z * sin(_Time.y + v.vertex.z/ _WiggleFrequency) * _WiggleSpeed;
			v.vertex.y += _WiggleDirection.y * sin(_Time.y + v.vertex.y/ _WiggleFrequency) * _WiggleSpeed;*/
			
			v.vertex.x += sin( _Time.y +  v.vertex.y / _WiggleFrequency) * _WiggleSpeed;// *abs(v.vertex.x);
			//v.vertex.y += _WiggleDirection.x * sin(_Time.y + v.vertex.x / _WiggleFrequency) * _WiggleSpeed;// *abs(v.vertex.y);
			//v.vertex.z += _WiggleDirection.x * sin(_Time.y + v.vertex.z / _WiggleFrequency) * _WiggleSpeed * abs(v.vertex.z);

	
			 //sin(_Time.y + v.vertex.z) * 10;
		}



		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			// Albedo comes from a texture tinted by color
			fixed4 c = _Color;
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
