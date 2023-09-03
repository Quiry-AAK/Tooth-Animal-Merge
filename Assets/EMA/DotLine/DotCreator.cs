using System;
using EMA.Scripts.MenuItems;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EMA.DotLine
{
    [Serializable]
    public class DotCreator
    {
        [SerializeField] private Sprite dotSprite;

        public GameObject InstantiateDot(Transform parent)
        {
            var obj = new GameObject();
            obj.name = "Dot";
            obj.transform.SetParent(parent);
            obj.AddComponent<SpriteRenderer>().sprite = dotSprite;
            CameraLookProvider.LookAtTheCamera(obj.transform);
            return obj;
        }
    }
}