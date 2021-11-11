using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWindowCommon : MonoBehaviour
{
    public Image muteImage;
    public BaseLevel Level;
    public void OnBackButtonDown()
    {
        LevelManager.Instance.CurrentIQ = 250;
        UIWindowManager.Instance.OpenWindow<StageSelectWindow>();
        Level.Destroy();
    }

    public void OnMuteButtonDown()
    {
        if (AudioManager.Instance.MuteBG != AudioManager.Instance.MuteEffect)
        {
            AudioManager.Instance.MuteBG = true;
            AudioManager.Instance.MuteEffect = true;
        }
        else
        {
            AudioManager.Instance.MuteBG = !AudioManager.Instance.MuteBG;
            AudioManager.Instance.MuteEffect = !AudioManager.Instance.MuteEffect;
        }
        if (AudioManager.Instance.MuteBG)
        {
            Color color = muteImage.color;
            color.a = 1;
            muteImage.color = color;
        }
        else
        {
            Color color = muteImage.color;
            color.a = 0;
            muteImage.color = color;
        }
    }
    
    void Start()
    {
        if (!AudioManager.Instance.MuteBG || !AudioManager.Instance.MuteEffect) 
        {
            Color color = muteImage.color;
            color.a = 0;
            muteImage.color = color;
        }
    }
}
