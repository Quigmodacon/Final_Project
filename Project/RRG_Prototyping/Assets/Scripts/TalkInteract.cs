using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace final
{
    public class TalkInteract : Interactable 
    {
        public override void Interact(Character character)
        {
            Debug.Log("You talked with me. YAY!");
        }
    }   
}
