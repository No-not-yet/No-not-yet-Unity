// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Week11/CelShadingWithRamp"
{
	Properties
	{		
		_LineColor("Line Color", Color) = (0,0,0,0)
		_Extrusion("Line width", Range(0.0, 0.01)) = 0.005
		_MainTex("Albedo", 2D) = "white" {}
		_RampTex("Ramp", 2D) = "white" {}
		//_NormalMap("NormalMap", 2D) = "bump" {}
	}

	SubShader
	{	
		// Extrud & invert mesh
		Pass
		{
			Cull Front
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			float4 _LineColor; 
			float _Extrusion;

			
			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};
			
			struct v2f
			{				
				float4 vertex : SV_POSITION;
			};
			
			v2f vert (appdata v)
			{
				v2f o;

				v.vertex.xyz += v.normal * _Extrusion;
				o.vertex = UnityObjectToClipPos(v.vertex);
				
				return o;
			}
			
			float4 frag (v2f i) : COLOR
			{

				return _LineColor;
			}
			
			ENDCG
		}
		
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			sampler2D _MainTex;
			sampler2D _RampTex;
			//sampler2D _NormalMap;
			
			float4 WorldSpaceLight;
			float4 LightColor;

			struct appdata
			{
				float4 vertex : POSITION;			
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;  // in object space
			};

			struct v2f
			{				
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 worldSpaceNormal: TEXCOORD1;
				float3 worldSpaceVertex: TEXCOORD2;
			};
			
			v2f vert (appdata v)
			{
				v2f o;

				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv; 
				
				o.worldSpaceNormal = normalize(mul(unity_ObjectToWorld, float4(v.normal, 0.0)).xyz);
				o.worldSpaceVertex = mul(unity_ObjectToWorld, v.vertex).xyz;
				
				return o;
			}
			
			float4 frag (v2f i) : COLOR
			{
				float NdotL = 0.0;
				i.worldSpaceNormal = normalize(i.worldSpaceNormal);
				
				// Directional
				if (WorldSpaceLight.w == 0.0)
				{
					float3 L = -WorldSpaceLight.xyz;	
					NdotL = saturate(dot(i.worldSpaceNormal,L));
				}
				else //if (WorldSpaceLight.w == 1.0)  // point light
				{									
					float3 L = normalize(WorldSpaceLight.xyz - i.worldSpaceVertex);
					NdotL = saturate(dot(i.worldSpaceNormal,L));
				}
				//float3 normal = UnpackNormal(tex2D(_NormalMap,i.uv));
				float4 finalTexelColor = tex2D(_MainTex, i.uv);
				float4 finalColor =  finalTexelColor * LightColor * tex2D(_RampTex, float2((NdotL * 0.5 + 0.5), 0.0));
				return finalColor;
			}

			ENDCG
		}
	}
}
