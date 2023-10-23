using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {
	[SerializeField] private int _currentHealth = 100;
	[SerializeField] private UnityEvent<int> OnReceiveDamage;
	[SerializeField] private UnityEvent OnZeroHealth;

	public int CurrentHealth {
		get => _currentHealth;
		set => _currentHealth = value;
	}

	public void ReceiveDamage(int damageAmount) {
		CurrentHealth -= damageAmount;
		OnReceiveDamage?.Invoke(CurrentHealth);

		if (CurrentHealth <= 0) {
			OnZeroHealth?.Invoke();
		}
	}
}
