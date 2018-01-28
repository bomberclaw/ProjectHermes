using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwapper : MonoBehaviour
{
	static private int sceneNumber;
	public void LoadNextLevel()
	{
		sceneNumber = SceneManager.GetActiveScene().buildIndex + 1;
		if (sceneNumber >= SceneManager.sceneCountInBuildSettings)
		{
			sceneNumber = 0;
		}
		SceneManager.LoadScene(sceneNumber);
	}

	public void ReloadLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
