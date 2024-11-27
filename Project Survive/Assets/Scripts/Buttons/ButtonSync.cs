using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;
 
public class ButtonSync : NetworkBehaviour
{
    private GameObject body;
    public Color endColor;
    private GameObject buttonSyncObject;
 
    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {
            buttonSyncObject = GameObject.Find("BUTTON (2)");
            body = GameObject.Find("Cube 1");
        }
        else
        {
            GetComponent<ButtonSync>().enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeColorServer(endColor);
        }
    }
    private void OnMouseDown()
    {
       if (gameObject.name == "BUTTON (2)")
       {
            Debug.Log("Button Clicked");
            ChangeColorServer(endColor);
       }
    }
 
    [ServerRpc]
    public void ChangeColorServer(Color color)
    {
        ChangeColor(color);
    }
 
    [ObserversRpc]
    public void ChangeColor(Color color)
    {
        body.GetComponent<Renderer>().material.color = color;
    }
}