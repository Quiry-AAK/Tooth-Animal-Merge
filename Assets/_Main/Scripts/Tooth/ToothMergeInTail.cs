using System;
using System.Collections;
using System.Collections.Generic;
using EMA_HC.Scripts.Merge;
using EMA_HC.Scripts.SimpleTail;
using UnityEngine;

namespace _Main.Scripts.Tooth
{
    public class ToothMergeInTail : MonoBehaviour
    {
        [SerializeField] private TailManager tailManager;
        [SerializeField] private MainToothMergeableHolder mainToothMergeableHolder;

        [SerializeField] private ToothCollisionManager toothCollisionManager;
        [SerializeField] private float mergeInTailSpeed;
        [SerializeField] private float mergeDelay;

        private bool mergeProgress = false;
        private bool triggeredInMergeProgress = false;

        private List<Mergeable> mergeableList;
        

        public void CheckMergeForTailList()
        {
            if (mergeProgress)
            {
                return;
            }

            mergeableList = new List<Mergeable>();
            mergeableList.Add(mainToothMergeableHolder.CurrentMergeable);
            for (int i = 1; i < tailManager.Tails.Count; i++)
            {
                mergeableList.Add(tailManager.Tails[i].GetComponent<Mergeable>());
            }

            for (int i = 0; i < tailManager.Tails.Count - 1; i++)
            {
                if (mergeableList[i].CheckMerge(mergeableList[i+1]))
                {
                    if (!mergeProgress)
                        StartCoroutine(StartMergeInTail(mergeableList[i+1], mergeableList[i]));
                }
            }
        }

        IEnumerator StartMergeInTail(Mergeable iMergeable, Mergeable iMinusOneMergeable)
        {
            mergeProgress = true;
            yield return new WaitForSeconds(mergeDelay);
            var iMergeableTr = iMergeable.transform;
            var iMinusOneMergeableTr = iMinusOneMergeable.transform;
            while (Vector3.Distance(iMergeableTr.position, iMinusOneMergeableTr.position) > .3f)
            {
                iMergeableTr.position =
                    Vector3.MoveTowards(iMergeableTr.position, iMinusOneMergeableTr.position,
                        Time.deltaTime * mergeInTailSpeed);
                yield return null;
            }

            toothCollisionManager.ToothMergeManager.Merge(iMergeable, iMinusOneMergeable,
                iMinusOneMergeable == mainToothMergeableHolder.CurrentMergeable);
            mergeProgress = false;
            CheckMergeForTailList();
        }

        public void CutCurrentMergeProgress()
        {
            StopAllCoroutines();
            mergeProgress = false;
        }
    }
}