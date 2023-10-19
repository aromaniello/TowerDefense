using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneLoader {
	public static void LoadScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}
}
