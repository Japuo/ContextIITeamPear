using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    public static Player Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null) { Destroy(Instance.gameObject); }
        Instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        #region animation
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            //ANITA: ADD CODE TO SWITCH TO WALKING ANIMATION HERE
        }

        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            //ANITA: ADD CODE TO SWITCH TO IDLE ANIMATION HERE
        }

        #endregion
        Vector2 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement = Vector2.up;
            //ANITA: ADD CODE TO SWITCH DIRECTION TO UP HERE
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement = Vector2.left;
            //ANITA: ADD CODE TO SWITCH DIRECTION TO LEFT HERE
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement = Vector2.down;
            //ANITA: ADD CODE TO SWITCH DIRECTION TO DOWN HERE
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement = Vector2.right;
            //ANITA: ADD CODE TO SWITCH DIRECTION TO RIGHT HERE
        }

        rb.MovePosition(rb.position + movement * moveSpeed);
    }
}
