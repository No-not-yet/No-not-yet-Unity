Shader "Custom/CellShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Ramp ("Ramp (RGB)", 2D) = "ramp" {}
		_NormalMap("Normal Map", 2D) = "bump" {}

		//_Glossiness ("Smoothness", Range(0,1)) = 0.5
		//_Metallic ("Metallic", Range(0,1)) = 0.0
 	}
	SubShader {
		Tags { "RenderType"="Opaque"}
		LOD 200
		
		CGPROGRAM
		//fyllfoward shadows: instrucciones al shader para que haya constraste en el material 
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Ramp


		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		//half _Glossiness;
		//half _Metallic;
		sampler2D _MainTex;
		fixed4 _Color;
		sampler2D _Ramp;
		sampler2D _NormalMap;

		half4 LightingRamp (SurfaceOutput s, half3 lightDir, half atten) {
			half NdotL = dot (s.Normal, lightDir);
			half diff = NdotL * .5 + .5;
			half3 ramp = tex2D (_Ramp, float2 (diff,diff)).rgb;
			half4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * ramp * atten;
			c.a = s.Alpha;
			return c;
		}

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * _Color;
			o.Normal = UnpackNormal(tex2D(_NormalMap,IN.uv_MainTex));
			// Metallic and smoothness come from slider variables
			//o.Metallic = _Metallic;
			//o.Smoothness = _Glossiness;
			//o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
