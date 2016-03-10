Shader "Gravitation Lensing Shader" {
Properties {
    _MainTex ("Base (RGB)", 2D) = "white" {}
}

SubShader {
    Pass {
        ZTest Always Cull Off ZWrite Off
        Fog { Mode off }
                
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #pragma fragmentoption ARB_precision_hint_fastest 
        #include "UnityCG.cginc"

        uniform sampler2D _MainTex;
        uniform float _Rad;
        uniform float _Ratio;
		uniform int _BHCount;

		uniform float2 _Positions[10];

        struct v2f {
            float4 pos : POSITION;
            float2 uv : TEXCOORD0;
        };

        v2f vert( appdata_img v )
        {
            v2f o;
            o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
            o.uv = v.texcoord;
            return o;
        }
        
        float4 frag (v2f i) : COLOR
        {
			if(_BHCount>0)
			{

				float2 ratio = {_Ratio,1}; // determines the aspect ratio
				float2 offSetSum;
				for(int f1=0; f1<_BHCount; f1++)
				{
					float2 offset = i.uv - _Positions[f1]; // We shift our pixel to the desired position
					float rad = length(offset / ratio); // the distance from the conventional "center" of the screen.

					float tempDist = abs(distance(i.uv, _Positions[f1]));
					float deformation = 1/pow(rad*pow(tempDist,0.5),2)*_Rad*2;
					offset =offset*(1-deformation);
					offset += _Positions[f1];

					if(f1==0)
						offSetSum = offset;
					else
						offSetSum += offset;

				}
				offSetSum /= _BHCount;
				half4 res = tex2D(_MainTex, offSetSum);
				return res;
			}
			else
			{
				half4 res = tex2D(_MainTex, i.uv);
				return res;
			}
        }
        ENDCG
    }
}

Fallback off

}