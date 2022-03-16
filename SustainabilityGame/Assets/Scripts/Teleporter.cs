using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    //Teleport player to my location
    public void Teleport()
    {
        FindObjectOfType<PlayerMovement>().transform.position = transform.position; //Dit moet mooi ofzo
        //ToDo: Camera goed mee teleporteren
    }
}
