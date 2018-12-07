// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32582,y:32576,varname:node_4795,prsc:2|emission-2590-OUT,alpha-2720-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:30722,y:32846,ptovrint:False,ptlb:Main_Texture,ptin:_Main_Texture,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4761-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:30740,y:32646,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_If,id:4970,x:31599,y:33010,varname:node_4970,prsc:2|A-6074-R,B-2053-A,GT-2637-OUT,EQ-1120-OUT,LT-1120-OUT;n:type:ShaderForge.SFN_TexCoord,id:9678,x:29919,y:32851,varname:node_9678,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:4728,x:30144,y:32851,varname:node_4728,prsc:2|A-9678-UVOUT,B-7556-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7556,x:29932,y:33112,ptovrint:False,ptlb:PixelSize,ptin:_PixelSize,varname:node_7556,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:65;n:type:ShaderForge.SFN_Floor,id:1963,x:30313,y:32846,varname:node_1963,prsc:2|IN-4728-OUT;n:type:ShaderForge.SFN_Divide,id:4761,x:30523,y:32846,varname:node_4761,prsc:2|A-1963-OUT,B-7556-OUT;n:type:ShaderForge.SFN_Vector1,id:1120,x:31396,y:33117,varname:node_1120,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:2637,x:31396,y:33044,varname:node_2637,prsc:2,v1:0;n:type:ShaderForge.SFN_Subtract,id:2689,x:31368,y:32799,varname:node_2689,prsc:2|A-6074-R,B-2475-OUT;n:type:ShaderForge.SFN_Vector1,id:2475,x:31191,y:32845,varname:node_2475,prsc:2,v1:0.03;n:type:ShaderForge.SFN_Ceil,id:8403,x:31552,y:32799,varname:node_8403,prsc:2|IN-2689-OUT;n:type:ShaderForge.SFN_Subtract,id:9769,x:31826,y:32871,varname:node_9769,prsc:2|A-8403-OUT,B-4970-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:2720,x:32200,y:32886,varname:node_2720,prsc:2,min:0,max:1|IN-9769-OUT;n:type:ShaderForge.SFN_Tex2d,id:3869,x:30740,y:32393,ptovrint:False,ptlb:NormalMap,ptin:_NormalMap,varname:_Main_Texture_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4e4e7a9d4caba1546a8222b8100665f6,ntxv:3,isnm:True|UVIN-4761-OUT;n:type:ShaderForge.SFN_Transform,id:7755,x:31023,y:32236,varname:node_7755,prsc:2,tffrom:0,tfto:3|IN-3869-RGB;n:type:ShaderForge.SFN_Cubemap,id:2802,x:31355,y:32364,ptovrint:False,ptlb:CubeMap,ptin:_CubeMap,varname:node_2802,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,cube:1b3ac9892b764054ab7b1631c4914ffc,pvfc:0|DIR-7755-XYZ;n:type:ShaderForge.SFN_Multiply,id:1849,x:31546,y:32506,varname:node_1849,prsc:2|A-2802-RGB,B-7542-RGB;n:type:ShaderForge.SFN_Color,id:7542,x:31096,y:32536,ptovrint:False,ptlb:Highlights,ptin:_Highlights,varname:node_7542,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:2590,x:31779,y:32581,varname:node_2590,prsc:2|A-1849-OUT,B-2053-RGB;proporder:6074-7556-3869-2802-7542;pass:END;sub:END;*/

Shader "Shader Forge/BloodDisolve" {
    Properties {
        _Main_Texture ("Main_Texture", 2D) = "white" {}
        _PixelSize ("PixelSize", Float ) = 65
        _NormalMap ("NormalMap", 2D) = "bump" {}
        _CubeMap ("CubeMap", Cube) = "_Skybox" {}
        _Highlights ("Highlights", Color) = (0.5,0.5,0.5,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Main_Texture; uniform float4 _Main_Texture_ST;
            uniform float _PixelSize;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform samplerCUBE _CubeMap;
            uniform float4 _Highlights;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float2 node_4761 = (floor((i.uv0*_PixelSize))/_PixelSize);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_4761, _NormalMap)));
                float3 emissive = ((texCUBE(_CubeMap,mul( UNITY_MATRIX_V, float4(_NormalMap_var.rgb,0) ).xyz.rgb).rgb*_Highlights.rgb)+i.vertexColor.rgb);
                float3 finalColor = emissive;
                float4 _Main_Texture_var = tex2D(_Main_Texture,TRANSFORM_TEX(node_4761, _Main_Texture));
                float node_4970_if_leA = step(_Main_Texture_var.r,i.vertexColor.a);
                float node_4970_if_leB = step(i.vertexColor.a,_Main_Texture_var.r);
                float node_1120 = 1.0;
                fixed4 finalRGBA = fixed4(finalColor,clamp((ceil((_Main_Texture_var.r-0.03))-lerp((node_4970_if_leA*node_1120)+(node_4970_if_leB*0.0),node_1120,node_4970_if_leA*node_4970_if_leB)),0,1));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
