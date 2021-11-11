using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black : MonoBehaviour
{
    private Animation animation;

    private bool played;
    void Start()
    {
        animation = GetComponent<Animation>();
        played = false;
    }

    public void PlayAnimation()
    {
        if (!played)
        {
            animation.Play();
            played = true;
        }
    }

    
}
