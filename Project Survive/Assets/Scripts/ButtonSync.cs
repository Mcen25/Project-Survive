using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class ButtonSync : NetworkBehaviour
{
    public bool isPressed = false;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {
            isPressed = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        // if (base.IsOwner)
        // {
        //     isPressed = !isPressed;
        // }
        Debug.Log("Button Pressed");
    }
}
