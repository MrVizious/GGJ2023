Shader "Custom/Sepia" {
    Properties {
      _MainTex ("Base (RGB)", 2D) = "white" {}
    }
    SubShader {
      Tags { "RenderType"="Opaque" }
      LOD 200
         
      CGPROGRAM
        #pragma surface surf Lambert finalcolor:Sepia
 
            sampler2D _MainTex;
 
        struct Input {
        float2 uv_MainTex;
        };
 
            void surf (Input IN, inout SurfaceOutput o) {
        half4 c = tex2D (_MainTex, IN.uv_MainTex);
        o.Albedo = c.rgb;
        o.Alpha = c.a;
        }
         
        void Sepia (Input IN, SurfaceOutput o, inout fixed4 color) {
          
            fixed3 sepia;
            sepia.r = dot(color.rgb, half3(0.393, 0.769, 0.189));
            sepia.g = dot(color.rgb, half3(0.349, 0.686, 0.168));   
            sepia.b = dot(color.rgb, half3(0.272, 0.534, 0.131));
          
            color.rgb = sepia;
        }
         
    ENDCG
    } 
    FallBack "Diffuse"
}