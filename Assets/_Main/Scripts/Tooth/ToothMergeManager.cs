using System;
using _Main.Scripts.Addons;
using _Main.Scripts.FXes;
using DG.Tweening;
using EMA_HC.Scripts.Merge;
using EMA_HC.Scripts.SimpleTail;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Main.Scripts.Tooth
{
    [Serializable]
    public class ToothMergeManager
    {
        [SerializeField] private Transform modelHolder;
        [SerializeField] private ToothMergeFX toothMergeFX;
        [SerializeField] private TailManager tailManager;
        [SerializeField] private float scale;
        [SerializeField] private float duration;
        private void MergeVisuals(GameObject newObj)
        {
            var tr = newObj.transform;
            tr.DOScale(Vector3.one * scale, duration).SetLoops(2, LoopType.Yoyo).SetEase(Ease.OutQuad);
            toothMergeFX.ActiveToothMergeFX(newObj.transform);
        }

        public void Merge(Mergeable mergeable, Mergeable mergeable2, bool mainTooth)
        {
            var newObj = mergeable.Merge(mergeable2);
            MergeVisuals(newObj);
            AfterMergeAdjustments(newObj, mainTooth);
        }

        public void LevelUpAMergeable(Mergeable mergeable, bool mainTooth, float ignoreGateDuration)
        {
            var newObj = mergeable.LevelUp();
            MergeVisuals(newObj);
            var ignoreGate = newObj.AddComponent<IgnoreGate>();
            Object.Destroy(ignoreGate, ignoreGateDuration);
            AfterMergeAdjustments(newObj, mainTooth);
        }

        public void LevelDownAMergeable(Mergeable mergeable, bool mainTooth, float ignoreGateDuration)
        {
            var newObj = mergeable.LevelDown();
            MergeVisuals(newObj);
            var ignoreGate = newObj.AddComponent<IgnoreGate>();
            Object.Destroy(ignoreGate, ignoreGateDuration);
            AfterMergeAdjustments(newObj, mainTooth);
        }

        public void AfterMergeAdjustments(GameObject newObj, bool mainTooth)
        {
            if (mainTooth)
            {
                newObj.transform.SetParent(modelHolder);
                newObj.transform.localPosition = Vector3.zero;
            }
            else
            {
                var tail = newObj.AddComponent<Tail>();
                tailManager.AddTail(tail);
            }
        }
    }
}