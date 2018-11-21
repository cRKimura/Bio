Shader "BitshiftProductions/Fast-UI-Jiggle"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)
	}

		SubShader
	{
		Tags
	{
		"Queue" = "Transparent"
		"IgnoreProjector" = "True"
		"RenderType" = "Transparent"
		"PreviewType" = "Plane"
		"CanUseSpriteAtlas" = "True"
	}

		Cull Off
		Lighting Off
		ZWrite Off
		ZTest[unity_GUIZTestMode]
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"
#include "UnityUI.cginc"

		struct appdata_t
	{
		float4 vertex   : POSITION;
		float4 color    : COLOR;
		float2 texcoord : TEXCOORD0;
	};

	struct v2f
	{
		float4 vertex   : SV_POSITION;
		fixed4 color : COLOR;
		half2 texcoord  : TEXCOORD0;
		float4 worldPosition : TEXCOORDO1;
	};

	fixed4 _Color;
	fixed4 _TextureSampleAdd;

#define PI 3.14159
#define TWO_PI 6.28318
	v2f vert(appdata_t IN)
	{
		v2f OUT;
		OUT.worldPosition = IN.vertex;
		OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);
		OUT.texcoord = IN.texcoord;

		OUT.color = _Color;
		return OUT;
	}

	sampler2D _MainTex;
	fixed4 frag(v2f IN) : SV_Target
	{
		float2 st = 0.5 - IN.texcoord;
		float a = atan2(st.y, st.x);
		float d = min(abs(cos(a * 2.5 + _Time.w*2)) + 0.4,
			abs(sin(a * 2.5 + _Time.w * -2)) + 0.7) * 0.32;
		return fixed4(d,d,d,1) * _Color;
	}
		ENDCG
	}
	}
}