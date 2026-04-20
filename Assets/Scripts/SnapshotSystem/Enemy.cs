using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
   public Transform target;

    public void Start()
    {
        GameManager.instance.OnPassTurn += MoveToTarget;
    }
    public void Update()
    {
            
    }

    public void Set(Transform target, Vector3 position)
    {
        this.target = target;
        transform.position = position;
    }
    public void MoveToTarget()
    {
        if (target == null)
        {
            Debug.LogError("El objetivo (target) no está asignado para el enemigo.");
            return;
        }

        // Obtener el siguiente paso hacia el jugador
        Vector3 targetPosition = GetCloseStep();

        // Mover al enemigo hacia la posición objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, GameManager.TileValue);
    }
    public Vector3 GetCloseStep()
    {
        Vector3 currentPosition = transform.position;

        // Posiciones posibles (arriba, abajo, izquierda, derecha)
        Vector3[] possiblePositions = new Vector3[]
        {
            target.position + new Vector3(GameManager.TileValue, 0, 0),  // Derecha
            target.position + new Vector3(-GameManager.TileValue, 0, 0), // Izquierda
            target.position + new Vector3(0, 0, GameManager.TileValue),  // Arriba
            target.position + new Vector3(0, 0, -GameManager.TileValue)  // Abajo
        };

        // Encontrar la posición más cercana
        Vector3 closestPosition = possiblePositions[0];
        float closestDistance = Vector3.Distance(currentPosition, closestPosition);

        foreach (var pos in possiblePositions)
        {
            float distance = Vector3.Distance(currentPosition, pos);
            if (distance < closestDistance)
            {
                closestPosition = pos;
                closestDistance = distance;
            }
        }

        return closestPosition;
    }
}
