using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public float speed = 5;
    public float maxX = 7.5f;
    float movementHorizontal;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        if ((movementHorizontal>0&& transform.position.x < maxX) || (movementHorizontal<0 && transform.position.x > maxX))
        {
            transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime;
        }
        
    }
}
