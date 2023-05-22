using UnityEngine;
using UnityEngine.UI;

public class ScoringManager : MonoBehaviour
{
	private int leftScore = 0, rightScore = 0;

	public int maxScore;

	[SerializeField] private bool pvpMode;

	public Text leftScoreText, rightScoreText;

	public void LeftPaddleScores()
	{
		leftScoreText.text = (++leftScore).ToString();
		CheckEndGame();
	}

	public void RightPaddleScores()
	{
		rightScoreText.text = (++rightScore).ToString();
		CheckEndGame();
	}

	private void CheckEndGame()
	{
		if (pvpMode)
		{
			if (leftScore == maxScore || rightScore == maxScore)
				ScenesManager.GetInstance().ChangeToScene((int)ScenesID.PVP_GAMEOVER);
		}
		else
		{
			if (leftScore == maxScore)
				ScenesManager.GetInstance().ChangeToScene((int)ScenesID.PVC_VICTORY);

			else if (rightScore == maxScore)
				ScenesManager.GetInstance().ChangeToScene((int)ScenesID.PVC_GAMEOVER);
		}

	}

}
