using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
  [SerializeField] private GameObject _loseScreen;
	[SerializeField] private GameObject _winScreen;

	public void ShowGameOverScreen() {
		if (GameManager.Instance.Winner) {
			_winScreen.SetActive(true);
		} else {
			_loseScreen.SetActive(true);
		}
	}

	public void SliderValueChanged(float value) {
		GameManager.Instance.GameSpeed = value;
	}

	public void RetryGame(string sceneName) {
		SceneLoader.LoadScene(sceneName);
	}
}
