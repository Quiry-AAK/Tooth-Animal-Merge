using System.Collections.Generic;
using EMA.Scripts.PatternClasses;
using UnityEngine;

namespace EMA_HC.Scripts.Merge
{
    public class GlobalMergeManager : MonoSingleton<GlobalMergeManager>
    {
        [SerializeField] private List<MergeScOb> allMerges;

        public List<MergeScOb> AllMerges => allMerges;
    }
}