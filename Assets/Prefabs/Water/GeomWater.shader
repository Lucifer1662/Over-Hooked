Shader "Geometry/NewGeometryShader"
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
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma geometry geom
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
            };

            struct g2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float3 normal: TEXCOORD1;
                fixed4 diffuse : COLOR0;
            };

            #include "BCCNoise8.hlsl"
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

            v2g vert(appdata v)
            {
                v2g o;
                v.vertex.xyz += v.normal * noiseAt(v.vertex);
                o.vertex = v.vertex;
                o.uv = v.uv;

       
            
              

                return o;
            }

            [maxvertexcount(3)]
            void geom(triangle v2g IN[3], inout TriangleStream<g2f> triStream)
            {
                g2f o;
                float3 a = normalize(IN[1].vertex.xyz - IN[0].vertex.xyz);
                float3 b = normalize(IN[2].vertex.xyz - IN[0].vertex.xyz);


                float3 normal = cross(b,a);//getNormal((IN[0].vertex + IN[1].vertex + IN[2].vertex) / 3.0f);

                half3 worldNormal = UnityObjectToWorldNormal(-normal);
                half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
                float diffuse = nl * _LightColor0 * _DiffuseFactor;

                // the only difference from previous shader:
                // in addition to the diffuse lighting from the main light,
                // add illumination from ambient or light probes
                // ShadeSH9 function from UnityCG.cginc evaluates it,
                // using world space normal
                /*o.diff.rgb += ShadeSH9(half4(worldNormal, 1));*/


                for (int i = 0; i < 3; i++)
                {
                    
                    o.vertex = UnityObjectToClipPos(IN[i].vertex);
                    
                    UNITY_TRANSFER_FOG(o,o.vertex);
                    o.uv = TRANSFORM_TEX(IN[i].uv, _MainTex);
                    o.normal = normal;
                    o.diffuse = diffuse;
                    triStream.Append(o);
                }



                triStream.RestartStrip();
            }

            fixed4 frag(g2f i) : SV_Target
            {
                float depth = 1-tex2D(_MainTex, i.uv).r;

                
                // sample the texture
                fixed4 col = lerp(_Colour,_DarkColour, depth) * saturate(_Ambient + i.diffuse);
                col.a = lerp(_Colour, _DarkColour, depth).a;
                
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
        ENDCG
    }
   
    }
    FallBack "Custom/Water"
}