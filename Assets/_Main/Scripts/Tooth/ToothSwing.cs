using System;
using UnityEngine;

namespace _Main.Scripts.Tooth
{
    public class ToothSwing : MonoBehaviour
    {
        [SerializeField] private Transform modelHolder;
        [SerializeField] private float swingSpeed;
        [SerializeField] private float swing;

        private void Update()
        {
            var pos = modelHolder.localPosition;
            pos.y = Mathf.Sin(Time.time * swingSpeed) * swing;
            modelHolder.localPosition = pos;
        }
    }
}