using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMoveDirection : MonoBehaviour {
	[SerializeField] private float _rotationSpeed = 50;
	Vector3 _previousPosition;
	float _maxRadiansDelta = 1;
	void Update() {
		Vector3 currentDirection = transform.position - _previousPosition;
		Vector3 targetDirection = Vector3.RotateTowards(transform.forward, currentDirection, _maxRadiansDelta, Time.deltaTime);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * _rotationSpeed);
		_previousPosition = transform.position;
	}
}
