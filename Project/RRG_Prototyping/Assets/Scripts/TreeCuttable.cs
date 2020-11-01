using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace final
{
public class TreeCuttable : Interact
{
    private ToolSwitch toolCheck ;
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.7f;
    public override void Hit() 
    {
        toolCheck = GameObject.FindGameObjectWithTag("Player").GetComponent<ToolSwitch>(); 
        if(toolCheck.CheckState() == "axe")
        {
            while (dropCount > 0) 
            {
                dropCount--;
                Vector3 position = transform.position;
                position.x += spread * UnityEngine.Random.value - spread / 2;
                position.y += spread * UnityEngine.Random.value - spread / 2;
                GameObject go = Instantiate(pickUpDrop);
                go.transform.position = position;
            }
                Destroy(gameObject); 
            
        }
        else if(toolCheck.CheckState() != "axe")
        {
            Debug.Log("Press Tab to Switch to Axe");
            return;
        }
    }
}
}
