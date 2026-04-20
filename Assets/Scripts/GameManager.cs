using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public Enemy enemy; // Referencia al enemigo en la escena
    public CustomDoubleLinkedList snapshots;
    public static int TileValue = 2;
    public bool EnablePlayerTurn = true;
    public Action OnPassTurn;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (snapshots == null)
        {
            snapshots = new CustomDoubleLinkedList();
        }
    }

    [Button]
    public void SaveTurn()
    {
        if (snapshots == null)
        {
            Debug.LogError("Snapshots no está inicializado.");
            return;
        }

        snapshots.SaveTurn();
        Debug.Log("Turno guardado. Total de turnos: " + snapshots.Count);

        // Deshabilitar el turno del jugador
        EnablePlayerTurn = false;
    }

    [Button]
    public void MoveEnemy()
    {
        if (enemy == null)
        {
            Debug.LogError("El enemigo no está asignado en GameManager.");
            return;
        }

        // Mover al enemigo hacia el jugador
        enemy.MoveToTarget();

        // Habilitar el turno del jugador nuevamente
        EnablePlayerTurn = true;
    }

    [Button]
    public void LoadTurn()
    {
        if (snapshots == null)
        {
            Debug.LogError("Snapshots no está inicializado.");
            return;
        }

        snapshots.LoadTurn(player);
        Debug.Log("Turno cargado.");
    }

    [Button]
    public void NextTurn()
    {
        if (snapshots == null)
        {
            Debug.LogError("Snapshots no está inicializado.");
            return;
        }

        snapshots.MoveForward();
        LoadTurn();
        Debug.Log("Turno siguiente cargado.");
    }

    [Button]
    public void PrevTurn()
    {
        if (snapshots == null)
        {
            Debug.LogError("Snapshots no está inicializado.");
            return;
        }

        snapshots.MoveBackwards();
        LoadTurn();
        Debug.Log("Turno anterior cargado.");
    }
}