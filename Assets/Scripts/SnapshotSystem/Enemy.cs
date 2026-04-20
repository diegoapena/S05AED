using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public Transform target;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void MoveToTarget()
    {
        if (target == null)
        {
            Debug.LogError("El objetivo (target) no está asignado para el enemigo.");
            return;
        }

        // Mover al enemigo hacia el jugador
        transform.position = Vector3.MoveTowards(transform.position, target.position, GameManager.TileValue);
    }
}
