using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
// using FishNet.Object.Synchronizing;

public class Lever : NetworkBehaviour
{

    [SerializeField] private GameObject body;
    [SerializeField] private GameObject leverSyncObject;
    [SerializeField] private GameObject leverSyncEmptyObject;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {
            leverSyncEmptyObject.SetActive(false);
            leverSyncObject = GameObject.Find("BUTTON (2)");
            body = GameObject.Find("Cube 1");
        }
        else
        {
            GetComponent<ButtonSync>().enabled = false;
        }
    }

    void Update()
    {
        
    }

    private void OnMouseDown() {
        //Update animation

        //play sound // remember to use mixer!

        //Update server
        LeverActivatedServer();
    }

    [ServerRpc]
    public void LeverActivatedServer() {
        LeverActivated();
    }

    [ObserversRpc]
    public void LeverActivated() {

    }

    [ServerRpc]
    public void LeverDeactivatedServer() {

    }

    [ObserversRpc]
    public void LeverDeactivated() {

    }

    public void PlaySound() {
        //Use sfx mixer
    }

    // public bool IsActivated() {
    //     return true;
    // }
    
    private void StartAnimation() {

    }
}