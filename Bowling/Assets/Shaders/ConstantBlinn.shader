Shader "Custom/ConstantBlinn"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_SpecColor("Specular Material Color", Color) = (1,1,1,1)
		_Shininess("Shininess", Float) = 10
	}
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma geometry geom
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform float4 _Color;
			uniform float4 _SpecColor;
			uniform float _Shininess;

			uniform float4 _LightColor0;

			struct appdata
			{
				float4 pos : POSITION;
				float3 norm : NORMAL;
			};

			struct v2g
			{
				float4 pos : SV_POSITION;
				float3 norm : TEXCOORD0;
			};

			struct g2f {
				float4 pos : SV_POSITION;
				fixed4 col : COLOR0;
			};

			v2g vert(appdata v)
			{
				v2g o;
				o.pos = v.pos;
				o.norm = v.norm;
				return o;
			}

			[maxvertexcount(3)]
			void geom(triangle v2g i[3], inout TriangleStream<g2f> triStream)
			{
				float4x4 modelMatrix = unity_ObjectToWorld;
				float3x3 modelMatrixInverse = unity_WorldToObject;
				float3 viewDirection = normalize(_WorldSpaceCameraPos- mul(modelMatrix, i[0].pos).xyz);
				float3 normalDirection = normalize(mul(i[0].pos, modelMatrixInverse));
				float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);

				//ambientLighting
				float3 ambientLighting = unity_AmbientSky.rgb * _Color.rgb;

				//diffuseReflection
				float3 diffuseReflection = _LightColor0.rgb * _Color.rgb * (max(0.0, dot(lightDirection, normalDirection)));

				//specular
				float3 h = normalize(lightDirection + viewDirection);
				float3 nh = max(0.0, dot(normalDirection, h));

				float3 specularReflection = _LightColor0.rgb * _SpecColor.rgb * pow(nh, _Shininess);

				fixed4 col = float4(ambientLighting + diffuseReflection + specularReflection, 1.0);

				g2f o;
				o.pos = UnityObjectToClipPos(i[0].pos);
				o.col = col;
				triStream.Append(o);

				o.pos = UnityObjectToClipPos(i[1].pos);
				o.col = col;
				triStream.Append(o);

				o.pos = UnityObjectToClipPos(i[2].pos);
				o.col = col;
				triStream.Append(o);
			}

			fixed4 frag(g2f v) : SV_Target
			{
				return v.col;
			}
		ENDCG
		}
	}
}
