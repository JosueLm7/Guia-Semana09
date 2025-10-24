using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    private PlayerInputActions _input;
    private CharacterController _controller;
    private Transform _camera;

    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _sensitivity = 1f;

    private Vector2 _move;
    private Vector2 _look;
    private float _xRotation = 0f;

    private void Awake()
    {
        _input = new PlayerInputActions();
        _controller = GetComponent<CharacterController>();
        _camera = Camera.main.transform;
    }

    private void OnEnable()
    {
        _input.Player.Enable();
        _input.Player.Move.performed += ctx => _move = ctx.ReadValue<Vector2>();
        _input.Player.Move.canceled += ctx => _move = Vector2.zero;
        _input.Player.Look.performed += ctx => _look = ctx.ReadValue<Vector2>();
        _input.Player.Look.canceled += ctx => _look = Vector2.zero;
    }

    private void OnDisable()
    {
        _input.Player.Disable();
    }

    private void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        Vector3 move = transform.right * _move.x + transform.forward * _move.y;
        _controller.Move(move * _speed * Time.deltaTime);
    }

    private void Look()
    {
        float mouseX = _look.x * _sensitivity;
        float mouseY = _look.y * _sensitivity;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _camera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
