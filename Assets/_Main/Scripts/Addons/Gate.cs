using System;
using _Main.Scripts.Tooth;
using EMA_HC.Scripts.Merge;
using UnityEngine;

namespace _Main.Scripts.Addons
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private bool positive;
        [SerializeField] private float ignoreDuration;
        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.TryGetComponent(out Mergeable mergeable))
            {
                if(mergeable.GetComponent<IgnoreGate>()) return;
                if (positive)
                {
                    if (mergeable.CheckMerge(mergeable))
                        ToothCollisionManager.Instance.ToothMergeManager.LevelUpAMergeable(mergeable,
                            mergeable == ToothCollisionManager.Instance.MainToothMergeableHolder.CurrentMergeable, ignoreDuration);
                }
                else
                {
                    ToothCollisionManager.Instance.ToothMergeManager.LevelDownAMergeable(mergeable,
                        mergeable == ToothCollisionManager.Instance.MainToothMergeableHolder.CurrentMergeable, ignoreDuration);
                }
            }
        }
    }
}