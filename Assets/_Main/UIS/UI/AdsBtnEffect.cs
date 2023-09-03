using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AdsBtnEffect : MonoBehaviour
{
    [SerializeField] private Button adsBtn;
    private void Start()
    {
        StartButtonEffect();
    }

    private void StartButtonEffect()
    {
        adsBtn.transform.DOScale(0.9f, 0.5f).SetEase(Ease.InBack).OnComplete(StopButtonEffect);
    }
    private void StopButtonEffect()
    {
        adsBtn.transform.DOScale(1f, 0.5f).SetEase(Ease.InBack).OnComplete(StartButtonEffect);
    }
}
