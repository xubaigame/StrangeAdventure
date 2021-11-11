// ****************************************************
//     文件：GameRoot.cs
//     作者：积极向上小木木
//     邮箱：positivemumu@126.com
//     日期：#CreateTime#
//     功能：
// *****************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

        ResourcesManager resourcesManager = GetComponent<ResourcesManager>();
        resourcesManager.Init();
        
        CameraManager cameraManager = GetComponent<CameraManager>();
        cameraManager.Init();

        AchievementManager achievementManager = GetComponent<AchievementManager>();
        achievementManager.Init();
        
        
        //判断是否是第一次游戏
        bool firstGame = ResourcesManager.Instance.GetGameConfig().FirstGame;
        if (firstGame)
        {
            UIWindowManager.Instance.OpenWindow<StartCGWindow>();
            ResourcesManager.Instance.GetGameConfig().FirstGame = false;
        }
        else
        {
            UIWindowManager.Instance.OpenWindow<MainMenuWindow>();
        }

        AudioManager audioManager = GetComponent<AudioManager>();
        audioManager.Init();

        LevelManager levelManager = GetComponent<LevelManager>();
        levelManager.Init();
    }

    public void OnDestroy()
    {
        AudioManager.Instance.Destroy();
        AchievementManager.Instance.Destroy();
        LevelManager.Instance.Destroy();
        ResourcesManager.Instance.Destroy();
    }
}
