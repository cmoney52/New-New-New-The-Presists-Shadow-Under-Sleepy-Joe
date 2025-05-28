using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class StateManager : MonoBehaviour
{
    public State currentState;
    public GameObject stateObjects;
    public 
     void Update()
    {
        if (!SunriseSimulation.IsDaytime)
        {
            RunStateMachine();
        }
        else {
            transform.position = new Vector3(445,14,430);
        }
        
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
