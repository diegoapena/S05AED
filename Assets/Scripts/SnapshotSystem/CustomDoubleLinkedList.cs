using UnityEngine;
using Sirenix.OdinInspector;

public class CustomDoubleLinkedList : DoubleLinkedList<SnapshotNode>
{
    public Node<SnapshotNode> pointer;

    public void SaveTurn()
    {
        // Si el puntero no está en el último nodo, eliminar todos los nodos futuros
        if (pointer != tail)
        {
            RemoveFromPosition(pointer.Next);
        }

        // Crear un nuevo snapshot y agregarlo al final
        SnapshotNode snapshot = new SnapshotNode(GameManager.instance.player, Count);
        base.Add(snapshot);

        // Actualizar el puntero al nuevo último nodo
        ResetPointer();
    }

    public void ResetPointer()
    {
        pointer = tail;
    }

    public void MoveBackwards()
    {
        if (pointer.Prev == null) return;
        pointer = pointer.Prev;
    }

    public void MoveForward()
    {
        if (pointer.Next == null) return;
        pointer = pointer.Next;
    }

    public void LoadTurn(Player player)
    {
        Debug.Log("Cargando el turno: " + pointer.Value.Turn);
        player.transform.position = pointer.Value.playerPosition;
        player.transform.eulerAngles = pointer.Value.playerRotation;
        player.str = pointer.Value.str;
        player.dtx = pointer.Value.dtx;
        player.spd = pointer.Value.spd;
    }
}
