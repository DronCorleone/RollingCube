using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikeController : MonoBehaviour
{
    [SerializeField] private float _timeInterval;
    [SerializeField] private float _speed;

    private PikeModel[] _pikes;
    private float _timer;
    private float _defaultHeight;
    private float _upHeight;
    private float _height = 0.75f;
    private bool _isUp = false;

    private void Start()
    {
        _pikes = GetComponentsInChildren<PikeModel>();
        _timer = 0;
        _defaultHeight = _pikes[0].transform.position.y;
        _upHeight = _defaultHeight + _height;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeInterval)
        {
            if (!_isUp)
            {
                for (int i = 0; i < _pikes.Length; i++)
                {
                    _pikes[i].transform.position += Vector3.up * Time.deltaTime * _speed;
                }

                if (_pikes[0].transform.position.y >= _upHeight)
                {
                    _isUp = true;
                    _timer = 0;
                }
            }
            else
            {
                for (int i = 0; i < _pikes.Length; i++)
                {
                    _pikes[i].transform.position += Vector3.down * Time.deltaTime * _speed;
                }

                if (_pikes[0].transform.position.y <= _defaultHeight)
                {
                    _isUp = false;
                    _timer = 0;
                }
            }
        }
    }
}