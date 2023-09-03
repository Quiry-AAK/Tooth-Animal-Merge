using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMA_HC.Scripts.SimpleTail
{
    public class TailManager : MonoBehaviour
    {
        private List<Tail> tails;
        private Vector3[] tailsV;
        private List<Vector3> tailsVList;

        [SerializeField] private GameObject tailPrefab;

        [SerializeField] private int currentLength;
        [SerializeField] private int maxLength;
        [SerializeField] private float eachTailOffset;
        [Range(1f, 15f)][SerializeField] private float followSpeed;

        private Transform tr;

        public List<Tail> Tails => tails;

        private void Start()
        {
            tr = transform;
            FillTailArray();
            RemoveTailsParent();
        }

        private void OnValidate()
        {
            if (Application.isPlaying) return;
            if (transform.childCount == currentLength) return;
            var CurrentTails = GetComponentsInChildren<Tail>();
            foreach (var CurrentTail in CurrentTails)
            {
                if (CurrentTail.gameObject == gameObject) continue;
                StartCoroutine(Destroy(CurrentTail.gameObject));
            }

            for (int i = 0; i < currentLength; i++)
            {
                var tail = Instantiate(tailPrefab, tr);
                var tailLocalPos = (i + 1) * eachTailOffset * Vector3.back;
                tail.transform.SetParent(transform);
                tail.transform.localPosition = tailLocalPos;
                tail.AddComponent<Tail>();
            }
        }

        private void FillTailArray()
        {
            tails = new List<Tail>();
            tailsV = new Vector3[tails.Count + 1];
            tails.AddRange(GetComponentsInChildren<Tail>());
            foreach (var tail in tails)
            {
                tail.TailManager = this;
            }
        }

        private void RemoveTailsParent()
        {
            for (int i = 1; i < tails.Count; i++)
            {
                tails[i].Tr.SetParent(null);
            }
        }

        public void AddTail(Tail tail)
        {
            if(tails.Count > maxLength) return;
            currentLength++;
            tails.Add(tail);
            tails[tails.Count - 1].Tr.position = tails[tails.Count - 2].Tr.position + -tr.forward * eachTailOffset;
            tail.TailManager = this;
            var oldTailsV = tailsV;
            tailsV = new Vector3[tails.Count + 1];
            for (int i = 0; i < tailsV.Length; i++)
            {
                if(i >= oldTailsV.Length) continue;
                tailsV[i] = oldTailsV[i];
            }
        }

        public void RemoveTail()
        {
            if (tails.Count < 2)
            {
                return;
            }
            tails.Remove(tails[tails.Count - 1]);
            tailsV[tailsV.Length - 1] = Vector3.zero;
        }

        public void RemoveTailByIndex(int index)
        {
            tails.Remove(tails[index]);
        }

        public void RemoveAllTailsAfterThatIndex(int index)
        {
            for (int i = index; i < tails.Count - 1; i++)
            {
                tails.Remove(tails[i]);
            }
        }

        private void Update()
        {
            for (int i = 1; i < tails.Count; i++)
            {
                tails[i].Tr.position = Vector3.SmoothDamp(tails[i].Tr.position,
                    tails[i - 1].Tr.position + -tr.forward * eachTailOffset, ref tailsV[i], 1 / followSpeed);
            }
        }

        IEnumerator Destroy(GameObject go)
        {
            yield return new WaitForEndOfFrame();
            DestroyImmediate(go);
        }
    }
}