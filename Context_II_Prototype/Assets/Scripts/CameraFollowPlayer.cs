using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public float distance = 350.0f;
    Vector2 player_prev_position;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Player.Instance.transform.position + (Vector3.back * 10);
    }

    private void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(Player.Instance.transform.position);

        if(screenPos.x < distance || screenPos.x > 1280-distance || screenPos.y < distance || screenPos.y > 720 - distance)
        {
            Vector2 delta_position;
            delta_position = (Vector2)Player.Instance.transform.position - player_prev_position;
            transform.Translate(delta_position);
        }
        player_prev_position = (Vector2)Player.Instance.transform.position;
    }

}
