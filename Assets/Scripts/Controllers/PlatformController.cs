using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private PlatformTriggerModel _trigger;
    private List<PlatformCubeModel> _cubes;


    private void Start()
    {
        _trigger = GetComponentInChildren<PlatformTriggerModel>();
        _cubes = new List<PlatformCubeModel>(GetComponentsInChildren<PlatformCubeModel>());

        for (int i = 0; i < _cubes.Count; i ++)
        {
            _cubes[i].TurnOff();
        }
    }

    private void Update()
    {
        if (_trigger.IsActive)
        {
            _trigger.gameObject.SetActive(false);

            for (int i = 0; i < _cubes.Count; i ++)
            {
                _cubes[i].TurnOn();
            }
        }
        else
        {
            _trigger.transform.Rotate(0, _rotateSpeed, 0);
        }
    }
}