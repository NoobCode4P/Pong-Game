using UnityEngine;

public class PlayerPaddle : Paddle {

	public KeyCode Up, Down;

	public override void Update() 
	{
		if (Input.GetKey(Up))
			direction = Vector2.up;
		else if (Input.GetKey(Down))
			direction = Vector2.down;
		else
			direction = Vector2.zero;
	}

	private void FixedUpdate()
	{
		rigidbody2d.velocity = direction * speed;
	}
}