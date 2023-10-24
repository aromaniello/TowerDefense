using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	private void OnEnable() {
		GameManager.Instance.EnemyCount += 1;
	}

	private void OnDisable() {
		GameManager.Instance.EnemyCount -= 1;
	}
}
