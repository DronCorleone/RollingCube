using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float tumblingDuration = 0.2f;
    [SerializeField] private LayerMask _winMask;

    private CameraFollow _camera;
    private Rigidbody _rigidbody;
    private BoxCollider _collider;
    private Vector3 _dir;
    private float _stepSize = 0.5f;
    private float _raySize = 2f;
    private bool isTumbling = false;

    private InputController _inputController;
    private MoveDirection _moveDirection;
    private bool _isInputAllow;

    private float _loseHeight = -10f;
    private PlayerState _state;

    public PlayerState State => _state;

    private void Start()
    {
        _inputController = FindObjectOfType<InputController>();
        _camera = FindObjectOfType<CameraFollow>();

        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();

        _rigidbody.isKinematic = true;
        _isInputAllow = true;
        _state = PlayerState.InGame;
    }

    void Update()
    {
        // Control
        _dir = Vector3.zero;
        _moveDirection = _inputController.GetDirection();

        if (_isInputAllow)
        {
            switch (_moveDirection)
            {
                case MoveDirection.RightUp:
                    _dir = Vector3.forward;
                    break;
                case MoveDirection.RightDown:
                    _dir = Vector3.right;
                    break;
                case MoveDirection.LeftUp:
                    _dir = Vector3.left;
                    break;
                case MoveDirection.LeftDown:
                    _dir = Vector3.back;
                    break;
                default:
                    _dir = Vector3.zero;
                    break;
            }
        }

        if (_dir != Vector3.zero && !isTumbling)
        {
            StartCoroutine(Tumble(_dir));
        }

        // Raycast
        if (!Physics.Raycast(transform.position, Vector3.down, _raySize))
        {
            _isInputAllow = false;
            _rigidbody.isKinematic = false;
            _camera.TurnOff();
            Physics.gravity = new Vector3(0, -25, 0);
            _collider.isTrigger = true;
        }
        else if (Physics.Raycast(transform.position, Vector3.down, _raySize, _winMask))
        {
            _state = PlayerState.Win;
            _collider.isTrigger = false;
        }

        // Height
        if (transform.position.y <= _loseHeight)
        {
            _state = PlayerState.Lose;
        }
    }

    private IEnumerator Tumble(Vector3 direction)
    {
        isTumbling = true;

        var rotAxis = Vector3.Cross(Vector3.up, direction);
        var pivot = (transform.position + Vector3.down * _stepSize) + direction * _stepSize;

        var startRotation = transform.rotation;
        var endRotation = Quaternion.AngleAxis(90.0f, rotAxis) * startRotation;

        var startPosition = transform.position;
        var endPosition = transform.position + direction;

        var rotSpeed = 90.0f / tumblingDuration;
        var t = 0.0f;

        while (t < tumblingDuration)
        {
            t += Time.deltaTime;
            if (t < tumblingDuration)
            {
                transform.RotateAround(pivot, rotAxis, rotSpeed * Time.deltaTime);
                yield return null;
            }
            else
            {
                transform.rotation = endRotation;
                transform.position = endPosition;
            }
        }

        isTumbling = false;
    }

    public void Death()
    {
        _camera.TurnOff();
        _isInputAllow = false;
        _state = PlayerState.Death;
    }
}