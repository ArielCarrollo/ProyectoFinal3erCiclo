using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Inventory inventory;
    [SerializeField] private float MovementVelocity;
    [SerializeField] private Transform cameraTransform;

    private Animator anim;
    private Vector2 movementInput;
    private bool isPickingUp = false; // Flag to track "Pick Up" animation state

    private void Awake()
    {
        anim = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0f;

        Quaternion targetRotation = Quaternion.LookRotation(cameraForward);

        transform.rotation = targetRotation;

        Vector3 forwardMovement = transform.forward * movementInput.y * MovementVelocity * Time.deltaTime;
        Vector3 rightMovement = transform.right * movementInput.x * MovementVelocity * Time.deltaTime;
        transform.position += forwardMovement + rightMovement;

        anim.SetInteger("VelX", (int)movementInput.x);
        anim.SetInteger("VelY", (int)movementInput.y);

        // Check for animation completion using normalized time
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && isPickingUp)
        {
            isPickingUp = false; // Reset flag after animation finishes
            anim.SetBool("Pick", false); // Deactivate "Pick" animation
        }
        if (isPickingUp)
        {
            movementInput = Vector2.zero; // Set movement input to zero
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void PickUp(InputAction.CallbackContext context)
    {
        if (context.performed && !isPickingUp) // Trigger animation only once
        {
            isPickingUp = true; // Set flag to track animation state
            anim.SetBool("Pick", true);
        }
    }

    public void Throw(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Implement throwing logic here
        }
    }
    
}






