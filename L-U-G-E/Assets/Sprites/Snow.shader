Shader "Custom/Snow" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_SSColor ("SS Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 300

CGPROGRAM
#pragma surface surf Lambert finalcolor:mycolor

sampler2D _MainTex;
sampler2D _BumpMap;
fixed4 _Color;
fixed4 _SSColor;

struct Input {
	float2 uv_MainTex;
	float2 uv_BumpMap;
};

void mycolor (Input IN, SurfaceOutput o, inout fixed4 color){
          color += _SSColor;
}

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	o.Albedo = c.rgb;
	o.Alpha = c.a;
	o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
}
ENDCG  
}

FallBack "Legacy Shaders/Diffuse"
}
