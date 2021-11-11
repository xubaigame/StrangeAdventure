using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FunctionEvent : MonoBehaviour
{
    public UnityEvent OnFunctionCalled;

    public void CallFunction()
    {
        OnFunctionCalled?.Invoke();
    }
}
