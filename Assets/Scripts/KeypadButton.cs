using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : MonoBehaviour
//Any scripts that are attached to object in program must inherit from monobehavior
//Applying script to prefab then propogates out the script to all object created from the prefab

{
    public int ButtonNumber;
    

    public Keypad Keypad;


    public void OnButtonClick()
    {
        Keypad.RegisterButtonClick(ButtonNumber);
        //Tell keypad that the button was clicked and tell it the buttons value

        //print("Clicked:" + ButtonNumber);
    }
}
