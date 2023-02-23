using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBroadcaster : MonoBehaviour
{
    public bool IsTapPressed { get; private set; } = false;
    //TODO add other input events here

    private void Update()
    {
        //Note: Put your Input/Detection here. This code
        //is just for simple example and does not account
        //for new Input System setup.
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsTapPressed = true; 
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            IsTapPressed = false;
        }
    }
}
