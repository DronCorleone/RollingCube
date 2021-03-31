using UnityEngine;

public class InputController : MonoBehaviour
{
    private Touch _touch;
    private Vector2 _startPosition;
    private Vector2 _currentPosition;
    private bool _inputStart;
    private MoveDirection _direction;


    private void Start()
    {
        _startPosition = new Vector2(0, 0);
        _direction = MoveDirection.None;
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began && !_inputStart)
            {
                _inputStart = true;
                _startPosition = _touch.position;
            }
            else if (_touch.phase == TouchPhase.Moved)
            {
                _currentPosition = _touch.position;

                if (_currentPosition.x > _startPosition.x)
                {
                    if (_currentPosition.y > _startPosition.y)
                    {
                        _direction = MoveDirection.RightUp;
                    }
                    else if (_currentPosition.y < _startPosition.y)
                    {
                        _direction = MoveDirection.RightDown;
                    }
                }
                else if (_currentPosition.x < _startPosition.x)
                {
                    if (_currentPosition.y > _startPosition.y)
                    {
                        _direction = MoveDirection.LeftUp;
                    }
                    else if (_currentPosition.y < _startPosition.y)
                    {
                        _direction = MoveDirection.LeftDown;
                    }
                }
                else
                {
                    _direction = MoveDirection.None;
                }
            }
        }
        else
        {
            _inputStart = false;
            _direction = MoveDirection.None;
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            _direction = MoveDirection.RightDown;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _direction = MoveDirection.LeftDown;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _direction = MoveDirection.LeftUp;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            _direction = MoveDirection.RightUp;
        }
        else
        {
            _direction = MoveDirection.None;
        }

    }

    public MoveDirection GetDirection()
    {
        return _direction;
    }
}