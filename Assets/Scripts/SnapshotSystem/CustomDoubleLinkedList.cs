using UnityEngine;
using Sirenix.OdinInspector;

public class CustomDoubleLinkedList : DoubleLinkedList<SnapshotNode>
{
    public Node<SnapshotNode> pointer;

    public void SaveTurn()
    {
        if (pointer != tail)
        {
            RemoveFromPosition(pointer.Next);
        }

        SnapshotNode snapshot = new SnapshotNode(GameManager.instance.player, Count);
        base.Add(snapshot);
        ResetPointer();
    }

    public void ResetPointer()
    {
        pointer = tail;
    }

    public void MoveBackwards()
    {
        MoveBackwardsRecursive(pointer);
    }

    private void MoveBackwardsRecursive(Node<SnapshotNode> current)
    {
        if (current == null || current.Prev == null) return; // Caso base: no hay nodo previo

        pointer = current.Prev; // Mover el puntero al nodo previo
        Debug.Log($"Retrocediendo al turno: {pointer.Value.Turn}");
    }

    public void MoveForward()
    {
        MoveForwardRecursive(pointer);
    }

    private void MoveForwardRecursive(Node<SnapshotNode> current)
    {
        if (current == null || current.Next == null) return; // Caso base: no hay nodo siguiente

        pointer = current.Next; // Mover el puntero al nodo siguiente
        Debug.Log($"Avanzando al turno: {pointer.Value.Turn}");
    }

    public void LoadTurn(Player player)
    {
        LoadTurnRecursive(pointer, player);
    }

    private void LoadTurnRecursive(Node<SnapshotNode> current, Player player)
    {
        if (current == null) return; // Caso base: no hay nodo actual

        Debug.Log($"Cargando el turno: {current.Value.Turn}");
        player.transform.position = current.Value.playerPosition;
        player.transform.eulerAngles = current.Value.playerRotation;
        player.str = current.Value.str;
        player.dtx = current.Value.dtx;
        player.spd = current.Value.spd;
    }
}

