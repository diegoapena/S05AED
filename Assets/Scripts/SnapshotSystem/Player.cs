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

    private Coroutine autoPlaybackCoroutine; // Para controlar la reproducción automática

    private void Awake()
    {
        inputs = new InputSystem_Actions();
        controller = GetComponent<CharacterController>();
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

    private void Start()
    {
        snapshotList = GameManager.instance.snapshots;
    }

    private void MovementBehavior(InputAction.CallbackContext context)
    {

        Vector2 input = context.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y) * moveDistance;
        controller.Move(move);
        
        SaveTurn();
       
    }
    private void SaveTurn()
    {
        snapshotList.SaveTurn();
    }
}
