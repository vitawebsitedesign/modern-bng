namespace ModernBng.Core.Models
{
    public class UnityScene
    {
        /// <summary>
        /// The name of the Unity Scene that has Unity lighting. This scene
        /// should contain baked Unity lighting (e.g.: GI) & optionally,
        /// realtime lights.
        /// </summary>
        public string SceneNameWithUnityLighting { get; set; }
        /// <summary>
        /// The name of the GameObject which represents the scene's sun.
        /// </summary>
        public string SunObject { get; set; }
        /// <summary>
        /// The name of the GameObject which contains scenery you want to
        /// show modern graphics for. This should be an empty GameObject,
        /// acting as a parent. It's children should all be meshes such as
        /// trees, terrain etc.
        /// </summary>
        public string ModernSceneryObject { get; set; }
        /// <summary>
        /// The name of the GameObject which uses the scene's sky material.
        /// This is used to set the camera background after switching to
        /// modern graphics.
        /// </summary>
        public string SkyMaterialObject { get; set; }
        /// <summary>
        /// The name of the object which contains the Post Processing Stack
        /// component. You can get this free addon from the Unity's Asset
        /// Store.
        /// </summary>
        public string PostProcessingObject { get; set; }
    }
}
