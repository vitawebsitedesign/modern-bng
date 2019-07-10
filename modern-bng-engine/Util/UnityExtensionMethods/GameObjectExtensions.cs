using System;
using UnityEngine;

namespace ModernBng.Util.UnityExtensionMethods
{
    public static class GameObjectExtensions
    {
        public static void ForThisObjectAndItsChildren(this GameObject parent, Action<GameObject> action)
        {
            foreach (var child in parent.GetComponentsInChildren<Transform>())
            {
                action(child.gameObject);
            }
            action(parent);
        }

        public static void ForTheseObjects<T>(this T[] objects, Action<T> action) where T : UnityEngine.Object
        {
            foreach (var obj in objects)
            {
                action(obj);
            }
        }
    }
}
