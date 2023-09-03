using System;
using _Main.Scripts.Tooth;
using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class ObstacleManager : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ToothKill toothKill))
            {
                ToothKillManager.Instance.KillTooth(toothKill);
            }
        }
    }
}