using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public void TeleportPlayer(GameObject target)
    {
        player.transform.position = target.transform.position;
    }
}
