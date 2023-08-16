using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //Player Movement Variables
    CharacterController rb;
    public int speed;

    void Start()
    {
        rb = GetComponent<CharacterController>(); //Talking to the player rigidbody
    }

    void Update()
    {
        moveMe();
    }

    void moveMe()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        rb.Move(move * speed * Time.deltaTime);
    }
}
