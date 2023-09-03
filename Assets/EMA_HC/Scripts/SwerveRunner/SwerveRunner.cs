using System;
using UnityEngine;

namespace EMA_HC.Scripts.SwerveRunner
{
    [Serializable]
    public class SwerveRunner
    {
        private Transform playerTr;
        private Rigidbody playerRb;
        private float horizontalSpeed;

        public SwerveRunner(Transform playerTr, Rigidbody playerRb, float horizontalSpeed)
        {
            this.playerTr = playerTr;
            this.playerRb = playerRb;
            this.horizontalSpeed = horizontalSpeed;
        }

        public void Move(Vector2 input)
        {
            if (playerTr == null) playerTr = playerRb.transform;
            var _inversedVel = playerTr.InverseTransformDirection(playerRb.velocity);
            _inversedVel.x = input.x * horizontalSpeed * Time.fixedDeltaTime;
            var _vel = playerTr.TransformDirection(_inversedVel);
           
            playerRb.velocity = _vel;
        }
    }
}