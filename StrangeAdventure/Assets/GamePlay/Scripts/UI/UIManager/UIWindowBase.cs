// ****************************************************
//     文件：BaseWindow.cs
//     作者：积极向上小木木
//     邮箱：positivemumu@126.com
//     日期：#CreateTime#
//     功能：
// *****************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIWindowBase : MonoBehaviour
{
    [HideInInspector]
    public UIWindowStates WindowState;

    internal void Open()
    {
        OpenWindow();
        Show();
    }

    internal void Show()
    {
        WindowState = UIWindowStates.Open;
        BeforeShowWindow();
        gameObject.SetActive(true);
        AfterShowWindow();
    }

    internal void Hide()
    {
        BeforeHideWindow();
        gameObject.SetActive(false);
        AfterHideWindow();
        WindowState = UIWindowStates.Hide;
    }

    internal void Close()
    {
        Hide();
        CloseWindow();
        DestroyImmediate(gameObject);
    }

    protected virtual void OpenWindow(){}

    protected virtual void BeforeShowWindow(){}
    
    protected virtual void AfterShowWindow(){}

    protected virtual void BeforeHideWindow(){}
    
    protected virtual void AfterHideWindow(){}

    protected virtual void CloseWindow(){}
}
