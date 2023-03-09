using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;

    void Start()
   {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        
        rb.velocity = new Vector3(xMove, yMove, 0) * speed;

        if (rb.velocity.x == 0 && rb.velocity.y == 0)
            animator.SetBool("walking", false);
        else
            animator.SetBool("walking", true);
    }
}
