﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickupDistance = 1.5f;
    [SerializeField] float ttl = 10f;

    public int count = 1;
    public Item item;


    private void Start()
    {
        player = GameManager.instance.player.transform;
    }
    private void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl < 0) { Destroy(gameObject); }


        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > pickupDistance) { return; }

        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position, 
            speed * Time.deltaTime
            );
        if (distance < 0.1) 
        {
            if (GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count);

            }
            else 
            {
                Debug.LogWarning("no inventory container attached to the game manager");

            }
            Destroy(gameObject); 
        }
    }

}
