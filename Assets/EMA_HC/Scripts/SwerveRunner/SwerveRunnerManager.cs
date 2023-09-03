using System;
using EMA.Scripts.InputEma;
using UnityEngine;

namespace EMA_HC.Scripts.SwerveRunner
{
    public class SwerveRunnerManager : MonoBehaviour
    {
        private SwerveRunner _swerveRunner;
        private ForwardRunning _forwardRunning;

        [Header("Movement")] [SerializeField] private Rigidbody playerRb;
        [SerializeField] private Transform playerTr;
        [SerializeField] private SwerveRunnerStats stats;

        [Space] [SerializeField] private bool stopOnRelease;
        
        [SerializeField] private bool fillInputAtStart;
        private void Start()
        {
            _swerveRunner = new SwerveRunner(playerTr, playerRb, stats.HorizontalSpeed);
            _forwardRunning = new ForwardRunning(playerRb, playerTr, stats.RunSpeed);   
            if (fillInputAtStart)
                FillMoveInputs(true);
        }

        public void FillHorizontalMoveSpeedInputs(bool value)
        {
            if (value)
            {
                SwerveInput.Instance.Swerve.AddListener(_swerveRunner.Move);
            }
            else
            {
                SwerveInput.Instance.Swerve.RemoveListener(_swerveRunner.Move);
            }
        }

        public void FillFrontalMoveSpedInputs(bool value)
        {
            if (value)
            {
                SwerveInput.Instance.CheckInput.AddListener(FrontalMove);
            }
            else
            {
                SwerveInput.Instance.CheckInput.RemoveListener(FrontalMove);
            }
        }

        public void FillMoveInputs(bool value)
        {
            FillHorizontalMoveSpeedInputs(value);
            FillFrontalMoveSpedInputs(value);
        }

        private void FrontalMove(bool value)
        {
            if (stopOnRelease & !value)
            {
                var inversedVel = playerTr.InverseTransformDirection(playerRb.velocity);
                inversedVel.z = 0f;
                playerRb.velocity = playerTr.TransformDirection(inversedVel);
                return;
            }
            _forwardRunning.Move();
        }
    }
}