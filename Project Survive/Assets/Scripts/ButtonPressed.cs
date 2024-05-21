using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using System.Threading;

public class ButtonPressed : NetworkBehaviour
{
    [SyncVar] public float timer = 10f;

    private void OnMouseDown()
    {
        Debug.Log("Button pressed");
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (timer > 0)
        {
            Debug.Log(timer);
            yield return new WaitForSeconds(1f);
            timer--;
        }
    }
}
