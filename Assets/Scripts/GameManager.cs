using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public CustomDoubleLinkedList snapshots;


    public static int TileValue = 2;
    public bool EnablePlayerTurn = true;
    public Action OnPassTurn;
    public SpawnEnemy spawner;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Inicializa snapshots si no está asignado en el inspector
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
            return;
        }

        snapshots.SaveTurn();
        Debug.Log("Turno guardado. Total de turnos: " + snapshots.Count);
    }

    [Button]
    public void LoadTurn()
    {
        if (snapshots == null)
        {
            return;
        }

        snapshots.LoadTurn(player,spawner);
        Debug.Log("Turno cargado.");
    }

    [Button]
    public void NextTurn()
    {
        if (snapshots == null)
        {
            return;
        }

        snapshots.MoveForward();
        LoadTurn();

        // Disparar el evento OnPassTurn
        OnPassTurn?.Invoke();

        Debug.Log("Turno siguiente cargado.");
    }

    [Button]
    public void PrevTurn()
    {
        if (snapshots == null)
        {
            return;
        }

        snapshots.MoveBackwards();
        LoadTurn();

        // Disparar el evento OnPassTurn
        OnPassTurn?.Invoke();

        Debug.Log("Turno anterior cargado.");
    }
}