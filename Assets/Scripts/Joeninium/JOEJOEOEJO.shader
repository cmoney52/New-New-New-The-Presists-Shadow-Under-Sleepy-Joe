Shader "Unlit/JOEJOEOEJO"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _AuraColor ("Aura Color", Color) = (0,1,0,1)
        _EdgeStrength ("Edge Strength", Range(0,1)) = 0.7
        _NoiseStrength ("Noise Strength", Range(0,1)) = 0.2
        _Speed ("Fluctuation Speed", Range(0,5)) = 1.5
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Overlay" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _AuraColor;
            float _EdgeStrength;
            float _NoiseStrength;
            float _Speed;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float rand(float2 co)
            {
                return frac(sin(dot(co.xy, float2(12.9898,78.233))) * 43758.5453);
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv * 2 - 1; // -1 to 1 space
                float dist = length(uv);
                // INVERTED: aura strongest at edge, fades toward center
                float edge = smoothstep(_EdgeStrength, 1.0, dist);

                // Fluctuating noise for the aura edge
                float t = _Time.y * _Speed;
                float noise = sin(uv.x * 10.0 + t) * sin(uv.y * 10.0 + t) * 0.5 + 0.5;
                noise += rand(uv * 100.0 + t) * 0.3;
                noise *= _NoiseStrength;

                edge *= (1.0 + noise);

                float alpha = edge * _AuraColor.a;
                return float4(_AuraColor.rgb, alpha);
            }
            ENDCG
        }
    }
}