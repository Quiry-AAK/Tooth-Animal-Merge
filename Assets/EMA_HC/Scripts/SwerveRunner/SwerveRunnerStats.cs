using System;
using UnityEngine;

namespace EMA_HC.Scripts.SwerveRunner
{
    [Serializable]
    public struct SwerveRunnerStats
    {
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private float runSpeed;

        #region Props

        public float HorizontalSpeed => horizontalSpeed;

        public float RunSpeed => runSpeed;

        #endregion
    }
}