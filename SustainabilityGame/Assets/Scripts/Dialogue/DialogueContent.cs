using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueContent", menuName = "ScriptableObjects/DialogueContent")]
public class DialogueContent : ScriptableObject
{
    public string[] speakerNames = new string[] { "Aniti", "Character" };
    public Sprite[] speakerSprites;

    [TextArea]
    public string[] dialogue;
    public int[] speakers;    
    public Sprite[] cutsceneSprites;

    public bool showLeftSpeakerBox = true;
}
