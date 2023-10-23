using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
	[SerializeField] private GameObject _loseScreen;
	[SerializeField] private GameObject _winScreen;
	[SerializeField] private Button[] _weaponButtons;
	[SerializeField] private TMP_Text _goldAmountText;
	[SerializeField] private ResourceData _resourceData;

	public void ShowGameOverScreen()
	{
		if (GameManager.Instance.Winner)
		{
			_winScreen.SetActive(true);
		}
		else
		{
			_loseScreen.SetActive(true);
		}
	}

	public void SliderValueChanged(float value)
	{
		GameManager.Instance.GameSpeed = value;
	}

	public void RetryGame(string sceneName)
	{
		SceneLoader.LoadScene(sceneName);
	}

	public void CheckIfEnoughGoldForWeapon(int _currentGoldAmount)
	{
		if (_currentGoldAmount >= _resourceData.WeaponsCosts[2].WeaponCost)
		{
			for (int i = 0; i < 3; i++)
			{
				// _weaponButtons[i].interactable = true;
			}
		}
		else if (_currentGoldAmount >= _resourceData.WeaponsCosts[1].WeaponCost)
		{
			for (int i = 0; i < 2; i++)
			{
				// _weaponButtons[i].interactable = true;
			}
		}
		else if (_currentGoldAmount >= _resourceData.WeaponsCosts[0].WeaponCost)
		{
			_weaponButtons[0].interactable = true;
		}
		else
		{
			for (int i = 0; i < _weaponButtons.Length; i++)
			{
				_weaponButtons[i].interactable = false;
			}
		}
	}

	public void UpdateGoldAmountUI(int currentGoldAmount)
	{
		_goldAmountText.text = $"Gold: {currentGoldAmount}";
	}
}
