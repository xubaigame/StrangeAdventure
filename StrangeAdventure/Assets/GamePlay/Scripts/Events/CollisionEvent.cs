using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    public UnityEvent OnCollision;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Player")
            OnCollision?.Invoke();                                                                                                                                                                                                          
    }
}