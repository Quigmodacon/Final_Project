using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace final
{
    public class ToolSwitch : MonoBehaviour
    {
        [SerializeField] Text toolIdentify;
        private string[] toolList;
        private int index;
        private int size = 3;
        private string activeItem;

        private void Awake() 
        {  
            toolList = new string[size];
            toolList[0] = "axe";
            toolList[1] = "gun";
            toolList[2] = "empty";

            activeItem = toolList[2];
            index = 2;

            toolIdentify.text = activeItem;
        }

        private void Update() 
        {
            if(Input.GetKeyDown("tab"))
            {
                if(index == 2)
                {
                    index = 0;
                    activeItem = toolList[index];
                    toolIdentify.text = activeItem;
                }
                else if(index != 2)
                {
                    index++;
                    activeItem = toolList[index];
                    toolIdentify.text = activeItem;

                }
            }
        }

        public string CheckState(){return activeItem;}
    }
}