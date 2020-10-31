using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace final
{
    public class BulletScript : MonoBehaviour
    {
        CharacterController2D character;
        private float time = 0;
        private Vector2 dir;
        private void Awake() 
        {
            character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
            Debug.Log("bang");
            dir = character.CheckDir();
        }
        private void Update() 
        {
            time += Time.deltaTime;
            if(time >= 3){Destroy(gameObject);}
        }
       
    }
}
