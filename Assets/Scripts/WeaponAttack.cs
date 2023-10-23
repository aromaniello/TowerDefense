using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponAttack : MonoBehaviour {
	[SerializeField] private Transform _weaponBarrel;
	[SerializeField] private float _maxRayDistance = 20;
	[SerializeField] private int _damagePower = 10;
	[SerializeField] private float _shotCooldown = 1;
	enum WeaponTypeEnum {
		Gun,
		Cannon,
		Turret
	}
	[SerializeField] private WeaponTypeEnum _weaponType;
	[SerializeField] private GameObject _cannonballPrefab;
	[SerializeField] private Transform _cannonballSpawnPoint;
	[SerializeField] private UnityEvent OnShoot;

	private void Start() {
		StartCoroutine(FireRoutine());
	}

	IEnumerator FireRoutine() {
		while (GameManager.Instance.CurrentGameState == GameManager.GameState.Playing) {
			Ray ray = new Ray(_weaponBarrel.position, _weaponBarrel.forward);
			if (Physics.Raycast(ray, out RaycastHit hitInfo, _maxRayDistance)) {
				if (hitInfo.collider.CompareTag("Enemy")) {
					if (_weaponType == WeaponTypeEnum.Cannon) {
						Instantiate(_cannonballPrefab, _cannonballSpawnPoint.position, _cannonballSpawnPoint.rotation);
					} else {
						Health enemyHealth = hitInfo.collider.GetComponent<Health>();
						if (enemyHealth != null) {
							enemyHealth.ReceiveDamage(_damagePower);
						}
					}
					OnShoot?.Invoke();
				}
			}
			yield return new WaitForSeconds(_shotCooldown);
		}
	}
}
