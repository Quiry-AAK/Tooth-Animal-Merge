using System;
using EMA_HC.Scripts.Merge;
using EMA_HC.Scripts.SimpleTail;
using EMA.Scripts.PatternClasses;
using UnityEngine;

namespace _Main.Scripts.Tooth
{
    public class ToothCollisionManager : MonoSingleton<ToothCollisionManager>
    {
        [SerializeField] private MainToothMergeableHolder mainToothMergeableHolder;
        [SerializeField] private TailManager tailManager;

        [SerializeField] private ToothMergeManager toothMergeManager;
        [SerializeField] private ToothMergeInTail toothMergeInTail;

        public ToothMergeManager ToothMergeManager => toothMergeManager;

        public MainToothMergeableHolder MainToothMergeableHolder => mainToothMergeableHolder;

        public void TriggerMergeOrTail(Mergeable mergeable)
        {
            if (mergeable.CheckMerge(mainToothMergeableHolder.CurrentMergeable))
            {
                toothMergeManager.Merge(mainToothMergeableHolder.CurrentMergeable, mergeable, true);
            }

            else
            {
                if (mainToothMergeableHolder.CurrentMergeable.CurrentLevel > mergeable.CurrentLevel)
                {
                    Destroy(mergeable.gameObject);
                    var newObj = Instantiate(GlobalMergeManager.Instance.AllMerges[mergeable.CurrentLevel-1].Prefab);
                    var newTail = newObj.AddComponent<Tail>();
                    tailManager.AddTail(newTail);
                    toothMergeInTail.CheckMergeForTailList();
                }
                else
                {
                    // Bump
                }
            }
        }
    }
}