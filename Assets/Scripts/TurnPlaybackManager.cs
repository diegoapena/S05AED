using System.Collections;
using UnityEngine;

public class TurnPlaybackManager : MonoBehaviour { }

   /* public Player player; // Referencia al jugador
    private CustomDoubleLinkedList snapshotList; // Referencia a la lista de snapshots

    private Coroutine autoPlaybackCoroutine; // Para controlar la reproducción automática

    private void Start()
    {
        // Obtener la lista de snapshots desde el GameManager
        snapshotList = GameManager.instance.snapshots;

        if (snapshotList == null)
        {
            Debug.LogError("La lista de snapshots no está inicializada en el GameManager.");
        }

        if (player == null)
        {
            Debug.LogError("El objeto Player no está asignado en el TurnPlaybackManager.");
        }
    }

    // Inicia la reproducción automática
    public void StartAutoPlayback(float delayBetweenTurns)
    {
        if (autoPlaybackCoroutine == null)
        {
            autoPlaybackCoroutine = StartCoroutine(AutoPlaybackCoroutine(delayBetweenTurns));
        }
    }

    // Detiene la reproducción automática
    public void StopAutoPlayback()
    {
        if (autoPlaybackCoroutine != null)
        {
            StopCoroutine(autoPlaybackCoroutine);
            autoPlaybackCoroutine = null;
        }
    }

    // Corrutina para recorrer los turnos automáticamente
    private IEnumerator AutoPlaybackCoroutine(float delayBetweenTurns)
    {
        while (snapshotList.pointer != null && snapshotList.pointer.Next != null)
        {
            snapshotList.MoveForward(); // Avanza al siguiente turno
            snapshotList.LoadTurn(player); // Carga el estado del turno actual
            yield return new WaitForSeconds(delayBetweenTurns); // Espera antes de avanzar al siguiente turno
        }

        // Finaliza la reproducción automática
        StopAutoPlayback();
    }
}
   */
