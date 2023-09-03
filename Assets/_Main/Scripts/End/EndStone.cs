using DG.Tweening;
using EMA.Scripts.Utils;
using UnityEngine;

namespace _Main.Scripts.End
{
    public class EndStone : MonoBehaviour
    {
        [SerializeField] private Rigidbody[] rbs;

        [SerializeField] private Vector2 randomForceInterval;

        public void BreakStone()
        {
            var pos = transform.position;
            foreach (var rb in rbs)
            {
                var dir = rb.transform.position - pos;
                dir.Normalize();
                var force = Random.Range(randomForceInterval.x, randomForceInterval.y);
                rb.isKinematic = false;
                rb.AddForce(dir * (force * Time.deltaTime), ForceMode.Impulse);
                rb.transform.DOLocalRotate(
                    transform.localRotation.eulerAngles +
                    (new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)) * 360f)
                    , Random.Range(1f, 2f),
                    RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
                rb.transform.DOScale(Vector3.zero, 1f).SetEase(Ease.InQuad);
            }
        }
    }
}