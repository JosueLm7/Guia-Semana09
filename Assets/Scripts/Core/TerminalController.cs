using UnityEngine;

public class TerminalController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Interact()
    {
        Debug.Log("Terminal activado. Disparando evento OnObjetiveActivated.");
        GameEvents.TriggerObjectiveActivated();
    }

}
