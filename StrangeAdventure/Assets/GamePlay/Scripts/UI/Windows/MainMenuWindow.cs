using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : UIWindowBase
{
    public Image HerFaceTitle;
    public Image HerFace;
    public Button RightKey;

    public List<Sprite> HerFaceSprite;
    protected override void AfterShowWindow()
    {
        StartCoroutine(HerFaceAnimation());
        isLock = !AchievementManager.Instance.isAchievementUnlocked(31);
    }
    
    IEnumerator HerFaceAnimation()
    {
        int index = 0;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            ++index;
            if (index >= 3)
            {
                index = 0;
            }
            
            HerFace.sprite = HerFaceSprite[index];
        }
    }

    protected override void AfterHideWindow()
    {
        StopCoroutine(HerFaceAnimation());
    }

    public void OnStartButtonDown()
    {
        UIWindowManager.Instance.OpenWindow<StageSelectWindow>();
        UIWindowManager.Instance.CloseWindow<MainMenuWindow>();
    }

    public void OnOptionButtonDown()
    {
        UIWindowManager.Instance.OpenWindow<OptionWindow>();
    }

    public void OnAboutButtonDown()
    {
        UIWindowManager.Instance.OpenWindow<AboutWindow>();
    }

    public void OnAchievementButtonDown()
    {
        UIWindowManager.Instance.OpenWindow<AchievementWindow>();
    }

    public void OnOtherGameButtonDown()
    {
        //todo 提示功能开发中
    }

    public void OnRateUsButtonDown()
    {
        //TODO 提示功能开发中
    }

    private int count = 1;
    private bool isLock;
    public void OnHerFaceClicked()
    {
        HerFace.sprite = HerFaceSprite[2];
        if (isLock)
        {
            if (count < 5)
            {
                count++;
                StartCoroutine(ReduceCount());
            }
            else
            {
                StopCoroutine(ReduceCount());
                AchievementManager.Instance.UnlockAchievement(31);
                isLock = !AchievementManager.Instance.isAchievementUnlocked(31);
            }
        }
    }
    
    IEnumerator ReduceCount()
    {
        yield return new WaitForSeconds(1);
        if (count > 0)
            count--;
    }

    public void OnRightKeyButtonDown()
    {
        
    }
}
