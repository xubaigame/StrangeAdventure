using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public CinemachineConfiner2D cinemachineConfiner;
    private Camera camera;

    public void Init()
    {
        Instance = this;
        camera = Camera.main;
    }

    public void SetCameraBound(Collider2D bounds)
    {
        cinemachineConfiner.m_BoundingShape2D = bounds;
    }

    public void SetCameraFollowAndLookAt(Transform target)
    {
        cinemachineVirtualCamera.Follow = target.transform;
        cinemachineVirtualCamera.LookAt = target.transform;
    }
    
}
