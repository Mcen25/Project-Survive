using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>> ();

    protected BaseState<EState> CurrentState;

    protected bool IsTransitioning = false;

    void Start() {
        CurrentState.EnterState();
    }

    void Update() {
        EState nextStateKey = CurrentState.GetNextState();

        if (nextStateKey.Equals(CurrentState.StateKey)) {
            CurrentState.UpdateState();
        } else {
            TransitionToState(nextStateKey);
        }
    }

    public void TransitionToState(EState nextStateKey) {
        IsTransitioning = true;
        CurrentState.ExitState();
        CurrentState = States[nextStateKey];
        CurrentState.EnterState();
        IsTransitioning = false;
    }

    void OnTriggerEnter() {
        CurrentState.OnTriggerEnter();
    }

    void OnTriggerStay() {
        CurrentState.OnTriggerStay();
    }

    void OnTriggerExit() {
    }
}
