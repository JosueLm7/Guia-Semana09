using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    private bool _isOpen = false;

    public void Interact()
    {
        _isOpen = !_isOpen;
        Debug.Log($"Puerta: ahora está {(_isOpen ? "abierta" : "cerrada")}");
    }
}
