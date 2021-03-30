using UnityEngine;

public class PikeModel : MonoBehaviour
{
    private ParticleSystem _particles;

    private void Start()
    {
        _particles = transform.parent.GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMoveController player))
        {
            _particles.gameObject.transform.position = player.gameObject.transform.position;
            player.Death();
            _particles.Play();
        }
    }
}