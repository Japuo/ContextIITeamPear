using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera myCamera = null;
    [SerializeField] private CinemachineVirtualCamera myCineMachine = null;
    [SerializeField] private GameObject followPointer = null;

    [SerializeField] private GameObject player = null;

    Vector3 mousePosition = new Vector3();
    Vector3 followPointerPosition = new Vector3();
    void Update()
    {
        mousePosition = myCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        followPointerPosition = (mousePosition + player.transform.position) / 2; //midpoint calculation
        followPointerPosition = (followPointerPosition + player.transform.position) / 2; //quarterpoint calculation
        followPointer.transform.position = followPointerPosition;

    }
}
