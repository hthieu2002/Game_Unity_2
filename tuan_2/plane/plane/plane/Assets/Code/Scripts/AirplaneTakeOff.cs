using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    // Elevator: Up / Down
    [SerializeField] private float elevatorUpWard = -18f;

    // Throttle (Speed): Up / Down
    [SerializeField] float throttle = 30f;
    // TODO Ailerons: Left / Right
    // TODOO Rudder

    // takeOffSpeed
    [SerializeField] float takeOffSpeed = 9f;

    // takeOffAccelerate 
    [SerializeField] private float takeOffAccelerate = 1.0072f;

    [SerializeField] private bool isTakeOff = true;
    [SerializeField] private float takeOffElevator = -3.6f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isTakeOff)
        {
            if (takeOffSpeed < throttle)
            {
                takeOffSpeed = takeOffSpeed * takeOffAccelerate;
                transform.Translate(0, 0, takeOffSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(takeOffElevator, 0, 0);
                isTakeOff = false;
            }
        }
        else
        {
            ProcessInput();
            transform.Translate(0f, 0f, throttle * Time.deltaTime);
        }

    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(elevatorUpWard * Time.deltaTime, 0, 0);
            transform.Translate(0f, -(elevatorUpWard * Time.deltaTime), 0);
            Debug.Log("Up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(-(elevatorUpWard * Time.deltaTime), 0, 0);
            transform.Translate(0f, -(elevatorUpWard * Time.deltaTime), 0);
            Debug.Log("Down");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, -(elevatorUpWard * Time.deltaTime));
            transform.Translate(-(elevatorUpWard * Time.deltaTime), 0f, 0);
            Debug.Log("Right");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, (elevatorUpWard * Time.deltaTime));
            transform.Translate((elevatorUpWard * Time.deltaTime), 0f, 0);
            Debug.Log("Right");
        }
    }
}
