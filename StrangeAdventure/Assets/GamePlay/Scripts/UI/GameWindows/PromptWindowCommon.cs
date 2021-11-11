using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PromptWindowCommon : MonoBehaviour
{
    public List<Sprite> PromptSprites;
    public GameObject PromptPrefab;
    public Transform PromptBG;
    public Button NextStageButton;
    public Button PreStageButton;
    public Text CountText;
    
    private int currentIndex;
    private RectTransform[] Prompts;

    public void Awake()
    {
        Prompts = new RectTransform[PromptSprites.Count];
        int i = 0;
        foreach (Sprite sprite in PromptSprites)
        {
            GameObject go = Instantiate(PromptPrefab, PromptBG);
            go.GetComponent<Image>().sprite = sprite;
            Prompts[i]=go.GetComponent<RectTransform>();
            i++;
        }
        currentIndex = 0;
    }

    public void OpenWindow()
    {
        currentIndex = 0;
        for (int i = 0; i < Prompts.Length; i++)
        {
            if (i < currentIndex)
            {
                Prompts[i].anchoredPosition = new Vector2(-Screen.width, 0);
            }
            else if (i > currentIndex)
            {
                Prompts[i].anchoredPosition = new Vector2(Screen.width, 0);
            }
            else
            {
                Prompts[i].anchoredPosition = new Vector2(0, 0);
            }
        }

        if (Prompts.Length == 1)
        {
            NextStageButton.interactable = false;
            NextStageButton.gameObject.SetActive(false);
            PreStageButton.interactable = false;
            PreStageButton.gameObject.SetActive(false);
        }
        else
        {
            PreStageButton.interactable = false;
            Color color = PreStageButton.GetComponent<Image>().color;
            color.a = 0.5f;
            PreStageButton.GetComponent<Image>().color = color;
            NextStageButton.interactable = true;
            color = NextStageButton.GetComponent<Image>().color;
            color.a = 1f;
            NextStageButton.GetComponent<Image>().color = color;
        }

        CountText.text = (currentIndex + 1) + "/" + Prompts.Length;
    }
    
    public void OnPreButtonDown()
    {
        if (currentIndex > 0)
        {
            Prompts[currentIndex].GetComponent<RectTransform>().DOAnchorPosX(Screen.width, 0.2f);
            Prompts[currentIndex - 1].GetComponent<RectTransform>().DOAnchorPosX(0, 0.2f);
            currentIndex--;
        }

        if (currentIndex == 0)
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
        CountText.text = (currentIndex + 1) + "/" + Prompts.Length;
    }
    public void OnNextButtonDown()
    {
        if (currentIndex < Prompts.Length - 1)
        {
            Prompts[currentIndex].GetComponent<RectTransform>().DOAnchorPosX(-Screen.width, 0.2f);
            Prompts[currentIndex + 1].GetComponent<RectTransform>().DOAnchorPosX(0, 0.2f);
            currentIndex++;
        }

        if (currentIndex == Prompts.Length - 1)
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

        CountText.text = (currentIndex + 1) + "/" + Prompts.Length;
    }

    public void OnOkButtonDown()
    {
        gameObject.SetActive(false);
    }
}
