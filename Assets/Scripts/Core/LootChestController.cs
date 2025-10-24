using UnityEngine;

public class LootChestController : MonoBehaviour, IInteractable
{
    private bool _isOpened = false;

    public void Interact()
    {
        if (!_isOpened)
        {
            _isOpened = true;
            Debug.Log("Has encontrado un tesoro!");
        }
        else
        {
            Debug.Log("El cofre ya está abierto.");
        }
    }
}
