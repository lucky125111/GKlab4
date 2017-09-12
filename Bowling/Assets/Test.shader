Shader "blabla/Test"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_lightPos ("opis", Vector) = (0,0,0,0)
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" }
		LOD 100

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

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

			sampler2D _MainTex;
			uniform float4 _lightPos;	//
			float4 _MainTex_ST;
			//geo
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				/*if (o.uv.x > 0.2 && o.uv.x < 0.4)
					o.uv.x = 0;*/
				return o;
			}
			//kolor
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				if (col.x + col.y + col.z < 2)
					col = float4(0,0,0,0);
				return col;
			}
			ENDCG
		}
	}
}
