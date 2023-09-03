using UnityEngine;

namespace EMA_HC.Scripts.Merge
{
    [CreateAssetMenu(menuName = "Mergeable", fileName = "New Merge")]
    public class MergeScOb : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int level;

        #region Props

        public GameObject Prefab => prefab;

        public int Level => level;

        #endregion
    }
}