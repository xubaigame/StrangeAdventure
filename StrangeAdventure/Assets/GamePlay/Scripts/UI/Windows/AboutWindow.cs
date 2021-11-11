using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutWindow : UIWindowBase
{
    public void OnBackButtonDown()
    {
        UIWindowManager.Instance.CloseWindow<AboutWindow>(true);
    }
}
