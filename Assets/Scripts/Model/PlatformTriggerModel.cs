using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class PlatformTriggerModel : MonoBehaviour
{
    private bool _isActive;

    public bool IsActive
    {
        get => _isActive;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMoveController>())
        {
            _isActive = true;
        }
    }
}