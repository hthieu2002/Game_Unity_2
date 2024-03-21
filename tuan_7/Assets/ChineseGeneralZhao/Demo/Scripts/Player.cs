namespace ChineseCharacter
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Player : MonoBehaviour
    {

        Animator animator;
        float H, V;
        Vector2 movement;
        public float speed = 5f;
        void Start()
        {
            animator = GetComponent<Animator>();
        }


        void Update()
        {
            H = Input.GetAxis("Horizontal");
            V = Input.GetAxis("Vertical");
            movement.x = H;
            movement.y = V;
            FaceMove();
            Move();
            Attack();
        }

        void FaceMove()
        {
            animator.SetFloat("H", movement.x);
            animator.SetFloat("V", movement.y);
            Debug.Log("Move:" + movement.sqrMagnitude);
            animator.SetFloat("walk", movement.sqrMagnitude);
        }
        void Move()
        {
            Vector3 move = new Vector3(H, V);
            transform.position += move * speed * Time.deltaTime;
        }
        void Attack()
        {

        }
    }
}
