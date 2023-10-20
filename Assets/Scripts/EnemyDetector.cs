using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDetector : MonoBehaviour {
	[SerializeField] private Transform _detectedTarget;
	[SerializeField] private float _maxAttackRange = 12;
	[SerializeField] private UnityEvent<Transform> OnEnemyDetected;
	[SerializeField] private UnityEvent OnEnemyLost;

	private void OnTriggerStay(Collider other) {
		if (_detectedTarget == null) {
			_detectedTarget = other.transform;
			OnEnemyDetected?.Invoke(other.transform);
		}
	}

	void Update() {
		if (_detectedTarget != null) {
			float distance = Vector3.Distance(transform.position, _detectedTarget.position);
			if (distance > _maxAttackRange) {
				_detectedTarget = null;
				OnEnemyLost?.Invoke();
			}
		}
	}
}
