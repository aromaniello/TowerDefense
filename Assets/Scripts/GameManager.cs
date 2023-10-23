using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
	private static GameManager _gameManager { get; set; }
	private int _enemyCount;
  [Range(0,5)][SerializeField] private float _gameSpeed = 1;
	private bool _winner;
	private bool _gameOver;
	[SerializeField] private UnityEvent OnGameOver;

	public bool Winner {
		get => _winner;
		set => _winner = value;
	}
	public bool GameOver {
		get => _gameOver;
		set {
			_gameOver = value;
			CurrentGameState = GameState.GameOver;
			OnGameOver?.Invoke();
		}
	}

	public int EnemyCount {
		get => _enemyCount;
		set => _enemyCount = value;
	}

	public float GameSpeed {
		get => _gameSpeed;
		set => _gameSpeed = value;
	}

	public static GameManager Instance {
		get => _gameManager;
		set => _gameManager = value;
	}

	public enum GameState {
		Playing,
		GameOver
	}

	private GameState _currentGameState;

	public GameState CurrentGameState {
		get => _currentGameState;
		set => _currentGameState = value;
	}

	private void Awake() {
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	void Update() {
		Time.timeScale = _gameSpeed;
	}
}
