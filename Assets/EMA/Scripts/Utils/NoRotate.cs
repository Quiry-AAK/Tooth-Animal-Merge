using System;
using UnityEngine;

namespace EMA.Scripts.Utils
{
    public class NoRotate : MonoBehaviour
    {
        private Transform tr;

        private void Start()
        {
            tr = transform;
        }

        private void Update()
        {
            tr.rotation = Quaternion.identity;
        }
    }
}