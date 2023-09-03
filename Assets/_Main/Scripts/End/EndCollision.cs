using System;
using _Main.Scripts.Tooth;
using EMA_HC.Scripts.SwerveRunner;
using EMA.Scripts.InputEma;
using EMA.Scripts.MyShortcuts;
using UnityEngine;

namespace _Main.Scripts.End
{
    public class EndCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if(other.attachedRigidbody.GetComponent<SwerveRunnerManager>() == null) return;
                other.attachedRigidbody.GetComponent<SwerveRunnerManager>().FillMoveInputs(false);
                MyShortcuts.RemoveMomentum(other.attachedRigidbody);
                other.attachedRigidbody.transform.position = new Vector3(0f, other.transform.position.y, transform.position.z);
                other.attachedRigidbody.GetComponent<ToothEvolveManager>().EvolveAllTeeth();
            }
        }
    }
}