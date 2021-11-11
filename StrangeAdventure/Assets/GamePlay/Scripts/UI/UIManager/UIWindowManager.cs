// ****************************************************
//     文件：UIWindowManager.cs
//     作者：积极向上小木木
//     邮箱：positivemumu@126.com
//     日期：#CreateTime#
//     功能：
// *****************************************************

using System;
using System.Collections.Generic;
using UnityEngine;

public class UIWindowManager : MonoBehaviour
{
    private static UIWindowManager instance;

    public static UIWindowManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = GameObject.Find("ScriptsHolder");
                if (go == null)
                {
                    go = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
                    go.name = "ScriptsHolder";
                    instance = go.AddComponent<UIWindowManager>();
                }
                else
                {
                    instance = go.GetComponent<UIWindowManager>();
                }

                instance.cachedWindows = new Dictionary<Type, UIWindowBase>();
            }

            return instance;
        }
    }
    
    public Canvas windowCanvas;
    public List<GameObject> windows;

    private Dictionary<Type, UIWindowBase> cachedWindows;

    public void OpenWindow<T>()
    {
        OpenWindow(typeof(T));
    }
    
    public void OpenWindow(Type windowType)
    {
        UIWindowBase window = GetWindowByType(windowType);

        if (window == null)
        {
            window = CreateWindow(windowType);
            cachedWindows.Add(window.GetType(),window);
            window.Open();
        }
        else
        {
            if (window.WindowState == UIWindowStates.Open)
            {
                Debug.LogError(windowType.Name+"窗口已经打开！");
                return;
            }
            window.Show();
        }
        SetWindowAsFocusWindow(window.GetType());
    }

    public void CloseWindow<T>(bool destroyWindow = false)
    {
        CloseWindow(typeof(T), destroyWindow);
    }

    public void CloseWindow(Type windowType, bool destroyWindow = false)
    {
        UIWindowBase window = GetWindowByType(windowType);
        if (window != null)
        {
            if(window.WindowState == UIWindowStates.Hide)
            {
                Debug.LogError(windowType.Name+"窗口已经关闭！");
                return;
            }
            
            if (destroyWindow)
            {
                window.Close();
                cachedWindows.Remove(windowType);
            }
            else
            {
                window.Hide();
            }
        }
        else
        {
            Debug.LogError(windowType.Name+"没有被加载，无法关闭！");
        }
    }

    public void CloseAllWindow(bool destroyAllWindow = false)
    {
        foreach (var VARIABLE in cachedWindows)
        {
            VARIABLE.Value.Hide();
            if (destroyAllWindow)
            {
                VARIABLE.Value.Close();
            }
        }
        if (destroyAllWindow)
        {
            cachedWindows.Clear();
        }
    }

    public UIWindowBase CreateWindow(Type windowType)
    {
        GameObject prefab = GetGameObjectWithName(windowType.Name);
        GameObject window = Instantiate(prefab, windowCanvas.transform);
        window.name = windowType.Name;
        UIWindowBase prefabsWindowBase = window.GetComponent<UIWindowBase>();
        return prefabsWindowBase;
    }

    private GameObject GetGameObjectWithName(string windowName)
    {
        foreach (GameObject window in windows)
        {
            if (window.name == windowName)
            {
                return window;
            }
        }

        return null;
    }

    private UIWindowBase GetWindowByType(Type windowType)
    {
        if (cachedWindows.ContainsKey(windowType))
        {
            return cachedWindows[windowType];
        }

        return null;
    }

    public void SetWindowAsFocusWindow(Type windowType)
    {
        if (cachedWindows.ContainsKey(windowType))
        {
            SetWindowAsLastWindow(cachedWindows[windowType]);
        }
    }

    private void SetWindowAsLastWindow(UIWindowBase uiWindowBase)
    {
        uiWindowBase.GetComponent<RectTransform>().SetSiblingIndex(windowCanvas.transform.GetChild(0).childCount - 1);
    }
}