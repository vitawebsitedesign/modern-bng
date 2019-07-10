using UnityEngine;

namespace ModernBng.Core
{
    /// <summary>
    /// Adapter between BallisticNG and C#/Unity.
    /// This is here to minimise the impact when
    /// the BallisticNG API changes.
    /// </summary>
    static class BngAdapter
    {
        internal static Texture ShipTexture(ShipRefs ship)
        {
            return ship.ShipRenderer.material.mainTexture;
        }

        internal static MeshRenderer ShipMeshRenderer(ShipRefs ship)
        {
            return ship.ShipRenderer;
        }

        internal static Projector ShipShadowProjector(ShipRefs ship)
        {
            return ship.ShadowProjector;
        }
    }
}
