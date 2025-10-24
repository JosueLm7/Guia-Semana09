using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private float _interactionDistance = 3f;
    private Camera _camera;
    private PlayerInputActions _input;

    private void Awake()
    {
        _camera = Camera.main;
        _input = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _input.Player.Enable();
        _input.Player.Interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        _input.Player.Disable();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, _interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}
