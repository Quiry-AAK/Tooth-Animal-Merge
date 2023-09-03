using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.Animals
{
    public class AnimalManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void StartRunningAnimation()
        {
            animator.SetBool("Running", true);
        }

        public void MakeDance()
        {
            transform.DOLocalRotate(Vector3.up * 180f, .5f).SetEase(Ease.InBack);
            animator.SetBool("Dancing", true);
        }
    }
}