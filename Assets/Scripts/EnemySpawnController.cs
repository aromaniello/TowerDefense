using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {
	[SerializeField] private WavesData _wavesData;
	[SerializeField] private Transform _spawnPoint;
	[SerializeField] private GameObject _weakEnemyPrefab;
	[SerializeField] private GameObject _midEnemyPrefab;
	[SerializeField] private GameObject _heavyEnemyPrefab;
	private int _waveNumber;

	private void Start() {
		StartCoroutine(CreateNewEnemyWave());
	}

	IEnumerator CreateNewEnemyWave() {
		while (_waveNumber < _wavesData.Waves.Length) {
			StartCoroutine(SpawnEnemies(_wavesData.Waves[_waveNumber].WeakEnemies, _weakEnemyPrefab));
			StartCoroutine(SpawnEnemies(_wavesData.Waves[_waveNumber].MidEnemies, _midEnemyPrefab));
			StartCoroutine(SpawnEnemies(_wavesData.Waves[_waveNumber].HeavyEnemies, _heavyEnemyPrefab));

			yield return new WaitForSeconds(5);
			_waveNumber += 1;
		}
	}

	IEnumerator SpawnEnemies(int enemyAmount, GameObject enemyPrefab) {
		for (int i = 0; i < enemyAmount; i++) {
			Instantiate(enemyPrefab, _spawnPoint.position, Quaternion.identity);
			yield return new WaitForSeconds(1);
		}
	}
}
