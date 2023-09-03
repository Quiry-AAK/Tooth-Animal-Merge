using UnityEditor;
using UnityEngine;

namespace EMA.Scripts.MenuItems
{
    public class CameraLookProvider : MonoBehaviour
    {
        #if UNITY_EDITOR

        [MenuItem("EMA/Look At The Camera")]
        
        #endif
        public static void LookAtTheCamera()
        {
            #if UNITY_EDITOR
            var _tr = Selection.activeTransform;
            _tr.LookAt(Camera.main.transform);
            #endif
        }

        public static void LookAtTheCamera(Transform tr)
        {
            tr.LookAt(Camera.main.transform);
        }

    }
}