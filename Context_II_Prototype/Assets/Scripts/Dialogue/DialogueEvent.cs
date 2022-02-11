using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueEvent : MonoBehaviour
{
    public int dialogueIndex;
    public UnityEvent onDialogueCompleted;

    public void InvokeEvent()
    {
        onDialogueCompleted.Invoke();
    }
}
