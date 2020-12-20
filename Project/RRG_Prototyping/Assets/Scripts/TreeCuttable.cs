using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace final
{
public class TreeCuttable : Interact
{
    private ToolSwitch toolCheck ;
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.7f;
    [SerializeField] Text text;
    private void Start()
    {
        text.text = "";
    }
    public override void Hit() 
    {
        toolCheck = GameObject.FindGameObjectWithTag("Player").GetComponent<ToolSwitch>(); 
        if(toolCheck.CheckState() == "axe")
        {
            text.text = "";
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
            text.text = "Equip Axe To Break";
            return;
        }
    }
}
}
