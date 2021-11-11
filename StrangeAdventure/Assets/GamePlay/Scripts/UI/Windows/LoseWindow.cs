using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoseWindow : UIWindowBase
{
    public Text IQ;
    private Vector2 anchoredPosition;
    protected override void OpenWindow()
    {
        anchoredPosition = transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition;
    }

    protected override void BeforeShowWindow()
    {
        IQ.text = LevelManager.Instance.CurrentIQ.ToString();
        transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
    }

    protected override void AfterShowWindow()
    {
        transform.GetChild(0).GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.5f).SetEase(Ease.Linear);
    }

    public void OnRestartButtonDown()
    {
        bool middle = FindObjectOfType<BaseLevel>().Middle;
        DestroyImmediate(FindObjectOfType<BaseLevel>().gameObject);
        LevelManager.Instance.LoadLevel(LevelManager.Instance.CurrentStage,LevelManager.Instance.CurrentLevel,middle);
        UIWindowManager.Instance.CloseWindow<LoseWindow>();
    }

    public void OnPromptButtonDown()
    {
        FindObjectOfType<BaseLevel>().OnPromptButtonDown();
    }
}
