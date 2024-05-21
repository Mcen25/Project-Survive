using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class ButtonSync : NetworkBehaviour
{
    public GameObject targetObject; // The object that will change color
    public Color color; // The color to change to

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {
            
        } else {
            gameObject.GetComponent<ButtonSync>().enabled = false;
        }
    }

    void OnMouseDown() 
    {
        // if (base.IsOwner) // Only the owner can change the color
        // {
            ChangeColorServerRpc(color);
            Debug.Log("Button Pressed");
        // }
    }

    [ServerRpc]
    public void ChangeColorServerRpc(Color color)
    {
        ChangeColorObserversRpc(color);
    }
 
    [ObserversRpc]
    public void ChangeColorObserversRpc(Color color)
    {
        targetObject.GetComponent<Renderer>().material.color = color;
    }
}