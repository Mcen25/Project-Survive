using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class ChangeScreen : NetworkBehaviour
{
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;

    private Color body;
  
    void Start()
    {
        body = GetComponent<Renderer>().material.color;
    }
    void Update()
    {
        if (button1.GetComponent<ButtonPressed>().countdownStarted == true && button2.GetComponent<ButtonPressed>().countdownStarted == true)
        {

            ChangeScreenColorServer(Color.green);
        }      
    }

    [ServerRpc(RequireOwnership = false)]
    public void ChangeScreenColorServer(Color color)
    {
        ChangeScreenColor(color);
    }

    [ObserversRpc]
    public void ChangeScreenColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
}
