using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public bool TopCollider = false;
    public UnityEvent OnTrigger;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (TopCollider)
            {
                if (col.GetComponent<Rigidbody2D>().velocity.y > 0)
                {
                    OnTrigger?.Invoke();
                }
            }
            else
            {
                OnTrigger?.Invoke();
            }
            
        }
        
    }
}
