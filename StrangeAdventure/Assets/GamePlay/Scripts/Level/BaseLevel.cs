using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLevel : MonoBehaviour
{
   public Transform Player;
   public Collider2D CameraBounds;
   public PromptWindowCommon PromptWindow;
   public int Stage;
   public int Level;
   
   private bool middle;

   public bool Middle
   {
      get => middle;
      set => middle = value;
   }

   public virtual void Init()
   {
      CameraManager.Instance.SetCameraFollowAndLookAt(Player);
      CameraManager.Instance.SetCameraBound(CameraBounds);
      Middle = false;
   }

   public void Destroy()   
   {
      DestroyImmediate(this.gameObject);
   }

   public virtual void GameSucceed()
   {
      LevelManager.Instance.PassLevel();
   }

   public virtual void GameLose()
   {
      LevelManager.Instance.LoseLevel();
   }

   public virtual void SetHeroPosition(bool middle) { }
   
   public void GetFlag()
   {
      Middle = true;
   }

   public void OnPromptButtonDown()
   {
      PromptWindow.gameObject.SetActive(true);
      PromptWindow.OpenWindow();
   }
}
