using System.Collections.Generic;
using _Main.Scripts.FXes;
using _Main.Scripts.Tooth;
using DG.Tweening;
using EMA_HC.Scripts.Merge;
using EMA.Scripts.PatternClasses;
using UnityEngine;

namespace _Main.Scripts.Evolve
{
    public class EvolveManager : MonoSingleton<EvolveManager>
    {
        [SerializeField] private List<EvolveScOb> evolveScObs;
        [SerializeField] private GameObject toothEvolveFx;
        [SerializeField] private GameObject toothMergeFx;
        private GameObject GetEvolvePrefab(Mergeable mergeable)
        {
            return evolveScObs[mergeable.CurrentLevel-1].Animal;
        }

        public GameObject EvolveTooth(Mergeable mergeable)
        {
            var evolveFx = Instantiate(toothEvolveFx);
            evolveFx.transform.position = mergeable.transform.position;
            mergeable.transform.DOScale(Vector3.zero, .5f).SetEase(Ease.InBack);
            var animal = Instantiate(GetEvolvePrefab(mergeable));
            animal.transform.localScale = Vector3.zero;
            ToothCollisionManager.Instance.ToothMergeManager.AfterMergeAdjustments(animal, mergeable == ToothCollisionManager.Instance.MainToothMergeableHolder.CurrentMergeable);
            animal.transform.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack).SetDelay(.5f);
            DOVirtual.DelayedCall(.5f, () =>
            {
                Instantiate(toothMergeFx);
                toothMergeFx.transform.position = animal.transform.position;
            });
            return animal;
        }
    }
}