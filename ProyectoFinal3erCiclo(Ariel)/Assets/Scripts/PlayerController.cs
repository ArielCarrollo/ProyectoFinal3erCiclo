using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Inventory inventory;
    [SerializeField] private float MovementVelocity;
    [SerializeField] private Transform cameraTransform;
    private Vector3 cameraForward;
    private Quaternion targetRotation;
    private Vector3 forwardMovement;
    private Vector3 rightMovement;

    private Animator anim;
    private Vector2 movementInput;
    private bool isPickingUp = false; 

    private void Awake()
    {
        anim = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
    }
    private void Update()
    {
        cameraForward = cameraTransform.forward;
        cameraForward.y = 0f;

        targetRotation = Quaternion.LookRotation(cameraForward);

        transform.rotation = targetRotation;

        forwardMovement = transform.forward * movementInput.y * MovementVelocity * Time.deltaTime;
        rightMovement = transform.right * movementInput.x * MovementVelocity * Time.deltaTime;
        transform.position += forwardMovement + rightMovement;

        anim.SetInteger("VelX", (int)movementInput.x);
        anim.SetInteger("VelY", (int)movementInput.y);
        anim.SetFloat("VelXF", movementInput.x);
        anim.SetFloat("VelYF", movementInput.y);

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && isPickingUp)
        {
            isPickingUp = false; 
            anim.SetBool("Pick", false); 
        }
        if (isPickingUp)
        {
            movementInput = Vector2.zero; 
        }
        DiagonalAnimations();
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void DiagonalAnimations()
    {
        if (movementInput.x > 0.7f && movementInput.y > 0.7)
        {
            anim.SetBool("DiagonalMirror", true);
        }
        else
        {
            anim.SetBool("DiagonalMirror", false);
        }
        if (movementInput.x < -0.7f && movementInput.y > 0.7)
        {
            anim.SetBool("Diagonal", true);
        }
        else
        {
            anim.SetBool("Diagonal", false);
        }
        if(movementInput.x < -0.7f && movementInput.y < -0.7)
        {
            anim.SetBool("BackDiagonalMirror", true);
        }
        else
        {
            anim.SetBool("BackDiagonalMirror", false);
        }
        if(movementInput.x > 0.7f && movementInput.y < -0.7)
        {
            anim.SetBool("BackDiagonal", true);
        }
        else
        {
            anim.SetBool("BackDiagonal", false);
        }
    }
    public void PickUp(InputAction.CallbackContext context)
    {
        if (context.performed && !isPickingUp) 
        {
            isPickingUp = true; 
            anim.SetBool("Pick", true);
        }
    }
    public void Throw(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //
        }
    }
}






