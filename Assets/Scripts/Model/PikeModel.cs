using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikeModel : MonoBehaviour
{
    [SerializeField] private float _raySize;
    [SerializeField] private LayerMask _mask;

    private ParticleSystem _particles;


    private void Start()
    {
        _particles = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.up, out RaycastHit hit, _raySize, _mask))
        {
            Debug.Log("Есть пробитие");
            if (hit.transform.TryGetComponent(out PlayerMoveController player))
            {
                Debug.Log("Player is found!");
                _particles.gameObject.transform.position = player.gameObject.transform.position;
                player.Death();
                _particles.Play();
            }
        }
    }
}