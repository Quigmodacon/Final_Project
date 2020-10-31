using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace final
{
    public class PlayerShooting : MonoBehaviour
    {
        ToolSwitch toolCheck;
        [SerializeField] GameObject bullet;
        
        
        private void Awake() 
        {
            toolCheck = GameObject.FindGameObjectWithTag("Player").GetComponent<ToolSwitch>();
        }
        private void Update() 
        {
            Vector3 player = gameObject.transform.position;
            if(toolCheck.CheckState() == "gun" && Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, player, transform.rotation);
            }
            else if(toolCheck.CheckState() != "gun" && Input.GetMouseButtonDown(0))
            {
                Debug.Log("Press Tab to Switch to gun");
            }  
        }
    }
}
