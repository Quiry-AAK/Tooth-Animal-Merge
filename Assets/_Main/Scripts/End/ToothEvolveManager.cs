using System.Collections.Generic;
using _Main.Scripts.Animals;
using _Main.Scripts.Evolve;
using _Main.Scripts.Tooth;
using DG.Tweening;
using EMA_HC.Scripts.Merge;
using EMA_HC.Scripts.SimpleTail;
using UnityEngine;

namespace _Main.Scripts.End
{
    public class ToothEvolveManager : MonoBehaviour
    {
        [SerializeField] private ToothEndRun toothEndRun;
        [SerializeField] private MainToothMergeableHolder mainToothMergeableHolder;
        [SerializeField] private TailManager tailManager;
        private List<Mergeable> mergeableList;
        private List<AnimalManager> animalsList;

        public void EvolveAllTeeth()
        {
            animalsList =new List<AnimalManager>();
            mergeableList = new List<Mergeable>();
            mergeableList.Add(mainToothMergeableHolder.CurrentMergeable);
            for (int i = 1; i < tailManager.Tails.Count; i++)
            {
                mergeableList.Add(tailManager.Tails[i].GetComponent<Mergeable>());
            }

            foreach (var mergeable in mergeableList)
            {
                var animalManager = EvolveManager.Instance.EvolveTooth(mergeable).GetComponent<AnimalManager>();
                animalsList.Add(animalManager);
                DOVirtual.DelayedCall(1f, ()=> animalManager.StartRunningAnimation());
            }
            DOVirtual.DelayedCall(1f, ()=>toothEndRun.StartRunning());
        }

        public void MakeAnimalsDance()
        {
            foreach (var animalManager in animalsList)
            {
                animalManager.MakeDance();
            }
        }
        
        
    }
}