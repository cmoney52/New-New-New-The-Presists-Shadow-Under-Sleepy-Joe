using UnityEngine;
using System.Collections;
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
        IEnumerator wait()
        {
            yield return new WaitForSeconds(5); // Wait for 3 seconds
        }
    private void SwitchState(State nextState) 
    {
        if (stateObjects.transform.Find(currentState.name).name == "Attack")
        {
            StartCoroutine(wait());
        }
        stateObjects.transform.Find(currentState.name).gameObject.SetActive(false);
        stateObjects.transform.Find(nextState.name).gameObject.SetActive(true);
        currentState = nextState;
    }
}
