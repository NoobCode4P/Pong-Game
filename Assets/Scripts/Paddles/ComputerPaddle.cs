using UnityEngine;

public class ComputerPaddle : Paddle {

	public Rigidbody2D ball;

	private void FixedUpdate()
	{
		Vector2 ballDirection = (transform.position - ball.transform.position).normalized;
		Vector2 relativeVelocity = ball.velocity - rigidbody2d.velocity;

		if (Vector2.Dot(relativeVelocity, ballDirection) > 0)   // The ball moves towards the Computer Paddle
		{
			if (ball.position.y > rigidbody2d.position.y)
				rigidbody2d.AddForce(Vector2.up* speed);
			else if (ball.position.y < rigidbody2d.position.y)
				rigidbody2d.AddForce(Vector2.down * speed);
		}
		else
		{
			// If the ball moves away from the Computer Paddle, it idles in the middle
			if (rigidbody2d.position.y > 0f)
				rigidbody2d.AddForce(Vector2.down * speed);
			else if (rigidbody2d.position.y < 0f)
				rigidbody2d.AddForce(Vector2.up * speed);
		}
	}

}