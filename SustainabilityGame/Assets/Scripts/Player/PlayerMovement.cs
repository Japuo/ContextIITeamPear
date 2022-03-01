using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0, 100)]
    public int movementSpeed;

    private Rigidbody2D playerRb;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        movementSpeed *= 100; //play with movementspeed, mass and linear drag of the rigidbody to finetune the player's "slipperiness"
    }

    void FixedUpdate()
    {
        Vector2 AxisInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerRb.AddForce(AxisInput * movementSpeed, ForceMode2D.Force);
    }
}
