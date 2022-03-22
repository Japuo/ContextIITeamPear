using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class YesNoBox : MonoBehaviour
{
    public Text text;
    public static YesNoBox Instance { get; private set; }
    public UnityEvent yesEvents, noEvents;

    private void Awake()
    {
        if(Instance != null) { Destroy(Instance.gameObject); Debug.LogWarning("There was already an instance of a Yes/No box, so I destroyed it >:)"); }
        Instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void PressYes()
    {
        yesEvents.Invoke();
        gameObject.SetActive(false);
    }

    public void PressNo()
    {
        noEvents.Invoke();
        gameObject.SetActive(false);
    }

    public void ActivateYesNo(string _text, UnityEvent _yesEvents, UnityEvent _noEvents)
    {
        text.text = _text;
        yesEvents = _yesEvents;
        noEvents = _noEvents;
        gameObject.SetActive(true);
    }
}
