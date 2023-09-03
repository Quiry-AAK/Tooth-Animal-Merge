using System;
using UnityEngine;

namespace EMA_HC.Scripts.SimpleTail
{
    public class Tail : MonoBehaviour
    {
        private Transform _tr;
        private TailManager _tailManager;

        public Transform Tr => _tr;

        public TailManager TailManager
        {
            get => _tailManager;
            set => _tailManager = value;
        }

        private void Awake()
        {
            _tr = transform;
        }

        private void OnDisable()
        {
            if (_tailManager.Tails.Contains(this))
                _tailManager.RemoveTailByIndex(_tailManager.Tails.IndexOf(this));
        }
    }
}