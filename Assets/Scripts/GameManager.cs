using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public CustomDoubleLinkedList snapshots;

    public List<Transform> entities; // Asigna tus entidades en el inspector

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

        snapshots.LoadTurn(player);
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
        Debug.Log("Turno anterior cargado.");
    }
}