using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


    public class TopDownCharacterController : MonoBehaviour
    {
    [SerializeField] private float speed = 5f;
    private AgentAnimations agentAnimations;
        private AgentMover agentMover;
        private WeaponParent weaponParent;
    private Rigidbody2D rb;

        [SerializeField]
        private InputActionReference movement, attack, pointerPosition;

        private Vector2 pointerInput, movementInput, movements;

    private Animator animator;


        private void Update()
        {
            pointerInput = GetPointerInput();
            movementInput = movement.action.ReadValue<Vector2>().normalized;

            agentMover.MovementInput = movementInput;
        }


        private Vector2 GetPointerInput()
        {
            Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
            mousePos.z = Camera.main.nearClipPlane;
            return Camera.main.ScreenToWorldPoint(mousePos);
        }

        
        private void Awake()
        {
            agentAnimations = GetComponentInChildren<AgentAnimations>();
            weaponParent = GetComponentInChildren<WeaponParent>();
            agentMover = GetComponent<AgentMover>();

            animator = GetComponent<Animator>();
        }

        private void OnMovement(InputValue value)
    {
        movements = value.Get<Vector2>();

        if(movements.x != 0 || movements.y != 0)
        {
            animator.SetFloat("X", movements.x);
            animator.SetFloat ("Y", movements.y);
        }
  
    }
        
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movements * speed * Time.fixedDeltaTime);
    }
        

    }