// ****************************************************
//     文件：StartCGWindow.cs
//     作者：积极向上小木木
//     邮箱：positivemumu@126.com
//     日期：#CreateTime#
//     功能：
// *****************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class StartCGWindow : UIWindowBase
{
    public Image MuteButton;
    public Sprite MuteOn;
    public Sprite MuteOff;
    
    public TimelineBehaviour startCG;
    private AudioSource audioSource;
    private bool mute = false;
    public void OnSkipButtonDown()
    {
        startCG.StopTimeline();
        UIWindowManager.Instance.OpenWindow<MainMenuWindow>();
        UIWindowManager.Instance.CloseWindow<StartCGWindow>(true);
    }
    
    public void OnMuteBGButtonDown()
    {
        mute = !mute;
        audioSource.mute = mute;
        if (mute)
        {
            MuteButton.sprite = MuteOn;
        }
        else
        {
            MuteButton.sprite = MuteOff;
        }
    }

    public void StartCGFinished()
    {
        UIWindowManager.Instance.OpenWindow<MainMenuWindow>();
        UIWindowManager.Instance.CloseWindow<StartCGWindow>(true);
    }

    protected override void BeforeShowWindow()
    {
        startCG.StartTimeline();
        MuteButton.sprite = MuteOff;
        audioSource = GetComponent<AudioSource>();
    }

}
