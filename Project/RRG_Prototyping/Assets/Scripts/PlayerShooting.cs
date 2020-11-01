using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace final
{
    public class PlayerShooting : MonoBehaviour
    {
        ToolSwitch toolCheck;
        [SerializeField] GameObject bullet;
        CharacterController2D direction;
        [SerializeField] float speed =3;
        private void Awake() 
        {
            toolCheck = GameObject.FindGameObjectWithTag("Player").GetComponent<ToolSwitch>();
            direction = gameObject.GetComponent<CharacterController2D>();
        }
        private void Update() 
        {
            
            Vector3 player = gameObject.transform.position;
            if(toolCheck.CheckState() == "gun" && Input.GetMouseButtonDown(0))
            {
                Shoot();
                
            }
            else if(toolCheck.CheckState() != "gun" && Input.GetMouseButtonDown(0))
            {
                Debug.Log("Press Tab to Switch to gun");
            }  
        }
        private void Shoot()
        {
            Vector3 shootDirection;
            shootDirection = Input.mousePosition;
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection = shootDirection-transform.position;
            //Vector2 dir = direction.CheckDir().normalized;
            GameObject arrow = Instantiate(bullet, transform.position, transform.rotation);
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
            arrow.transform.Rotate(0f,0f, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg);
            Destroy(arrow, 2.0f);
            
        }
    }
}
