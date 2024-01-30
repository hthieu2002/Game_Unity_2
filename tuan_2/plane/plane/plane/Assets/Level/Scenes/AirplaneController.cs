using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 10f;

    void Update()
    {
        
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(0f, 0f, verticalInput);
        Vector3 moveAmount = moveDirection * speed * Time.deltaTime;
        transform.Translate(moveAmount);
    }
}
