using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager Instance;
    private GameConfig gameConfig;
    public void Init()
    {
        Instance = this;
        gameConfig = new GameConfig();
        gameConfig.LoadConfig();
        if (gameConfig.FirstGame)
        {
            LoadAchievementFile();
        }
    }
    public GameConfig GetGameConfig()
    {
        return gameConfig;
    }
    
    private void SaveGameConfig()
    {
        gameConfig.SaveConfig();
    }

    public Sprite LoadSprite(string pathWithFileName)
    {
        return Resources.Load<Sprite>(pathWithFileName);
    }

    public void LoadAchievementFile()
    {
        if (File.Exists(Application.persistentDataPath + "/achievements"))
        {
            File.Delete(Application.persistentDataPath + "/achievements");
        }
        
        File.Copy(Application.streamingAssetsPath+"/achievements",Application.persistentDataPath + "/achievements");
    }
    
    public List<Achievement> LoadAchievement()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(Application.persistentDataPath+"/achievements",FileMode.Open))
        {
            return (List<Achievement>)binaryFormatter.Deserialize(fileStream);
        }
    }

    public GameObject LoadLevel(string pathWithFileName)
    {
        return Resources.Load<GameObject>(pathWithFileName);
    }
    
    public void SaveAchievement(List<Achievement> achievements)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(Application.persistentDataPath+"/achievements",FileMode.Create))
        {
            binaryFormatter.Serialize(fileStream,achievements);
        }
    }
    
    public void Destroy()
    {
        SaveGameConfig();
    }
}