using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour {

	public void PlayLevel()
	{
		SceneManager.LoadScene ("GameLevel");
	}

	public void Exit()
	{
		Application.Quit();
	}


}
