using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;

public class PressedToCamera : MonoBehaviour
{

    public Camera firstPersonCamera;
    public Camera overheadCamera;
    
    // public void ShowFirstPersonView() {
    //     firstPersonCamera.enabled = true;
    //     overheadCamera.enabled = false;
    // }
    // public override void OnStartClient()
    // {
    //     base.OnStartClient();
    //     if (!base.IsOwner)
    //     {
    //         GetComponent<PressedToCamera>().enabled = false;
    //     }
        
    // }

    //  private void OnMouseDown()
    // {
    
    //     // GameObject clickedObject = GameObject.Find(hit.transform.name);
    //     // Debug.Log("Clicked object: " + clickedObject.name);
   
    // }

    // public void ShowOverheadView() {
    //     firstPersonCamera.enabled = false;
    //     overheadCamera.enabled = true;
    // }
}
