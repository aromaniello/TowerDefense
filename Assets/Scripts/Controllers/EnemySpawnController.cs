using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemySpawnController : MonoBehaviour
{
	[SerializeField] private WavesData _wavesData;
	[SerializeField] private Transform _spawnPoint;
	[SerializeField] private GameObject _weakEnemyPrefab;
	[SerializeField] private GameObject _midEnemyPrefab;
	[SerializeField] private GameObject _heavyEnemyPrefab;
	[SerializeField] private float _minimumSpawnDelay = 1;
	[SerializeField] private float _maximumSpawnDelay = 3;
	// [SerializeField] private float _waitTimeBetweenWaves = 5;
	[SerializeField] private UnityEvent OnWavesEnded;
	private int _waveNumber;
	private ObjectPool _weakEnemyPool;

	private void Start()
	{
		_weakEnemyPool = new ObjectPool();
		_weakEnemyPool.ObjectPrefab = _weakEnemyPrefab;
		StartCoroutine(CreateNewEnemyWave());
	}

	IEnumerator CreateNewEnemyWave()
	{
		while (_waveNumber < _wavesData.Waves.Length && GameManager.Instance.CurrentGameState == GameManager.GameState.Playing)
		{
			StartCoroutine(SpawnEnemies(_wavesData.Waves[_waveNumber].WeakEnemies, _weakEnemyPrefab));
			StartCoroutine(SpawnEnemies(_wavesData.Waves[_waveNumber].MidEnemies, _midEnemyPrefab));
			StartCoroutine(SpawnEnemies(_wavesData.Waves[_waveNumber].HeavyEnemies, _heavyEnemyPrefab));
			// StartCoroutine(SpawnEnemiesFromPool(_wavesData.Waves[_waveNumber].WeakEnemies, _weakEnemyPool));
			// StartCoroutine(SpawnEnemiesFromPool(_wavesData.Waves[_waveNumber].MidEnemies, _midEnemyPool));
			// StartCoroutine(SpawnEnemiesFromPool(_wavesData.Waves[_waveNumber].heavyEnemies, _heavyEnemyPool));

			while (GameManager.Instance.EnemyCount > 0)
			{
				yield return null;
			}
			_waveNumber += 1;
		}
		// Winner
		if (!GameManager.Instance.GameOver)
		{
			OnWavesEnded?.Invoke();
		}
	}

	IEnumerator SpawnEnemies(int enemyAmount, GameObject enemyPrefab)
	{
		for (int i = 0; i < enemyAmount; i++)
		{
			Instantiate(enemyPrefab, _spawnPoint.position, Quaternion.identity);
			yield return new WaitForSeconds(Random.Range(_minimumSpawnDelay, _maximumSpawnDelay));
		}
	}

	IEnumerator SpawnEnemiesFromPool(int enemyAmount, ObjectPool objectPool)
	{
		for (int i = 0; i < enemyAmount; i++)
		{
			GameObject enemy = objectPool.GetGameObjectFromPool();
			enemy.transform.position = _spawnPoint.position;
			enemy.SetActive(true);
			yield return new WaitForSeconds(Random.Range(_minimumSpawnDelay, _maximumSpawnDelay));
		}
	}
}
