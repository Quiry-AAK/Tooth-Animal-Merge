using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EMA.DotLine
{
    public class DotLineManager : MonoBehaviour
    {
        [SerializeField] private DotCreator dotCreator;
        [SerializeField] private DotProps dotProps;

        private Transform _dotsParent;

        private List<Transform> _dots = new List<Transform>();

        #region Props
        public DotCreator DotCreator => dotCreator;
        public DotProps DotProps => dotProps;
        public Transform DotsParent => _dotsParent;
        public List<Transform> Dots => _dots;
        #endregion


        private void Start()
        {
            _dotsParent = transform;
            foreach (var dots in _dotsParent)
            {
                _dots.Add((Transform)dots);
            }
        }

        public void DrawLine(List<Vector3> points)
        {
            if (points.Count != dotProps.DotCount)
            {
                Debug.LogError("Dot Count is not equal to points.Count");
                return;
            }

            for (int i = 0; i < points.Count; i++)
            {
                _dots[i].position = points[i];
            }
        }

        #if UNITY_EDITOR
        private void OnValidate()
        {
            EditorApplication.delayCall += _OnValidate;
        }

        #endif
        private void _OnValidate()
        {
            if (_dotsParent == null)
            {
                _dotsParent = transform;
            }
            if (_dotsParent.childCount != dotProps.DotCount)
            {
                Scripts.MyShortcuts.MyShortcuts.DeleteChildrenOfList(_dotsParent);
                for (int i = 0; i < dotProps.DotCount; i++)
                {
                    var dot = dotCreator.InstantiateDot(_dotsParent);
                    AdjustScaleForADot(dot.transform);
                }
            }

            if (_dotsParent.childCount <= 0) return;
            if (dotProps.Scale * Vector3.one != _dotsParent.GetChild(0).lossyScale)
            {
                for (int i = 0; i < dotProps.DotCount; i++)
                {
                    var dot = _dotsParent.GetChild(i);
                    AdjustScaleForADot(dot);
                }
            }
        }

        private void AdjustScaleForADot(Transform dot)
        {
            dot.SetParent(null);
            dot.localScale = dotProps.Scale * Vector3.one;
            dot.SetParent(_dotsParent);
        }
    }
}