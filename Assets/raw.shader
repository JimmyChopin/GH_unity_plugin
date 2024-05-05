Shader "rawShader"
{
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 color : COLOR0;
            };

            StructuredBuffer<float2> verticeBuff;
            uniform float _NumInstances;

            v2f vert(uint vertexID: SV_VertexID, uint instanceID : SV_InstanceID)
            {
                v2f o;
                float2 pos = verticeBuff[vertexID];
                o.pos = mul(UNITY_MATRIX_VP, float4(pos,0.0f,1.0f));
                o.color = float4(1.0f, 0.0f, 0.0f, 1.0f);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                return i.color;
            }
            ENDCG
        }
    }
}