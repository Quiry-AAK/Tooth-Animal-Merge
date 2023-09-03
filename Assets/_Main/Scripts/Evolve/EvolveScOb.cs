using System;
using UnityEngine;

namespace _Main.Scripts.Evolve
{
    [CreateAssetMenu(fileName = "New Evolve", menuName = "Evolves")]
    public class EvolveScOb : ScriptableObject
    {
        [SerializeField] private int level;
        [SerializeField] private GameObject animal;

        public int Level => level;

        public GameObject Animal => animal;
    }
}