Shader "Unlit/iso"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"



            struct vData{
                float2 vertex;
                float2 uv ;
            }

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };



            float cellSize;

            v2f vert (vData v)
            {
                v2f o;
                float3x3 isoMat = float3x3(
                    1,          -1,         0,
                    -0.5,       -0.5,       0,
                    0,          0 ,         1
                );
                float3x3 scaleMat = float3x3(
                    cellSize/2,     0,              0,
                    0,              cellSize/2,     0,
                    0,              0,              1,
                );
                float3 offset = float3(-cellSize/2.0,cellSize/2.0,0.0);

                float3 pos =  mul(mul(scaleMat,isoMat),v.vertex) + float3(cellSize*v.uv.x , -cellSize*v.uv.y, 0) + offset;

                o.vertex = UnityObjectToClipPos(float4(pos,1.0));
                o.uv = v.uv;
                return o;
            }


            sampler2D _MainTex;
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
