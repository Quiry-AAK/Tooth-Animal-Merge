using System;
using _Main.Scripts.Tooth;
using EMA.Scripts.MyShortcuts;
using UnityEngine;

namespace _Main.Scripts.End
{
    public class ToothEndRun : MonoBehaviour
    {
        [SerializeField] private GameObject endingTrail;
        [SerializeField] private GameObject[] confettiFx;
        [SerializeField] private ToothSwing[] swings;
        [SerializeField] private ToothEvolveManager toothEvolveManager;
        [SerializeField] private Rigidbody playerRb;
        [SerializeField] private float runSpeed;

        private float breakStone;
        
        private bool running = false;
        
        public void StartRunning()
        {
            endingTrail.SetActive(true);
            running = true;
            breakStone = ToothCollisionManager.Instance.MainToothMergeableHolder.CurrentMergeable.CurrentLevel;
            foreach (var swing in swings)
            {
                Destroy(swing);
            }
        }

        private void Update()
        {
            if(!running) return;
            playerRb.velocity = Vector3.forward * (runSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out EndStone endStone))
            {
                endStone.BreakStone();
                breakStone--;
                if (breakStone == 0)
                {
                    running = false;
                    toothEvolveManager.MakeAnimalsDance();
                    foreach (var confetti in confettiFx)
                    {
                        confetti.SetActive(true);
                    }
                    MyShortcuts.RemoveMomentum(playerRb);
                }
            }
        }
    }
}