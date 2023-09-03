using System;
using EMA_HC.Scripts.Merge;
using UnityEngine;

namespace _Main.Scripts.Tooth
{
    public class ToothPickupManager : MonoBehaviour
    {
        [SerializeField] private ToothCollisionManager toothCollisionManager;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("ToothPickup"))
            {
                toothCollisionManager.TriggerMergeOrTail(other.GetComponent<Mergeable>());
            }
        }
    }
}