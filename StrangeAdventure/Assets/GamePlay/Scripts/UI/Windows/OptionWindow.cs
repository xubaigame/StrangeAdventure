using UnityEngine;
using UnityEngine.UI;

public class OptionWindow : UIWindowBase
{
    public Image MuteBG;
    public Image MuteEffect;

    protected override void BeforeShowWindow()
    {
        Color color = MuteBG.color;
        if (AudioManager.Instance.MuteBG)
        {
            color.a = 1f;
        }
        else
        {
            color.a = 0f;
        }
        MuteBG.color = color;

        color = MuteEffect.color;
        if (AudioManager.Instance.MuteEffect)
        {
            color.a = 1f;
        }
        else
        {
            color.a = 0f;
        }

        MuteEffect.color = color;

    }

    public void OnMuteBGButtonDown()
    {
        AudioManager.Instance.MuteBG = !AudioManager.Instance.MuteBG;
        Color color = MuteBG.color;
        if (AudioManager.Instance.MuteBG)
        {
            color.a = 1f;
        }
        else
        {
            color.a = 0f;
        }
        MuteBG.color = color;
    }

    public void OnMuteEffectButtonDown()
    {
        AudioManager.Instance.MuteEffect = !AudioManager.Instance.MuteEffect;
        Color color = MuteEffect.color;
        if (AudioManager.Instance.MuteEffect)
        {
            color.a = 1f;
        }
        else
        {
            color.a = 0f;
        }

        MuteEffect.color = color;
    }

    public void OnBackButtonDown()
    {
        UIWindowManager.Instance.CloseWindow<OptionWindow>();
    }
}
