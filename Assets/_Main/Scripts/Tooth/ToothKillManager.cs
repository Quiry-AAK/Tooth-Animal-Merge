using System;
using System.Collections.Generic;
using Cinemachine;
using EMA_HC.Scripts.SimpleTail;
using EMA_HC.Scripts.SwerveRunner;
using EMA.Scripts.MyShortcuts;
using EMA.Scripts.PatternClasses;
using JetBrains.Annotations;
using UnityEngine;

namespace _Main.Scripts.Tooth
{
    public class ToothKillManager : MonoSingleton<ToothKillManager>
    {
        [SerializeField] [NotNull] private CinemachineVirtualCamera vCam1;
        [SerializeField] private Transform playerTr;
        [SerializeField] private Rigidbody playerRb;
        [SerializeField] private SwerveRunnerManager swerveRunnerManager;
        [SerializeField] private TailManager tailManager;
        
        public void KillTooth(ToothKill toothKill)
        {
            var tail = toothKill.GetComponent<Tail>();
            if(tail == null)
            {
                swerveRunnerManager.FillMoveInputs(false);
                Destroy(swerveRunnerManager);
                toothKill.KillTooth();
                for (int i = 1; i < tailManager.Tails.Count; i++)
                {
                    var toothKillI = tailManager.Tails[i].GetComponent<ToothKill>();
                    toothKillI.KillTooth();
                    tailManager.RemoveTailByIndex(i);
                }
                toothKill.transform.SetParent(null);
                playerTr.SetParent(toothKill.transform);
                MyShortcuts.RemoveMomentum(playerRb);
                vCam1.Follow = null;
                playerTr.localPosition = Vector3.zero;
                PopUpManager.Instance.ShowPopUp(true);
            }
            else
            {
                var index = tailManager.Tails.IndexOf(tail);
                for (int i = tailManager.Tails.Count - 1 ; i > index; i--)
                {
                    var toothKillI = tailManager.Tails[i].GetComponent<ToothKill>();
                    toothKillI.KillTooth();
                    tailManager.Tails.Remove(tailManager.Tails[i]);
                }
            }
        }
    }
}