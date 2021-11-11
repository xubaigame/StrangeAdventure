using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public enum DestroyTypes
    {
        Time,
        Position,
    }

    public DestroyTypes DestroyType;
    public float Second;
    public float YPosition;
    void Start()
    {
        if(DestroyType == DestroyTypes.Time)
            Destroy(gameObject,Second);
    }

    private void Update()
    {
        if (DestroyType == DestroyTypes.Position)
        {
            if (transform.localPosition.y < YPosition)
            {
                DestroyImmediate(gameObject);
            }
        }
    }
}
