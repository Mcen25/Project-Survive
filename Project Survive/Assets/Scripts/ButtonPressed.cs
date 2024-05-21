using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using System.Threading;
using Unity.VisualScripting;

public class ButtonPressed : NetworkBehaviour
{
    private float timer = 10f;
    [SyncVar] public bool countdownStarted = false;

    // private void OnMouseDown()
    // {
    //     StartCountdownServer();
    // }

      private void Update()
    {
        Debug.Log(countdownStarted);
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCountdownServer(this);
        }
    }

    [ServerRpc]
    public void StartCountdownServer(ButtonPressed script)
    {
        Debug.Log("Countdown started");
        script.countdownStarted = true;
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
