using UnityEngine;
using UnityEngine.SceneManagement;

namespace ModernBng.Util
{
    internal static class UnityUtil
    {
        const string _standardShaderName = "Standard";
        internal static Shader StandardShader { get; }

        static UnityUtil()
        {
            StandardShader = Shader.Find(_standardShaderName);
        }

        internal static Scene GetSceneByName(string name)
        {
            return SceneManager.GetSceneByName(name);
        }

        internal static Material CreateMaterialForStandardShader(Texture shipTexture)
        {
            var mat = new Material(StandardShader);
            mat.SetFloat("_Metallic", 0.3f);
            mat.SetFloat("_Glossiness", 0.1f);
            mat.mainTexture = shipTexture;
            return mat;
        }

        internal static void ApplyStandardShaderToGameObject(GameObject obj)
        {
            var renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                obj.GetComponent<Renderer>().material.shader = StandardShader;
            }
        }

        internal static void ResetUnityLighting(string skyMaterialRef)
        {
            RenderSettings.ambientEquatorColor = Color.black;
            RenderSettings.ambientGroundColor = Color.black;
            RenderSettings.ambientIntensity = 0;
            RenderSettings.reflectionIntensity = 0;
            RenderSettings.customReflection = null;
            RenderSettings.ambientLight = Color.black;

            RenderSettings.skybox = GameObject.Find(skyMaterialRef)?.GetComponent<Renderer>().material;
            if (RenderSettings.skybox != null)
            {
                RenderSettings.skybox.globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;
                RenderSettings.skybox.color = Color.black;
            }
        }
    }
}
