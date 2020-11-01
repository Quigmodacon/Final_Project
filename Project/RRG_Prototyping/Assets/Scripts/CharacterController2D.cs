using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace final{
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 2.0f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;

    public bool moving;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = motionVector * speed;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(
            horizontal,
            vertical
            );

        anim.SetFloat("horizontal", horizontal);
        anim.SetFloat("vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        anim.SetBool("moving", moving);


        if (horizontal != 0 || vertical != 0)

        {
            lastMotionVector = new Vector2(
            horizontal,
            vertical
            ).normalized;

            anim.SetFloat("lastHorizontal", horizontal);
            anim.SetFloat("lastVertical", vertical);


        }

    }
    public Vector2 CheckDir(){return lastMotionVector;}
}
}
