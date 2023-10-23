using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
	[SerializeField] private GameObject _objectToCreate;
	private Transform _spawnPoint;
	[SerializeField] private bool _useSpawnPoint;

	public void CreateNewObject()
	{
		if (_useSpawnPoint)
		{
			Instantiate(_objectToCreate, _spawnPoint.position, Quaternion.identity);
		}
		else
		{
			Instantiate(_objectToCreate, transform.position, Quaternion.identity);
		}
	}
}
