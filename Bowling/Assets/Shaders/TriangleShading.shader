Shader "Custom/TrianglePhong"
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

		float3 viewDirection1 = normalize(_WorldSpaceCameraPos - mul(modelMatrix, i[0].norm).xyz);
		float3 normalDirection1 = normalize(mul(i[0].pos, modelMatrixInverse));

		float3 viewDirection2 = normalize(_WorldSpaceCameraPos - mul(modelMatrix, i[1].norm).xyz);
		float3 normalDirection2 = normalize(mul(i[1].pos, modelMatrixInverse));

		float3 viewDirection3 = normalize(_WorldSpaceCameraPos - mul(modelMatrix, i[2].norm).xyz);
		float3 normalDirection3 = normalize(mul(i[2].pos, modelMatrixInverse));

		float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);

		//ambientLighting
		float3 ambientLighting = unity_AmbientSky.rgb * _Color.rgb;

		//diffuseReflection
		float3 diffuseReflection1 = _LightColor0.rgb * _Color.rgb * (max(0.0, dot(lightDirection, normalDirection1)));
		float3 diffuseReflection2 = _LightColor0.rgb * _Color.rgb * (max(0.0, dot(lightDirection, normalDirection2)));
		float3 diffuseReflection3 = _LightColor0.rgb * _Color.rgb * (max(0.0, dot(lightDirection, normalDirection3)));

		float3 diffuseReflection = lerp(lerp(diffuseReflection1 ,diffuseReflection2, 1.0),  diffuseReflection3, 1.0);

		//specular
		float3 r1 = reflect(-lightDirection, normalDirection1);
		float3 rv1 = max(0.0, dot(r1, viewDirection1));
		float3 specularReflection1 = _LightColor0.rgb * _SpecColor.rgb * pow(rv1, _Shininess);

		float3 r2 = reflect(-lightDirection, normalDirection2);
		float3 rv2 = max(0.0, dot(r2, viewDirection2));
		float3 specularReflection2 = _LightColor0.rgb * _SpecColor.rgb * pow(rv2, _Shininess);

		float3 r3 = reflect(-lightDirection, normalDirection3);
		float3 rv3 = max(0.0, dot(r3, viewDirection3));
		float3 specularReflection3 = _LightColor0.rgb * _SpecColor.rgb * pow(rv3, _Shininess);

		float3 specularReflection = lerp(lerp(specularReflection1 , specularReflection2, 1.0), specularReflection3, 1.0);

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
