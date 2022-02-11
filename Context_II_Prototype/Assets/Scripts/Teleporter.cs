using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter target;
    public Transform spawnPoint;

    public void Teleport()
    {
        StartCoroutine(TeleportC());
    }

    IEnumerator TeleportC()
    {
        yield return GameManager.Instance.FadeIn(Color.clear, Color.black);
        yield return new WaitForSeconds(0.25f);
        Player.Instance.transform.position = target.spawnPoint.position;
        yield return new WaitForSeconds(0.25f);
        yield return GameManager.Instance.FadeOut(Color.black, Color.clear);
    }

    
}
