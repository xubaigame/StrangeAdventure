using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : MonoBehaviour
{
    public Image Icon;
    public Text Level;
    public Text Name;
    public Text Des;
    public GameObject Check;

    public void InitItem(Achievement achievement)
    {
        Icon.sprite = ResourcesManager.Instance.LoadSprite("Achievement/" + achievement.spritePath);
        Level.text = achievement.level;
        Name.text = achievement.name;
        Des.text = achievement.description;
        Check.SetActive(achievement.unlock);
        if (!achievement.unlock)
        {
            Color color = GetComponent<Image>().color;
            color.a = 40 / 255f;
            GetComponent<Image>().color = color;
            Image[] images = GetComponentsInChildren<Image>();
            foreach (var image in images)
            {
                color = image.color;
                color.a = 40 / 255f;
                image.color = color;
            }
            Text[] texts = GetComponentsInChildren<Text>();
            foreach (var text in texts)
            {
                color = text.color;
                color.a = 40 / 255f;
                text.color = color;
            }
        }
    }
}
