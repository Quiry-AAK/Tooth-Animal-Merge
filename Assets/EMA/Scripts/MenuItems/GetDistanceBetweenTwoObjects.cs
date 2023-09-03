using UnityEditor;
using UnityEngine;

namespace EMA.Scripts.MenuItems
{
    public class GetDistanceBetweenTwoObjects : MonoBehaviour
    {
        #if UNITY_EDITOR

        [MenuItem("EMA/Calculate Distance Between Two Objects")]

        #endif
        
        public static void LookAtTheCamera()
        {
            #if UNITY_EDITOR
            var objects = Selection.objects;
            if (objects.Length != 2)
            {
                Debug.LogError("Select 2 Objects !!!");
                return;
            }
            Debug.Log(Vector3.Distance(((GameObject)objects[0]).transform.position, ((GameObject)objects[1]).transform.position));
            #endif
        }
    }
}