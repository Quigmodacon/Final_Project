using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace final{

public class ToolsCharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController2D character;
    Rigidbody2D rb;

    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    private void Awake()
    {
        character = GetComponent<CharacterController2D>();

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 position = rb.position + character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders) 
        {
            Interact hit = c.GetComponent<Interact>();
            if (hit != null) 
            {
                hit.Hit();
                break;
            }
        }
        
    }
}
}