using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed = 360;
    [SerializeField] private Animator _animator;

    [SerializeField] private Rigidbody _rbody;

    private PlayerControls _controls;
    private Vector3 _moveInput;

    private void Awake()
    {
        _controls = InputManager.getControls();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rbody.MovePosition(transform.position + (transform.forward * _moveInput.magnitude) * _speed * Time.deltaTime);
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            _controls.asset.FindActionMap("Gameplay").Disable();
            _controls.asset.FindActionMap("UI").Enable();
        }
        else
        {
            _controls.asset.FindActionMap("UI").Disable();
            _controls.asset.FindActionMap("Gameplay").Enable();
        }

        GatherInput();
        Look();
    }

    private void GatherInput()
    {
        Vector2 temp = _controls.Gameplay.Movement.ReadValue<Vector2>();
        if (temp != Vector2.zero)
            _moveInput = new Vector3(temp.x, 0, temp.y);
        else
            _moveInput = Vector2.zero;
    }

    private void Look()
    {
        if (_moveInput != Vector3.zero)
        {
            _animator.Play("Walk");
            var relative = _moveInput.ToIso();
            var rot = Quaternion.LookRotation(relative,Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.fixedDeltaTime);
            //transform.rotation = rot;
        }
        else
        {
            _animator.Play("Idle");
        }
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }
}