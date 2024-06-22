using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Inventory inventory;
    [SerializeField] private float MovementVelocity;
    [SerializeField] private float RotateVelocity;
    [SerializeField] Animator anim;
    [SerializeField] private Vector2 movementInput;
    [SerializeField] private Vector2 lookInput;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 forwardMovement = transform.forward * movementInput.y * MovementVelocity * Time.deltaTime;
        Vector3 rightMovement = transform.right * movementInput.x * MovementVelocity * Time.deltaTime;
        transform.position += forwardMovement + rightMovement;
        anim.SetFloat("VelX", movementInput.x);
        anim.SetFloat("VelY", movementInput.y);
        RotatePlayer();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
    private void RotatePlayer()
    {
        float mouseX = lookInput.x * RotateVelocity * Time.deltaTime;
        transform.Rotate(0, mouseX, 0);
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

