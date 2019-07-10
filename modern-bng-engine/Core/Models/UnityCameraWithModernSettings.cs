using UnityEngine;

namespace ModernBng.Core.Models
{
    public class ModernSettingsForUnityCamera
    {
        public CameraClearFlags ClearFlags = CameraClearFlags.Skybox;
        public RenderingPath RenderingPath = RenderingPath.DeferredShading;
        public Color BackgroundColor = Color.black;
        public RenderTexture TargetTexture = null;
        public bool AllowHDR = true;
        public bool AllowMSAA = true;
        public bool UseOcclusionCulling = false;
        public float FieldOfView = 60f;
        public float NearClipPlane = 0.3f;
        public float FarClipPlane = 1000;
        public float Depth = -1;
    }
}
