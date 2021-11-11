using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using DG.Tweening;
using LitJson;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance = null;
    [FormerlySerializedAs("AchievementLable")] public RectTransform AchievementLabel;
    public Text AchievementTitle;
    public Text AchievementDes;
    public void Init()
    {
        Instance = this;
        achievements = new Dictionary<int, Achievement>();
        List<Achievement> tempAchievements = ResourcesManager.Instance.LoadAchievement();
        unlockCount = 0;
        for (int i = 0; i < tempAchievements.Count; i++)
        {
            if (tempAchievements[i].unlock)
                unlockCount++;
            achievements.Add(tempAchievements[i].id,tempAchievements[i]);
        }
    }

    private int unlockCount;
    private Dictionary<int, Achievement> achievements;

    public List<Achievement> GetAchievements()
    {
        return achievements.Values.ToList();
    }

    public void UnlockAchievement(int id)
    {
        if (achievements.ContainsKey(id))
        {
            achievements[id].unlock = true;
            unlockCount++;
            AchievementTitle.text = "获得成就：" + achievements[id].name;
            AchievementDes.text = achievements[id].description;
            AchievementLabel.DOAnchorPosY(-AchievementLabel.sizeDelta.y / 2, 0.2f);
            StartCoroutine(ResetAchievementLabel());
            CheckAchievement(unlockCount);
        }
    }

    IEnumerator ResetAchievementLabel()
    {
        yield return new WaitForSeconds(5);
        AchievementLabel.DOAnchorPosY(AchievementLabel.sizeDelta.y / 2, 0.2f);
    }

    public bool isAchievementUnlocked(int id)
    {
        if (achievements.ContainsKey(id))
        {
            return achievements[id].unlock;
        }
        else
        {
            return true;
        }
    }
    
    public void CheckAchievement(int unlockCount)
    {
        if (unlockCount == 30)
        {
            UnlockAchievement(32);
        }
    }

    public int UnLockedCount()
    {
        return unlockCount;
    }

    public void Destroy()
    {
        ResourcesManager.Instance.SaveAchievement(AchievementManager.Instance.GetAchievements());
    }
}
