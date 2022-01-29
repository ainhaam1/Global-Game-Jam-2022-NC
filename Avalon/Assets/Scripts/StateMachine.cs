using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    BaseState currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = getInitialState();
        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            Debug.Log(currentState.name);
            currentState.UpdateLogic();
        }
    }

    private void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdatePhysics();
        }
    }


    public void changeState(BaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    protected virtual BaseState getInitialState()
    {
        return null;
    }

    
}
