using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float MovementVelocity = 5f;
    [SerializeField] private float RotateVelocity = 200f;
    [SerializeField] Animator anim;
    [SerializeField] private float x;
    [SerializeField] private float y;
    public int SafeObjects = 2;
    public int UnSafeObjects = 2;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0, x * Time.deltaTime * RotateVelocity, 0);
        transform.Translate(0, 0, y * Time.deltaTime * MovementVelocity);
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
    }
}
