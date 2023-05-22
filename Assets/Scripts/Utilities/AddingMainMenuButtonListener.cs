using UnityEngine;
using UnityEngine.UI;

public class AddingMainMenuButtonListener : MonoBehaviour
{
	void Start()
	{
		Button[] buttons = FindObjectsOfType<Button>();

		foreach (Button c in buttons)
		{
			if (c.name == "Play Button")
				c.onClick.AddListener(() => ScenesManager.GetInstance().ChangeToScene((int)ScenesID.SELECTMODE));

			else if (c.name == "Quit Button")
				c.onClick.AddListener(() => ScenesManager.GetInstance().QuitPongGame());
		}
		
	}

}