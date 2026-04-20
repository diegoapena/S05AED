using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;



public class Player : MonoBehaviour
{
    public int str;
    public int dtx;
    public int spd;

    
    public float moveDistance = 2f;
    private CharacterController controller;
    public InputSystem_Actions inputs;

    private CustomDoubleLinkedList snapshotList;

    private void Awake()
    {
        inputs = new InputSystem_Actions();
        controller = GetComponent<CharacterController>();
    }
    private void Start()
    {
        snapshotList = GameManager.instance.snapshots;
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Move.performed += MovementBehavior;
    }
    private void OnDisable()
    {
        inputs.Disable();
        inputs.Player.Move.performed -= MovementBehavior;
    }
    private void SaveTurn()
    {
        snapshotList.SaveTurn();
    }
    private void MovementBehavior(InputAction.CallbackContext context)
    {
       if (!GameManager.instance.EnablePlayerTurn) return; // Evitar movimiento si no es el turno del jugador
        Vector2 input = context.ReadValue<Vector2>();

        Vector3 move = new Vector3(input.x, 0, input.y) * moveDistance;

        controller.Move(move);

        
        if (move != Vector3.zero) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = targetRotation;
        }

      
        SaveTurn();
    }
  
}
