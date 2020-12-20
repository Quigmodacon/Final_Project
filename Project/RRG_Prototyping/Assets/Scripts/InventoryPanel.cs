using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] ItemContainer inventory;
    [SerializeField] List<InventoryButton> buttons;

    private void Start()
    {
        Show();
        SetIndex();
    }

    private void FixedUpdate()
    {
        Show();
    }
    private void SetIndex()
    {
        for (int i = 0; i < inventory.slots.Count; i++) 
        {
            buttons[i].SetIndex(i);
        }
    }

    private void Show()
    {
        for (int i = 0; i < inventory.slots.Count; i++) 
        {
            if (inventory.slots[i].item == null)
            {
                buttons[i].Clean();
            }
            else 
            {
                buttons[i].Set(inventory.slots[i]);
            }
            if(inventory.slots[i].count == 0 
            && inventory.slots[i].item.stackable) { buttons[i].Clean(); }
        }
    }
    public void SubtractItem(int index, int number) 
    {
        inventory.slots[index].count -= number;
    }

    
    public Item GetItem(int index) { return inventory.slots[index].item; }
    public int GetCount(int index) { return inventory.slots[index].count; }
}
