using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int Stage;
    public int Level;

    public void OnLevelButtonDown()
    {
        LevelManager.Instance.CurrentStage = Stage;
        LevelManager.Instance.CurrentLevel = Level;
        LevelManager.Instance.LoadLevel(Stage,Level,false);
        UIWindowManager.Instance.CloseWindow<StageSelectWindow>();
    }
}
