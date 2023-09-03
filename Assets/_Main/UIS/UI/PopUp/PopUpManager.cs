using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using EMA.Scripts.PatternClasses;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUpManager : MonoSingleton<PopUpManager>
{
    [SerializeField] private TMP_Text winLoseTxt;
    [SerializeField] private GameObject popUpBack;
    [SerializeField] private GameObject popUpMain;

    [SerializeField] private Button nextLevelBtn;
    [SerializeField] private Button showAdsBtn;


    public void ShowPopUp(bool status)
    {
        winLoseTxt.text = status ? "You Win" : "You Lose";
        BtnControl(status);
        popUpBack.transform.DOScale(1, 0.7f).SetEase(Ease.OutBack);
    }

    public void ClosePopUp()
    {
        popUpBack.transform.DOScale(0, 0.5f).SetEase(Ease.InBack).OnComplete(() => popUpMain.gameObject.SetActive(false));
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }

    private void BtnControl(bool status)
    {
        if (status)
        {
            nextLevelBtn.gameObject.SetActive(true);
            showAdsBtn.gameObject.SetActive(false);
        }
        else
        {
            nextLevelBtn.gameObject.SetActive(false);
            showAdsBtn.gameObject.SetActive(true);
        }
    }
}
