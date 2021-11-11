using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WinWindow : UIWindowBase
{
    private Vector2 anchoredPosition;
    protected override void OpenWindow()
    {
        anchoredPosition = transform.GetChild(0).transform.GetComponent<RectTransform>().anchoredPosition;
    }

    protected override void BeforeShowWindow()
    {
        transform.GetChild(0).transform.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
    }
    protected override void AfterShowWindow()
    {
        transform.GetChild(0).GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.5f).SetEase(Ease.Linear);
    }

    public void OnNextLevelButtonDown()
    {
        DestroyImmediate(FindObjectOfType<BaseLevel>().gameObject);
        LevelManager.Instance.LoadLevel(LevelManager.Instance.CurrentStage,LevelManager.Instance.CurrentLevel,false);
        UIWindowManager.Instance.CloseWindow<WinWindow>();
    }
    
    
}
