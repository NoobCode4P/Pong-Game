using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float initialSpeed, maxSpeed;
	public ScoringManager scoringManager;

	float speedRate;

	private Rigidbody2D rb2d;

	private Camera mainCamera;

	void Start() 
	{
		rb2d = GetComponent<Rigidbody2D>();
		mainCamera = Camera.main;
		StartCoroutine(Launch());
	}

	private void Update()
	{
		float cameraHeight = Mathf.Abs(mainCamera.orthographicSize) * 2f;
		float cameraWidth = cameraHeight * mainCamera.aspect;

		if (Mathf.Abs(transform.position.y) > cameraHeight / 2 || Mathf.Abs(transform.position.x) > cameraWidth / 2)
		{
			StartCoroutine(Launch());
		}
	}
	
	public IEnumerator Launch() 
	{
		speedRate = 1.1f;

		ResetBall();

		yield return new WaitForSeconds(1);

		// 50 - 50: starts on the left or right
		float x = Random.value < 0.5f ? -1.0f : 1.0f;

		// 50 - 50: goes up or down
		float y = Random.value < 0.5f ? Random.Range(-1f, 0.5f) : Random.Range(0.5f, 1f);

		Vector2 direction = new (x, y);

		rb2d.velocity = direction.normalized * initialSpeed;

	}

	public void ResetBall()
	{
		rb2d.velocity = rb2d.position = Vector2.zero;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision != null)
		{
			if (collision.gameObject.CompareTag("Paddle"))
			{
				if (rb2d.velocity.magnitude * (speedRate + 0.1f) <= maxSpeed)
				{
					speedRate += 0.1f;
					rb2d.velocity *= speedRate;
				}
				
			}
			else if (collision.gameObject.CompareTag("ScoreZone"))
			{
				if (collision.gameObject.transform.position.x > 0)
					scoringManager.LeftPaddleScores();
				else
					scoringManager.RightPaddleScores();

				StartCoroutine(Launch());
			}

			AudioManager.GetInstance().PlayHitSound();
		}
	}
	
}
