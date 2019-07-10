using ModernBng.Core.Models;
using UnityEngine;

namespace ModernBng.Util.UnityExtensionMethods
{
    public static class CameraExtensions
    {
        public static Camera SetSettings(this Camera cam, ModernSettingsForUnityCamera settings)
        {
            cam.clearFlags = settings.ClearFlags;
            cam.renderingPath = settings.RenderingPath;
            cam.targetTexture = settings.TargetTexture;
            cam.backgroundColor = settings.BackgroundColor;
            cam.allowHDR = settings.AllowHDR;
            cam.allowMSAA = settings.AllowMSAA;
            cam.useOcclusionCulling = settings.UseOcclusionCulling;
            cam.fieldOfView = settings.FieldOfView;
            cam.nearClipPlane = settings.NearClipPlane;
            cam.farClipPlane = settings.FarClipPlane;
            cam.depth = settings.Depth;
            return cam;
        }
    }
}
