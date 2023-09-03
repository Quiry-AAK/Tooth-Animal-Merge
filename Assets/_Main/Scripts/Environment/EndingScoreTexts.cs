using System;
using TMPro;
using UnityEngine;

namespace _Main.Scripts.Environment
{
    public class EndingScoreTexts : MonoBehaviour
    {
        [SerializeField] private GameObject[] endings;

        private void Start()
        {
            var score = 0;
            foreach (var ending in endings)
            {
                score += 10;
                ending.GetComponentInChildren<TextMeshProUGUI>().text = score.ToString();
            }
        }
    }
}