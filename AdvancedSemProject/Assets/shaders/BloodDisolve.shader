// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32582,y:32576,varname:node_4795,prsc:2|emission-2053-RGB,alpha-2720-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:30722,y:32846,ptovrint:False,ptlb:Main_Texture,ptin:_Main_Texture,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4761-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:30740,y:32646,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_If,id:4970,x:31599,y:33010,varname:node_4970,prsc:2|A-6074-R,B-2053-A,GT-2637-OUT,EQ-1120-OUT,LT-1120-OUT;n:type:ShaderForge.SFN_TexCoord,id:9678,x:29919,y:32851,varname:node_9678,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:4728,x:30144,y:32851,varname:node_4728,prsc:2|A-9678-UVOUT,B-7556-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7556,x:29932,y:33112,ptovrint:False,ptlb:PixelSize,ptin:_PixelSize,varname:node_7556,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:16;n:type:ShaderForge.SFN_Floor,id:1963,x:30313,y:32846,varname:node_1963,prsc:2|IN-4728-OUT;n:type:ShaderForge.SFN_Divide,id:4761,x:30523,y:32846,varname:node_4761,prsc:2|A-1963-OUT,B-7556-OUT;n:type:ShaderForge.SFN_Vector1,id:1120,x:31396,y:33117,varname:node_1120,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:2637,x:31396,y:33044,varname:node_2637,prsc:2,v1:0;n:type:ShaderForge.SFN_Subtract,id:2689,x:31368,y:32799,varname:node_2689,prsc:2|A-6074-R,B-2475-OUT;n:type:ShaderForge.SFN_Vector1,id:2475,x:31191,y:32845,varname:node_2475,prsc:2,v1:0.03;n:type:ShaderForge.SFN_Ceil,id:8403,x:31552,y:32799,varname:node_8403,prsc:2|IN-2689-OUT;n:type:ShaderForge.SFN_Subtract,id:9769,x:31826,y:32871,varname:node_9769,prsc:2|A-8403-OUT,B-4970-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:2720,x:32200,y:32886,varname:node_2720,prsc:2,min:0,max:1|IN-9769-OUT;proporder:6074-7556;pass:END;sub:END;*/

Shader "Shader Forge/BloodDisolve" {
    Properties {
        _Main_Texture ("Main_Texture", 2D) = "white" {}
        _PixelSize ("PixelSize", Float ) = 16
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
                float3 emissive = i.vertexColor.rgb;
                float3 finalColor = emissive;
                float2 node_4761 = (floor((i.uv0*_PixelSize))/_PixelSize);
                float4 _Main_Texture_var = tex2D(_Main_Texture,TRANSFORM_TEX(node_4761, _Main_Texture));
                float node_4970_if_leA = step(_Main_Texture_var.r,i.vertexColor.a);
                float node_4970_if_leB = step(i.vertexColor.a,_Main_Texture_var.r);
                float node_1120 = 1.0;
                float node_9769 = (ceil((_Main_Texture_var.r-0.03))-lerp((node_4970_if_leA*node_1120)+(node_4970_if_leB*0.0),node_1120,node_4970_if_leA*node_4970_if_leB));
                fixed4 finalRGBA = fixed4(finalColor,clamp(node_9769,0,1));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
