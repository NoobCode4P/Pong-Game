using UnityEngine;
using UnityEngine.SceneManagement;

public enum ScenesID
{
	MAINMENU,
	SELECTMODE,
	PVC_SELECTDIFF, PVC_EASY, PVC_MED, PVC_HARD, PVC_VICTORY, PVC_GAMEOVER,
	PVP, PVP_GAMEOVER
}

public class ScenesManager : MonoBehaviour
{
	private static ScenesManager instance;

	private void Awake()
	{
		if (instance)
			Destroy(gameObject);
		else
		{
			instance = this;
			DontDestroyOnLoad(instance);
		}
	}

	public static ScenesManager GetInstance()
	{
		return instance;
	}

	public void ChangeToScene(int sceneID)
	{
		SceneManager.LoadScene(sceneID);
	}

	public void QuitPongGame()
	{
		Application.Quit();
	}

}