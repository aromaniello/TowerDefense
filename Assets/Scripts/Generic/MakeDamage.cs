using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MakeDamage : MonoBehaviour {
	[SerializeField] private int _damagePower = 10;
	[SerializeField] private string _tagToCompare = "Player";
	[SerializeField] private UnityEvent OnTrigger;
	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag(_tagToCompare)) {
			Health health = other.GetComponent<Health>();
			if (health != null) {
				health.ReceiveDamage(_damagePower);
				OnTrigger?.Invoke();
			}
		}
	}
}
