using System; // Para la clase "Action"
using UnityEngine; // Para poder usar GameObject

/// <summary>
/// Contenedor estático para los eventos globales del juego
/// Permite una comunicación desacoplada entre diferentes sistemas (Patrón Observer)
/// </summary>
public static class GameEvents
{
    // Evento que se dispara cuando un terminal de objetivo es activado
    public static event Action OnObjectiveActivated;
    public static event Action<GameObject> OnITargetFocused;
    public static event Action<GameObject> OnITargetLost;

    // Método para invocar el evento desde cualquier lugar, de forma segura
    public static void TriggerObjectiveActivated()
    {
        // El '?' comprueba si hay algún suscriptor antes de invocar el evento
        OnObjectiveActivated?.Invoke();
    }

    public static void TriggerITargetFocused(GameObject target)
    {
        OnITargetFocused?.Invoke(target);
    }
    public static void TriggerITargetLost(GameObject target)
    {
        OnITargetLost?.Invoke(target);
    }
}