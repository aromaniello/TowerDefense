using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private GameObject _gunPrefab;
	// [SerializeField] private GameObject _cannonPrefab;
	// [SerializeField] private GameObject _laserTurretPrefab;
	[SerializeField] private GameObject _heldWeapon;
	[SerializeField] private Camera _mainCamera;
	[SerializeField] private float _maxRayDistance = 20;
	[SerializeField] private LayerMask _groundLayerMask;
	[SerializeField] private UnityEvent<string> OnWeaponPurchased;

	private void Start()
	{
		StartCoroutine(HeldWeaponRoutine());
	}

	public void CreateWeapon(string weaponType)
	{
		if (_heldWeapon != null)
			return;

		switch (weaponType)
		{
			case "Gun":
				_heldWeapon = Instantiate(_gunPrefab);
				break;
			case "Cannon":
				break;
			case "LaserTurret":
				break;
			default:
				Debug.LogError("Weapon type {weaponType} is not valid");
				break;
		}

		OnWeaponPurchased?.Invoke(weaponType);
	}

	IEnumerator HeldWeaponRoutine()
	{
		while (GameManager.Instance.CurrentGameState == GameManager.GameState.Playing)
		{
			if (_heldWeapon != null)
			{
				Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out RaycastHit hitInfo, _maxRayDistance, _groundLayerMask))
				{
					_heldWeapon.transform.position = hitInfo.point;
					if (Input.GetMouseButton(0) && hitInfo.collider.CompareTag("WeaponSlot") && hitInfo.transform.childCount == 0) // LMB
					{
						_heldWeapon.transform.position = hitInfo.transform.position;
						_heldWeapon.transform.SetParent(hitInfo.transform);
						// _heldWeapon.GetComponent<WeaponAttack>().StartWeaponAttack();
						_heldWeapon = null;
					}
				}

				if (Input.GetMouseButton(1)) // RMB
				{
					Destroy(_heldWeapon);
					_heldWeapon = null;
				}
			}
			yield return null;
		}
	}
}
