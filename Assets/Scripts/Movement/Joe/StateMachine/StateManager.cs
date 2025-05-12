using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currentState;
     void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchState(nextState);
        }
    }

    private void SwitchState(State nextState) 
    {
        currentState = nextState;
    }
}
