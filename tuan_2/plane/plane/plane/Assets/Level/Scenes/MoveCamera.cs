using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float moveSpeed = 5f;

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Mouse X");
        float verticalMovement = Input.GetAxis("Mouse Y");
        Vector3 moveDirection = new Vector3(horizontalMovement, 0f, verticalMovement);
        Vector3 planeNormal = Vector3.up;
        Vector3 moveDirectionOnPlane = Vector3.ProjectOnPlane(moveDirection, planeNormal);
        transform.Translate(moveDirectionOnPlane * moveSpeed * Time.deltaTime);
    }
}
