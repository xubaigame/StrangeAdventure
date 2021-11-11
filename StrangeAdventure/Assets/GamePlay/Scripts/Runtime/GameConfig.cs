using UnityEngine;

public class GameConfig
{
    private bool firstGame;
    private bool muteBG;
    private bool muteEffect;
    private int passedStage;
    private int passedLevel;
    public bool FirstGame
    {
        get => firstGame;
        set => firstGame = value;
    }
    public bool MuteBg
    {
        get => muteBG;
        set => muteBG = value;
    }

    public bool MuteEffect
    {
        get => muteEffect;
        set => muteEffect = value;
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

    public void LoadConfig()
    {
        firstGame = true;
        if (PlayerPrefs.HasKey("FirstGame"))
        {
            firstGame = PlayerPrefs.GetInt("FirstGame") == 1;
        }

        muteBG = false;
        if (PlayerPrefs.HasKey("MuteBG"))
        {
            muteBG = PlayerPrefs.GetInt("MuteBG") == 1;
        }
        
        muteEffect = false;
        if (PlayerPrefs.HasKey("MuteEffect"))
        {
            muteEffect = PlayerPrefs.GetInt("MuteEffect") == 1;
        }

        passedStage = 1;
        if (PlayerPrefs.HasKey("PassedStage"))
        {
            passedStage = PlayerPrefs.GetInt("PassedStage");
        }

        passedLevel = 1;
        if (PlayerPrefs.HasKey("PassedLevel"))
        {
            passedLevel = PlayerPrefs.GetInt("PassedLevel");
        }
    }

    public void SaveConfig()
    {
        PlayerPrefs.SetInt("FirstGame",firstGame?1:0);
        PlayerPrefs.SetInt("MuteBG",muteBG?1:0);
        PlayerPrefs.SetInt("MuteEffect",muteEffect?1:0);
        PlayerPrefs.SetInt("PassedStage",passedStage);
        PlayerPrefs.SetInt("PassedLevel",passedLevel);
    }
}
