using System.Collections;
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

    public LayerMask play = 1 << 8;
    public float attackRange = 5f;
    //public Transform attackPoint;
    public int attackDamage = 20;

    private bool attacking;

    bool playerAlive = true;

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
        if (playerAlive) {
            if(Vector3.Distance(player.position, transform.position) <= range && Vector3.Distance(player.position, transform.position) > minRange - .5f)
            {
                FollowPlayer();
            }
        
            //else if(Vector3.Distance(player.position, - transform.position) <= minRange + 3) { Attack(); }
            else if(!(Vector3.Distance(player.position, transform.position) <= range && Vector3.Distance(player.position, transform.position) > minRange - .5f))
            {
                anim.SetBool("Moving", false);
            }

            if (attack) {
                attack = false;
                Invoke("Attack", 0.5f);
            }
        }
    }

    public void FollowPlayer()
    {
        anim.SetBool("Moving", true);
        anim.SetFloat("DirX", (player.transform.position - transform.position).x);
        anim.SetFloat("DirY", (player.transform.position - transform.position).y);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed *Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            attacking = true;
            attack = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            attacking = false;
        }
    }

    void Attack()
    { 
            //anim.SetTrigger("attack");
            if(attacking) {
                player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                if (player.GetComponent<PlayerHealth>().CheckHealth() > 0) {
                    Invoke("Attack", 0.5f);
                }
                else {
                    playerAlive = false;
                    attacking = false;
                }
            }

            /* Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, play);

            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            } */
    }
}