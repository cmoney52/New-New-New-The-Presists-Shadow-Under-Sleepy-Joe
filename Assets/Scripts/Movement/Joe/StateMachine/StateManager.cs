using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class StateManager : MonoBehaviour
{
    public State currentState;
    public GameObject stateObjects;
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
        stateObjects.transform.Find(currentState.name).gameObject.SetActive(false);
        stateObjects.transform.Find(nextState.name).gameObject.SetActive(true);
        currentState = nextState;
    }
}
