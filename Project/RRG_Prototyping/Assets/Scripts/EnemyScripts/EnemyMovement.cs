﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Animator anim;
    [SerializeField] private float speed = 5f;
    //Rigidbody2D rb;
    private Transform player;
    [SerializeField] float range = 2f;
    [SerializeField] float minRange = 1f;
    public Transform homeSpot;
    private bool attack;

    public LayerMask play;
    public float attackRange;
    //public Transform attackPoint;
    public int attackDamage = 20;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position, transform.position) <= range && Vector3.Distance(player.position, transform.position) > minRange - .5f)
        {
            FollowPlayer();
        }
    
        //else if(Vector3.Distance(player.position, - transform.position) <= minRange + 3) { Attack(); }
         else if(!(Vector3.Distance(player.position, transform.position) <= range && Vector3.Distance(player.position, transform.position) > minRange - .5f))
        {
            anim.SetBool("Moving", false);
        }
    }
    public void FollowPlayer()
    {
        anim.SetBool("Moving", true);
        anim.SetFloat("DirX", (player.transform.position - transform.position).x);
        anim.SetFloat("DirY", (player.transform.position - transform.position).y);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed *Time.deltaTime);
    }
    
    /* public void Attack()
    { 
            //anim.SetTrigger("attack");
            

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, play);

            foreach(Collider2D enemy in hitEnemies)
            {
                //enemy.GetComponent<PlayHealth>().TakeDamage(attackDamage);
            }
    } */
}