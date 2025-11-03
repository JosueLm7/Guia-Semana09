using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private float _interactionDistance = 2f;

    private Camera _mainCamera;
    private PlayerInputActions _inputActions;

    private GameObject _currentFocus; // Variable para guardar el objeto enfocado

    private void Awake()
    {
        _mainCamera = Camera.main;
        _inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _inputActions.Player.Enable();
        _inputActions.Player.Interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        _inputActions.Player.Interact.performed -= OnInteract;
        _inputActions.Player.Disable();
    }

    private void Update()
    {
        DetectAndShowFeedback();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        PerformRaycastInteraction();
    }

    private void PerformRaycastInteraction()
    {
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, _interactionDistance))
        {
            // Principio de Inversión de Dependencias
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    private void DetectAndShowFeedback()
    {
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, _interactionDistance))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.GetComponent<IInteractable>() != null)
            {
                SetFocus(hitObject);
                return;
            }
        }
        // Si el raycast no golpea nada interactuable, limpiamos el foco.
        ClearFocus();
    }

    private void SetFocus(GameObject target)
    {
        if (_currentFocus == target) return;
        ClearFocus(); // Limpia el foco anterior si existe
        _currentFocus = target;
        // _currentFocus.GetComponent<OutlineComponent>()?.Apply(); // Descomentar si tienes un componente de Outline
        GameEvents.TriggerITargetFocused(_currentFocus);
    }

    private void ClearFocus()
    {
        if (_currentFocus == null) return;
        // _currentFocus.GetComponent<OutlineComponent>()?.Remove(); // Descomentar si tienes un componente de Outline
        GameEvents.TriggerITargetLost(_currentFocus);
        _currentFocus = null;
    }
}