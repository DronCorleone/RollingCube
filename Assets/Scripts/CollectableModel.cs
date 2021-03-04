using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableModel : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Background _background;


    void Start()
    {
        _background = FindObjectOfType<Background>();
    }

    void Update()
    {
        _transform.Rotate(0f, 2.0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _background.OnColourChange();
            Destroy(_transform.gameObject);
        }
    }
}
