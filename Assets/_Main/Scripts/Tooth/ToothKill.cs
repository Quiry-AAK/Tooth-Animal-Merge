using System;
using DG.Tweening;
using EMA_HC.Scripts.SimpleTail;
using UnityEngine;

namespace _Main.Scripts.Tooth
{
    public class ToothKill : MonoBehaviour
    {
        [SerializeField] private Collider col;
        [SerializeField] private Rigidbody rb;

        public ToothKill(Collider col, Rigidbody rb)
        {
            this.col = col;
            this.rb = rb;
        }

        public void KillTooth()
        {
            col.isTrigger = false;
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}