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

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (!base.IsOwner)
        {
            GetComponent<ButtonPressed>().enabled = false;
        }
        
    }

    private void OnMouseDown()
    {
        if (base.IsOwner)
        {
            StartCountdownServer(this);
        }
        else
        {
            StartCountdownServer(this);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    public void StartCountdownServer(ButtonPressed script)
    {
        script.countdownStarted = true;
        StartCoroutine(StartCountdown(this));
    }

    private IEnumerator StartCountdown(ButtonPressed script)
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;
        }

        if (timer <= 0)
        {
            script.countdownStarted = false;
        }
    }
}
