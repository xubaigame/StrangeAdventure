using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AchievementWindow : UIWindowBase
{
    public Transform Context;
    public GameObject AchievementGameObject;
    public Text unlockedCount;
    private List<Achievement> achievements;
    protected override void OpenWindow()
    {
        achievements = AchievementManager.Instance.GetAchievements();
    }

    #region 检查"成就"成就是否解锁
    private int count = 1;
    private bool isLock;
    
    public void OnTitleButtonDown()
    {
        if (isLock)
        {
            if (count < 2)
            {
                count++;
                StartCoroutine(ReduceCount());
            }
            else
            {
                StopCoroutine(ReduceCount());
                AchievementManager.Instance.UnlockAchievement(32);
                BeforeHideWindow();
                BeforeShowWindow();
            }
        }
    }
    #endregion
    

    IEnumerator ReduceCount()
    {
        yield return new WaitForSeconds(1);
        if (count > 0)
            count--;
    }

    protected override void BeforeShowWindow()
    {
        UpdateWindow();
    }

    public void UpdateWindow()
    {
        for (int i = Context.childCount-1; i >=0 ; i--)
        {
            DestroyImmediate(Context.GetChild(i).gameObject);
        }

        achievements = achievements.OrderBy(a => a.id).OrderByDescending(a => a.unlock).ToList();
        for (int i = 0; i < achievements.Count; i++)
        {
            Instantiate(AchievementGameObject, Context).GetComponent<AchievementItem>().InitItem(achievements[i]);
        }

        unlockedCount.text = AchievementManager.Instance.UnLockedCount() +"/32";
        isLock = !AchievementManager.Instance.isAchievementUnlocked(32);
    }

    protected override void CloseWindow()
    {
        achievements = null;
    }

    public void OnBackButtonDown()
    {
        UIWindowManager.Instance.CloseWindow<AchievementWindow>();
    }
}
