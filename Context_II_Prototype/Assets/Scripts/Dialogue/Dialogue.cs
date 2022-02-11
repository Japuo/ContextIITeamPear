using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public DialogueContent[] dialogues;
    public GameObject dialogueIcon;

    Dictionary<int,DialogueEvent> dialogueEvents;
    public int currentDialogue;
    bool isPlayerInRange;

    private void Start()
    {
        dialogueEvents = new Dictionary<int, DialogueEvent>();
        isPlayerInRange = false;

        foreach(DialogueEvent de in GetComponents<DialogueEvent>())
        {
            dialogueEvents.Add(de.dialogueIndex, de);
        }

        #region wow tests
        //Check to see if dialogues are valid
        foreach (DialogueContent dc in dialogues)
        {
            //If the arrays aren't the same size, raise an error
            if (dc.dialogue.Length != dc.speakers.Length || (dc.dialogue.Length != dc.cutsceneSprites.Length && dc.cutsceneSprites.Length > 0)
                || dc.speakerNames.Length != dc.speakerSprites.Length)
            {
                throw new System.ArgumentException("Dialogue " + dc.name + " has incorrect formatting: Arrays are not the right size.");
            }

            //If there's a speaker in the speakers list that doesn't exist, yeet an error
            for (int i = 0; i < dc.speakers.Length; i++)
            {
                if (dc.speakers[i] < 0 || dc.speakers[i] >= dc.speakerNames.Length)
                {
                    throw new System.ArgumentException("Dialogue " + dc.name + " has incorrect formatting: Speakers out of bounds");
                }
            }            
        }
        #endregion
    }

    private void Update()
    {
        if(isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.Space) && currentDialogue >= 0 && currentDialogue < dialogues.Length)
            {
                PlayDialogue(currentDialogue);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && currentDialogue >= 0 && currentDialogue < dialogues.Length)
        {
            dialogueIcon.SetActive(true);
            isPlayerInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueIcon.SetActive(false);
            isPlayerInRange = false;
        }
    }

    public void SetCharacterDialogue(int dialogueIndex)
    {
        currentDialogue = dialogueIndex;
    }

    public Coroutine PlayDialogue(int index)
    {
        return StartCoroutine(PlayDialogueC(index));
    }

    public void PlayDialogueFromEvent(int index)
    {
        StartCoroutine(PlayDialogueC(index));
    }

    IEnumerator PlayDialogueC(int index)
    {
        Collider2D col = GetComponentInChildren<Collider2D>();
        if(col != null) { col.enabled = false; }
        yield return DialogueManager.Instance.PlayDialogue(dialogues[index]);
        if(dialogueEvents.ContainsKey(index))
        {
            dialogueEvents[index].InvokeEvent();
        }
        if (col != null) { col.enabled = true; }
    }
}
