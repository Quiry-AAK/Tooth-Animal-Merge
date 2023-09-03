using System;
using UnityEngine;

namespace EMA.DotLine
{
    [Serializable]
    public struct DotProps
    {
        [SerializeField] private int dotCount;
        [Range(0f,1f)][SerializeField] private float scale;

        public int DotCount => dotCount;
        public float Scale => scale;
    }
}