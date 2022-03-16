using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }
    
    public GameObject dialogueBox, cutScene, speakerLeftBox, speakerRightBox;
    public Text dialogueText, speakerLeftNameText, speakerRightNameText;
    public Image speakerLeftSprite, speakerRightSprite, cutSceneSprite;
    public float textSpeed = 4;
    bool isPlayingDialogue;

    private void Awake()
    {
        if(Instance != null) { Destroy(Instance.gameObject); Debug.LogWarning("There were two dialogue managers. The old one has been destroyed."); }
        Instance = this;
    }

    private void Start()
    {
        isPlayingDialogue = false;
    }

    public Coroutine PlayDialogue(DialogueContent dialogue)
    {
        return StartCoroutine(PlayDialogueC(dialogue));
    }

    IEnumerator PlayDialogueC(DialogueContent dialogue)
    {
        if (isPlayingDialogue) { Debug.LogWarning("Tried to start dialogue while dialogue was already playing. Pain.mp3"); yield break; }

        isPlayingDialogue = true;
        Time.timeScale = 0.0f;
        dialogueBox.SetActive(true);

        #region initialization shit

        Color speakerNameColor = speakerLeftNameText.color;

        speakerLeftNameText.text = dialogue.speakerNames[0];
        speakerLeftSprite.sprite = dialogue.speakerSprites[0];
        
        if (dialogue.speakerNames.Length > 1)
        {
            speakerRightNameText.text = dialogue.speakerNames[1];
            speakerRightSprite.sprite = dialogue.speakerSprites[1];
        }

        speakerLeftBox.SetActive(dialogue.showLeftSpeakerBox);
        speakerRightBox.SetActive(dialogue.speakerNames.Length > 1);
        #endregion

        for (int i = 0; i < dialogue.dialogue.Length; i++)
        {
            //Switch to correct speaker and turn on cutscene image if necessary
            #region speaker switching
            if (dialogue.speakers[i] == 0)
            {
                speakerLeftNameText.color = speakerNameColor;
                speakerRightNameText.color = new Color(0.2f,0.2f,0.2f,1);

                speakerLeftSprite.color = Color.white;
                speakerRightSprite.color = new Color(0.2f,0.2f,0.2f,1);
            }
            else
            {
                speakerRightNameText.text = dialogue.speakerNames[dialogue.speakers[i]];
                speakerRightSprite.sprite = dialogue.speakerSprites[dialogue.speakers[i]];
                
                speakerLeftNameText.color = new Color(0.2f,0.2f,0.2f,1); 
                speakerRightNameText.color = speakerNameColor;

                speakerLeftSprite.color = new Color(0.2f,0.2f,0.2f,1);
                speakerRightSprite.color = Color.white; 
            }

            if(dialogue.cutsceneSprites.Length > 0)
            {
                if(dialogue.cutsceneSprites[i] != null)
                {
                    cutScene.SetActive(true);
                    cutSceneSprite.sprite = dialogue.cutsceneSprites[i];
                }
                else
                {
                    cutScene.SetActive(false);
                    cutSceneSprite.sprite = null;
                }
            }
            else
            {
                cutScene.SetActive(false);
            }
            #endregion
            
            yield return null;
            //Loop through dialogue and display letter by letter, skipping it to full if the player presses space
            for (int j = 0; j < dialogue.dialogue[i].Length && !Input.GetKeyDown(KeyCode.Space); j++)
            {
                dialogueText.text = dialogue.dialogue[i].Substring(0, j);
                //yield return new WaitForSecondsRealtime(1 / textSpeed);
                float t = 0;
                while(t < 1/textSpeed && !Input.GetKeyDown(KeyCode.Space))
                {
                    t += Time.unscaledDeltaTime;
                    yield return null;
                }
            }

            dialogueText.text = dialogue.dialogue[i];
            yield return null;


            //Wait until player presses space
            while(!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
            yield return null;
        }

        cutScene.SetActive(false);
        cutSceneSprite.sprite = null;
        speakerLeftNameText.color = speakerNameColor;
        speakerLeftBox.SetActive(true);
        speakerRightBox.SetActive(true);
        dialogueBox.SetActive(false);
        Time.timeScale = 1.0f;
        isPlayingDialogue = false;
    }
}
