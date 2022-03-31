using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public UnityEvent startEvents;

    private void Start()
    {
        startEvents.Invoke();
    }
}
