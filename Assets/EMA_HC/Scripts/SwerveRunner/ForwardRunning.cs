using System;
using UnityEngine;

namespace EMA_HC.Scripts.SwerveRunner
{
    public class ForwardRunning
    {
        private Rigidbody playerRb;
        private Transform playerTr;
        private float forwardMoveSpeed;

        public ForwardRunning(Rigidbody playerRb, Transform playerTr, float forwardMoveSpeed)
        {
            this.playerRb = playerRb;
            this.playerTr = playerTr;
            this.forwardMoveSpeed = forwardMoveSpeed;
        }

        public void Move()
        {
            if (playerTr == null) playerTr = playerRb.transform;
            var _inversedVel = playerTr.InverseTransformDirection(playerRb.velocity);
            _inversedVel.z = forwardMoveSpeed * Time.fixedDeltaTime;
            var _vel = playerTr.TransformDirection(_inversedVel);

            playerRb.velocity = _vel;
        }
    }
}