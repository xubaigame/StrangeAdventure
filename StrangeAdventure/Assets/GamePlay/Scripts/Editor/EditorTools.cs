using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class EditorTools : Editor
{
    [MenuItem("EditorTools/DeleteAllPlayerPrefs")]
    public static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("删除成功！");
    }

    [MenuItem("EditorTools/DeletePersistentDataPath")]
    public static void DeletePersistentDataPath()
    {
        if (Directory.Exists(Application.persistentDataPath))
        {
            Directory.Delete(Application.persistentDataPath,true);
        }
        Debug.Log("删除成功！");
    }
    
    [MenuItem("EditorTools/ShowPersistentDataPath")]
    public static void ShowPersistentDataPath()
    {
        Debug.Log(Application.persistentDataPath);
    }
}
