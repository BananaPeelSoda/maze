using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //we put information at the start of a class
    public int health = 100;
    public float speed = 4.5f;
    public string hero = "Jenso";
    public bool isAlive = true;
    // Start is called before the first frame update


    //xyz coordination
    public Vector3 direction;
    public Rigidbody playerRb;



    void Start()
    {
        Debug.Log("My name is " + hero);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(direction * Time.deltaTime * speed);



        playerRb.linearVelocity = direction * speed;
    }


    private void OnMove(InputValue value)
    {

        //ask the input system what keys are being pressed
        Vector2 inputValue = value.Get<Vector2>();
        direction = new Vector3(
            inputValue.x,
            0,
            inputValue.y
        );
    }


}    