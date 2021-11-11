using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectWindow : UIWindowBase
{
    public List<GameObject> Stages;
    public Button NextStageButton;
    public Button PreStageButton;
    private int currentStage;
    protected override void BeforeShowWindow()
    {
        int passedStage = LevelManager.Instance.PassedStage - 1;
        int passedLevel = LevelManager.Instance.PassedLevel - 1;
        currentStage = LevelManager.Instance.FocusStage;
        for (int i = 0; i < Stages.Count; i++)
        {
            if (i < passedStage)
            {
                Button[] levels = Stages[i].GetComponentsInChildren<Button>();
                foreach (var level in levels)
                {
                    level.interactable = true;
                }

                
            }
            else if(i == passedStage)
            {
                Button[] levels = Stages[i].GetComponentsInChildren<Button>();
                for (int j = 0; j < levels.Length; j++)
                {
                    if (j <= passedLevel)
                    {
                        levels[j].interactable = true;
                    }
                    else
                    {
                        levels[j].interactable = false;
                        levels[j].transform.GetChild(0).gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                Button[] levels = Stages[i].GetComponentsInChildren<Button>();
                foreach (var level in levels)
                {
                    level.interactable = false;
                    level.transform.GetChild(0).gameObject.SetActive(false);
                }
                
            }

            if (i < currentStage)
            {
                Stages[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-Screen.width, 0);
            }
            else if(i == currentStage)
            {
                Stages[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            }
            else
            {
                Stages[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width, 0);
            }
        }
        
        if (currentStage == 6)
        {
            NextStageButton.interactable = false;
            Color color = NextStageButton.GetComponent<Image>().color;
            color.a = 0.5f;
            NextStageButton.GetComponent<Image>().color = color;
        }
        if (currentStage == 0)
        {
            PreStageButton.interactable = false;
            Color color = PreStageButton.GetComponent<Image>().color;
            color.a = 0.5f;
            PreStageButton.GetComponent<Image>().color = color;
        }
    }

    protected override void BeforeHideWindow()
    {
        LevelManager.Instance.FocusStage = currentStage;
    }

    public void OnNextStageButtonDown()
    {
        if (currentStage < 6)
        {
            Stages[currentStage].GetComponent<RectTransform>().DOAnchorPosX(-Screen.width, 0.2f);
            Stages[currentStage + 1].GetComponent<RectTransform>().DOAnchorPosX(0, 0.2f);
            currentStage++;
        }

        if (currentStage == 6)
        {
            NextStageButton.interactable = false;
            Color color = NextStageButton.GetComponent<Image>().color;
            color.a = 0.5f;
            NextStageButton.GetComponent<Image>().color = color;
        }

        if (PreStageButton.interactable == false)
        {
            PreStageButton.interactable = true;
            Color color = PreStageButton.GetComponent<Image>().color;
            color.a = 1f;
            PreStageButton.GetComponent<Image>().color = color;
        }
    }

    public void OnPreStageButtonDown()
    {
        if (currentStage > 0)
        {
            Stages[currentStage].GetComponent<RectTransform>().DOAnchorPosX(Screen.width, 0.2f);
            Stages[currentStage - 1].GetComponent<RectTransform>().DOAnchorPosX(0, 0.2f);
            currentStage--;
        }

        if (currentStage == 0)
        {
            PreStageButton.interactable = false;
            Color color = PreStageButton.GetComponent<Image>().color;
            color.a = 0.5f;
            PreStageButton.GetComponent<Image>().color = color;
        }
        
        if (NextStageButton.interactable == false)
        {
            NextStageButton.interactable = true;
            Color color = NextStageButton.GetComponent<Image>().color;
            color.a = 1f;
            NextStageButton.GetComponent<Image>().color = color;
        }
    }

    public void OnBackButtonDown()
    {
        UIWindowManager.Instance.OpenWindow<MainMenuWindow>();
        UIWindowManager.Instance.CloseWindow<StageSelectWindow>();
    }
}
