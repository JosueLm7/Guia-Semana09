using UnityEngine;

public class TerminalController : MonoBehaviour, IInteractable
{
    [SerializeField] private Light terminalLight; // arrastra aquí la luz
    private bool _isActive = false;

    public void Interact()
    {
        _isActive = !_isActive;

        // cambia el color entre verde y rojo
        terminalLight.color = _isActive ? Color.green : Color.red;

        Debug.Log($"Estado del sistema: {(_isActive ? "Activo" : "Inactivo")}");
    }
}
