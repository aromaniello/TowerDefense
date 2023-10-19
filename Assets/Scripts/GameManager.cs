using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  [Range(0,5)][SerializeField] private float _gameSpeed = 1;

	void Update() {
		Time.timeScale = _gameSpeed;
	}
}
