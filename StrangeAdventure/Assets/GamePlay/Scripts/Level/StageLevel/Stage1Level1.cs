using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Stage1Level1 : BaseLevel
{
    public Image TimeBG;
    public Text Time;
    public GameObject Flag;
    public FunctionEvent WallMissiles;
    public HeroController Hero;
    public Vector3 StartPosition;
    public Vector3 MiddlePosition;
    
    private int count;
    private bool showDieTime;
    public override void Init()
    {
        base.Init();
        count = 0;
        showDieTime = false;
    }

    public void AddCount()
    {
        count++;
        if (count >= 5 && !showDieTime)
        {
            ShowDieTime();
        }
    }

    public void ShowDieTime()
    {
        TimeBG.gameObject.SetActive(true);
        StartCoroutine(Timer(Time));
    }

    IEnumerator Timer(Text time)
    {
        time.text = "3";
        time.transform.DOScale(new Vector3(0, 0, 0), 1f);
        yield return new WaitForSeconds(1);
        time.rectTransform.localScale = Vector3.one;
        time.text = "2";
        time.transform.DOScale(new Vector3(0, 0, 0), 1f);
        yield return new WaitForSeconds(1);
        time.rectTransform.localScale = Vector3.one;
        time.text = "1";
        time.transform.DOScale(new Vector3(0, 0, 0), 1f);
        yield return new WaitForSeconds(1);
        TimeBG.gameObject.SetActive(false);
        WallMissiles.CallFunction();
    }
    
    public void GetKey()
    {
        if (!AchievementManager.Instance.isAchievementUnlocked(1))
        {
            AchievementManager.Instance.UnlockAchievement(1);
        }
    }

    public override void GameSucceed()
    {
        Hero.DisableControl();
        base.GameSucceed();
        UIWindowManager.Instance.OpenWindow<WinWindow>();
    }

    public override void GameLose()
    {
        Hero.DisableControl();
        base.GameLose();
        Hero.DieAnimation();
        UIWindowManager.Instance.OpenWindow<LoseWindow>();
    }

    public override void SetHeroPosition(bool middle)
    {
        Middle = middle;
        if (!middle)
        {
            Hero.transform.position = StartPosition;
        }
        else
        {
            Flag.SetActive(false);
            Hero.transform.position = MiddlePosition;
        }
    }
}
