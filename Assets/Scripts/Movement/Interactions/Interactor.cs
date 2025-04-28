using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


interface IInteractable{
    UnityEvent onInteract { get; set; }

    public void Interact();
}
public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;
    private PlayerInput _playerInput;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.actions["Interact"].performed += DoInteract;
        Debug.Log("Subscribed to Interact action.");
    }

    private void OnDisable()
    {
        _playerInput.actions["Interact"].performed -= DoInteract;
    }

    private void DoInteract(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("Interact action triggered!");
        // add Raycasts
        if (!Physics.Raycast(_transform.position + (Vector3.up) + (_transform.forward * 0.2f), transform.forward, out var hit, 1.5f, interactableLayer)) return;

        if (!hit.transform.TryGetComponent(out InteractableObject interactable)) return;
        interactable.Interact();
    }
}
