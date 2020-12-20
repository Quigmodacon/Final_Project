using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] Item spell;
    [SerializeField] Image icon;
    [SerializeField] Text text;

    int myIndex;
   

    public void SetIndex(int index) 
    {
        myIndex = index;
    }

    public void Set(ItemSlot slot)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;

        if (slot.item.stackable == true)
        {
            text.gameObject.SetActive(true);
            text.text = slot.count.ToString();
        }
        else
        {
            text.gameObject.SetActive(false);
        } 
    }

    public void Clean() 
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);

        text.gameObject.SetActive(false);
    }

    public void Craft()
    {//statement to check if the item and if more
        if(GameManager.instance.inventoryContainer.slots[myIndex].item.name =="CorruptShard" 
        && GameManager.instance.inventoryContainer.slots[myIndex].count >= 5 ) 
        {
            GameManager.instance.inventoryContainer.slots[myIndex].count -= 5;
            GameManager.instance.inventoryContainer .Add(spell, 1);
        }
    }   
}
