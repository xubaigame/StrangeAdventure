using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsBehavior : MonoBehaviour
{

    public List<GameObject> WillShowOjects;
    public void ShowObject()
    {
        foreach (var WillShowOject in WillShowOjects)
        {
            WillShowOject.SetActive(true);
        }
        
    }
    
    public List<GameObject> WillHideObjects;
    public void HideObject()
    {
        foreach (var WillHideObject in WillHideObjects)
        {
            WillHideObject.SetActive(false);
        }
    }

    public Rigidbody2D FallRigidbody2D;

    public void FallGameObject()
    {
        FallRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        FallRigidbody2D.freezeRotation = true;
        FallRigidbody2D.gravityScale = 0;
        FallRigidbody2D.AddForce(new Vector2(0, -150));
    }
    
    public Rigidbody2D UpRigidbody2D;

    public void UpGameObject()
    {
        UpRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        UpRigidbody2D.freezeRotation = true;
        UpRigidbody2D.gravityScale = 0;
        UpRigidbody2D.AddForce(new Vector2(0, 200));
    }
    
    public Rigidbody2D LeftRigidbody2D;

    public void LeftGameObject()
    {
        LeftRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        LeftRigidbody2D.freezeRotation = true;
        LeftRigidbody2D.gravityScale = 0;
        LeftRigidbody2D.AddForce(new Vector2(-100, 0));
    }
    
    public Rigidbody2D RightRigidbody2D;

    public void RightGameObject()
    {
        RightRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        RightRigidbody2D.freezeRotation = true;
        RightRigidbody2D.gravityScale = 0;
        RightRigidbody2D.AddForce(new Vector2(100, 0));
    }
    
    public Rigidbody2D DisableRigidbody2D;
    public void DisableRigidbody()
    {
        DisableRigidbody2D.bodyType = RigidbodyType2D.Static;
    }
}
