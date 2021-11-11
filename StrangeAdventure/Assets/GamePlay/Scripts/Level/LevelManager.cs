using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public static LevelManager Instance;
    private int passedStage;
    private int passedLevel;
    private int focusStage;
    private int currentStage;
    private int currentLevel;
    private int currentIQ;

    public int CurrentIQ
    {
        get => currentIQ;
        set => currentIQ = value;
    }

    public int PassedStage
    {
        get => passedStage;
        set => passedStage = value;
    }

    public int PassedLevel
    {
        get => passedLevel;
        set => passedLevel = value;
    }
    
    public int CurrentStage
    {
        get => currentStage;
        set => currentStage = value;
    }

    public int CurrentLevel
    {
        get => currentLevel;
        set => currentLevel = value;
    }
    public int FocusStage
    {
        get => focusStage;
        set => focusStage = value;
    }
    public void Init()
    {
        Instance = this;
        PassedStage = ResourcesManager.Instance.GetGameConfig().PassedStage;
        PassedLevel = ResourcesManager.Instance.GetGameConfig().PassedLevel;
        focusStage = 0;
        CurrentIQ = 250;
    }

    public void LoadLevel(int stageIndex, int levelIndex, bool middle)
    {
        GameObject go = ResourcesManager.Instance.LoadLevel("Level/Stage" + stageIndex + "Level" + levelIndex);
        BaseLevel level = Instantiate(go).GetComponent<BaseLevel>();
        level.Init();
        level.SetHeroPosition(middle);
    }

    public void PassLevel()
    {
        if (CurrentIQ == 250 && !AchievementManager.Instance.isAchievementUnlocked(29))
        {
            AchievementManager.Instance.UnlockAchievement(29);
        }
        CurrentIQ = 250;
        CurrentLevel++;
        if (CurrentLevel > 6)
        {
            if (CurrentStage < 6)
            {
                CurrentStage++;
                CurrentLevel = 1;
            }
            else
            {
                CurrentLevel = 6;
            }
        }

        if (CurrentStage == PassedStage&&CurrentLevel > PassedLevel)
        {
            PassedLevel = CurrentLevel;
        }

        if (CurrentStage > PassedStage)
        {
            PassedStage = CurrentStage;
            PassedLevel = CurrentLevel;
        }
    }

    public void LoseLevel()
    {
        CurrentIQ -= 50;
        if (CurrentIQ < 0 && !AchievementManager.Instance.isAchievementUnlocked(30))
        {
            AchievementManager.Instance.UnlockAchievement(30);
        }
    }

    public void Destroy()
    {
        ResourcesManager.Instance.GetGameConfig().PassedStage = PassedStage;
        ResourcesManager.Instance.GetGameConfig().PassedLevel = PassedLevel;
    }
    
    
}
