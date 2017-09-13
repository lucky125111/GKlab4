// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/ConstantPhong"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_SpecColor("Specular Material Color", Color) = (1,1,1,1)
		_Shininess("Shininess", Float) = 10
	}
		SubShader
	{
		Tags{ "RenderType" = "Opaque" "LightMode" = "ForwardBase" }
		LOD 100

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
		fixed4 diffColor : COLOR0;
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
		float3 viewDirection = normalize(_WorldSpaceCameraPos
			- mul(unity_ObjectToWorld, i[0].norm).xyz);
		//trzeba przyjac dowolny 
		float3 normalDirection = normalize(
			mul(i[0].pos, modelMatrixInverse));		
		float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);

		//ambient
		float3 ambientLighting =
			unity_AmbientSky.rgb * _Color.rgb;

		//diffuse 
		float3 diffuseReflection = _LightColor0.rgb * _Color.rgb
			* max(0.0, dot(normalDirection, lightDirection));

		//specular
		//tutaj if (dot(normalDirection, lightDirection) < 0.0)  to 0 poprawic
		float3 halfVector = normalize(_WorldSpaceLightPos0.xyz + _WorldSpaceCameraPos
			- mul(unity_ObjectToWorld, i[0].pos).xyz);

		//float3 tmp = dot(normalDirection, halfVector);
		float3 tmp = dot(normalDirection, halfVector);

		// z wykladu v * r czyli v - unit vecgtor w strone ogladacza, r - z punktu po
		float3 specularReflection;
		if (dot(normalDirection, lightDirection) < 0.0)
		{
			specularReflection = float3(0.0, 0.0, 0.0);
		}
		else {
			specularReflection = _LightColor0.rgb * _SpecColor.rgb * pow(max(0.0, tmp), _Shininess);
		}

		fixed4 diff = float4(ambientLighting + diffuseReflection + specularReflection, 1.0);

		g2f o;
		o.pos = UnityObjectToClipPos(i[0].pos);
		o.diffColor = diff;
		triStream.Append(o);

		o.pos = UnityObjectToClipPos(i[1].pos);
		o.diffColor = diff;
		triStream.Append(o);

		o.pos = UnityObjectToClipPos(i[2].pos);
		o.diffColor = diff;
		triStream.Append(o);
	}

	fixed4 frag(g2f i) : SV_Target
	{
		fixed4 mainColor = i.diffColor;
		return mainColor;
	}
		ENDCG
	}
	}
}
