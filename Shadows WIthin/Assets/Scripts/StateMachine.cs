using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class StateMachine : MonoBehaviour
{
    Dictionary<Type, State> _availableStates;
    State _currentState;
    public void Initialize(Dictionary<Type, State> states)
    {
        _availableStates = states;
        if (_currentState == null)
        {
            _currentState = states.Values.First();
        }
        
    }

    private void Update()
    {

        _currentState?.Tick();
    }

    void SwitchState(State nextState)
    {
        _currentState.Exit();
        _currentState = nextState;
        _currentState.Enter();
    }
}
