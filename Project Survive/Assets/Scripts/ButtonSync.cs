using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class ButtonSync : NetworkBehaviour
{
    public GameObject bodyObject;
    public Color color;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (!base.IsOwner)
        {
            gameObject.GetComponent<ButtonSync>().enabled = false;
        }
    }

    void OnMouseDown() {
        // if (base.IsOwner)
        // {
            ChangeColorServer(color);
            Debug.Log("Button Pressed");
        // }
    }

    [ServerRpc]
    public void ChangeColorServer(Color color)
    {
        ChangeColor(color);
    }
 
    [ObserversRpc]
    public void ChangeColor(Color color)
    {
        bodyObject.GetComponent<Renderer>().material.color = color;
    }
}