using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.FXes
{
    public class ToothMergeFX : MonoBehaviour
    {
        [SerializeField] private GameObject toothMergeFx;
        [SerializeField] private float yOffset;
        public void ActiveToothMergeFX(Transform parentTr)
        {
            var newObj = Instantiate(toothMergeFx);
            newObj.transform.SetParent(parentTr);
            newObj.transform.localPosition = Vector3.up * yOffset;
            Destroy(newObj, .5f);
        }
    }
}