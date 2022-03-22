using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class YesNoBoxEvent : MonoBehaviour
{
    public UnityEvent yesEvents, noEvents;
    [TextArea]
    public string text;

    public void Activate()
    {
        YesNoBox.Instance.ActivateYesNo(text, yesEvents, noEvents);
    }
}
