using EMA_HC.Scripts.Merge;
using UnityEngine;

namespace _Main.Scripts.Tooth
{
    public class MainToothMergeableHolder : MonoBehaviour
    {
        [SerializeField] private Transform mergeableTr;

        public Mergeable CurrentMergeable => mergeableTr.GetComponentInChildren<Mergeable>();
    }
}