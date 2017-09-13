// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/PhongBlinn"
{
	Properties
	{
		_Color("Diffuse Material Color", Color) = (1,1,1,1)
		_SpecColor("Specular Material Color", Color) = (1,1,1,1)
		_Shininess("Shininess", Float) = 10
	}
		SubShader
	{
		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"


	uniform float4 _Color;
	uniform float4 _SpecColor;
	uniform float _Shininess;

	uniform float4 _LightColor0;

	struct vertexInput {
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};
	struct vertexOutput {
		float4 pos : SV_POSITION;
		float4 col : COLOR;
	};

	vertexOutput vert(vertexInput input)
	{
		vertexOutput output;

		float4x4 modelMatrix = unity_ObjectToWorld;
		float3x3 modelMatrixInverse = unity_WorldToObject;
		float3 normalDirection = normalize(
			mul(input.normal, modelMatrixInverse));
		float3 viewDirection = normalize(_WorldSpaceCameraPos
			- mul(unity_ObjectToWorld, input.vertex).xyz);
		float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);

		float3 ambientLighting =
			unity_AmbientSky.rgb * _Color.rgb;

		//Idiffuse = Kd * Ilight * cos ^ shine  (color to diffusife material)
		float3 diffuseReflection = _LightColor0.rgb * _Color.rgb
			* max(0.0, dot(normalDirection, lightDirection));

		//Ispecular = Ks * Ilight * cos()	(spec color)
		//vector r (z wykladu mirror reflectance direction)
		float3 halfVector = normalize(_WorldSpaceLightPos0.xyz + _WorldSpaceCameraPos
			- mul(unity_ObjectToWorld, input.vertex).xyz);

		//float3 tmp = dot(normalDirection, halfVector);
		float3 tmp = dot(normalDirection, halfVector);

		// z wykladu v * r czyli v - unit vecgtor w strone ogladacza, r - z punktu po

		float3 specularReflection = _LightColor0.rgb * _SpecColor.rgb * pow(max(0.0, tmp), _Shininess);

		output.col = float4(ambientLighting + diffuseReflection
			+ specularReflection, 1.0);


		output.pos = UnityObjectToClipPos(input.vertex);


		return output;
	}

	float4 frag(vertexOutput input) : COLOR
	{
		return input.col;
	}
		ENDCG
	}
	}
}
