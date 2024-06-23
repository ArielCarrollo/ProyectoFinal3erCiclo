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
        if(movementInput.y == 1 && movementInput.x == 1)
        {
            anim.SetTrigger("Run");
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "SafeObject" && Input.GetKeyDown(KeyCode.E))
        {
            inventory.SaveObject(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}




