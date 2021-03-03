using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject Player;

	private Vector3 _startPositionVector;
	private Vector3 _positionVector;
	private bool _isActive;

	private void Start()
	{
		_startPositionVector = Player.transform.position;
		_positionVector = _startPositionVector - transform.position;
		_isActive = true;
	}

	private void Update()
	{
		if (!_isActive) return;
		transform.position = Player.transform.position - _positionVector;
	}

	public void TurnOff()
    {
		_isActive = false;
    }
}