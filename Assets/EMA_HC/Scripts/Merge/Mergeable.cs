using System;
using UnityEngine;
using UnityEngine.Events;

namespace EMA_HC.Scripts.Merge
{
    public class Mergeable : MonoBehaviour
    {
        [SerializeField] private int currentLevel;

        public int CurrentLevel => currentLevel;

        public bool CheckMerge(Mergeable mergeable)
        {
            return mergeable.currentLevel == currentLevel && GlobalMergeManager.Instance.AllMerges.Count > currentLevel;
        }

        public GameObject Merge(Mergeable mergeable)
        {
            var parent = transform.parent;
            Destroy(mergeable.gameObject);
            var newObj  = Instantiate(GlobalMergeManager.Instance.AllMerges[currentLevel].Prefab, parent, true);
            Destroy(gameObject);
            return newObj;
        }

        public GameObject LevelDown()
        {
            var newLevel = currentLevel - 2;
            newLevel = Mathf.Clamp(newLevel, 0, GlobalMergeManager.Instance.AllMerges.Count - 1);
            var parent = transform.parent;
            var newObj  = Instantiate(GlobalMergeManager.Instance.AllMerges[newLevel].Prefab, parent, true);
            Destroy(gameObject);
            return newObj;
        }

        public GameObject LevelUp()
        {
            var parent = transform.parent;
            var newObj  = Instantiate(GlobalMergeManager.Instance.AllMerges[currentLevel].Prefab, parent, true);
            Destroy(gameObject);
            return newObj;
        }
    }
}