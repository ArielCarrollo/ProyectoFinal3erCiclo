using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Inventory inventory;
    [SerializeField] private float MovementVelocity;
    [SerializeField] private Transform cameraTransform; // Referencia a la transformaci�n de la c�mara

    private Animator anim;
    private Vector2 movementInput;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        cameraTransform = Camera.main.transform; // Asigna la transformaci�n de la c�mara
    }

    private void Update()
    {
        // Obt�n la direcci�n de la c�mara
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0f; // Ignora la componente Y para mantener al jugador en el plano horizontal

        // Calcula la rotaci�n deseada para el jugador
        Quaternion targetRotation = Quaternion.LookRotation(cameraForward);

        // Aplica la rotaci�n al jugador
        transform.rotation = targetRotation;

        // Movimiento similar al que ya tienes
        Vector3 forwardMovement = transform.forward * movementInput.y * MovementVelocity * Time.deltaTime;
        Vector3 rightMovement = transform.right * movementInput.x * MovementVelocity * Time.deltaTime;
        transform.position += forwardMovement + rightMovement;

        // Actualiza las animaciones
        anim.SetFloat("VelX", movementInput.x);
        anim.SetFloat("VelY", movementInput.y);
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




