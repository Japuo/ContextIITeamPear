using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueEvent : MonoBehaviour
{
    public int dialogueIndex;
    public UnityEvent onDialogueCompleted, onDialogueStarted;

    public void InvokeStartEvent()
    {
        onDialogueStarted.Invoke();
    }

    public void InvokeEndEvent()
    {
        onDialogueCompleted.Invoke();
    }
}
