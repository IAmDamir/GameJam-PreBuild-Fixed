using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DaniyarMovement : MonoBehaviour
{
    public InputAction inp;
    public Vector2 wasdInput;
    private Rigidbody rb;
    public float speed;
    public GameObject frwrd;
    private Vector3 right;

    protected void OnEnable()
    {
        inp.Enable();
    }

    protected void OnDisable()
    {
        inp.Disable();
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * frwrd.transform.forward;
    }

    // Update is called once per frame
    private void Update()
    {
        IsometricMovement();
    }

    private void IsometricMovement()
    {
        wasdInput = inp.ReadValue<Vector2>();

        Vector3 wsMovement = frwrd.transform.forward * wasdInput.y;
        Vector3 adMovement = right * wasdInput.x;
        rb.velocity = Vector3.Normalize(wsMovement + adMovement) * speed;
    }
}