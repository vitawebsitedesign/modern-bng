using ModernBng.Core.Models;
using ModernBng.Util;
using ModernBng.Util.UnityExtensionMethods;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ModernBng.Core
{
    public static class ModernBngCore
    {
        /// <summary>
        /// Tries to apply modern Unity graphics to the current BallsiticNG track scene.
        /// </summary>
        /// <param name="ship">A BallisticNG ShipRef object</param>
        /// <param name="unityScene">An object specifying certain GameObject names in your Unity scene</param>
        /// <returns>False if the unityScene argument is invalid, otherwise true.</returns>
        public static async Task<bool> TryApplyModernGfx(ShipRefs ship, UnityScene unityScene)
        {
            if (CanApplyModernGfx(unityScene))
            {
                ApplyModernGfx(ship, unityScene);
                return true;
            }
            else
            {
                await LogUtil.Log("Cant apply modern graphics (is your unityScene parameter correct?)");
                return false;
            }
        }

        static bool CanApplyModernGfx(UnityScene unityScene)
        {
            return unityScene != null
                && UnityUtil.GetSceneByName(unityScene.SceneNameWithUnityLighting) != null
                && GameObject.Find(unityScene.SunObject) != null
                && GameObject.Find(unityScene.ModernSceneryObject) != null
                && GameObject.Find(unityScene.SkyMaterialObject) != null
                && GameObject.Find(unityScene.PostProcessingObject) != null;
        }

        static void ApplyModernGfx(ShipRefs ship, UnityScene unityScene)
        {
            using (var p = new TimerUtil())
            {
                ApplyUnityLightingToScene(unityScene);
                ApplyStandardShaderToScenery(unityScene);
                ApplyStandardShaderToShip(ship);
                ApplyDynamicShadows(ship);
                ApplyNewCamera(unityScene);
            }
        }

        static void ApplyUnityLightingToScene(UnityScene unityScene)
        {
            GameObject.Find(unityScene.ModernSceneryObject).ForThisObjectAndItsChildren(UnityEngine.Object.Destroy);
            UnityEngine.Object.FindObjectsOfType<Light>().ForTheseObjects(UnityEngine.Object.Destroy);
            SceneManager.LoadScene(unityScene.SceneNameWithUnityLighting, LoadSceneMode.Additive);
            UnityUtil.ResetUnityLighting(unityScene.SkyMaterialObject);
        }

        static void ApplyStandardShaderToScenery(UnityScene unityScene)
        {
            GameObject.Find(unityScene.ModernSceneryObject).ForThisObjectAndItsChildren(UnityUtil.ApplyStandardShaderToGameObject);
        }

        static void ApplyStandardShaderToShip(ShipRefs ship)
        {
            var shipTex = BngAdapter.ShipTexture(ship);
            BngAdapter.ShipMeshRenderer(ship).material = UnityUtil.CreateMaterialForStandardShader(shipTex);
        }

        static void ApplyDynamicShadows(ShipRefs ship)
        {
            BngAdapter.ShipShadowProjector(ship).enabled = false;
            QualitySettings.shadows = ShadowQuality.All;
        }

        static void ApplyNewCamera(UnityScene unityScene)
        {
            var cameraWithModernSettings = new GameObject().AddComponent<Camera>().SetSettings(new ModernSettingsForUnityCamera());
            Camera.current.enabled = false;
            Camera.SetupCurrent(cameraWithModernSettings);
        }
    }
}
