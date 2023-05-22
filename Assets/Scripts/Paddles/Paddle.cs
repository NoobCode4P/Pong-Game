using UnityEngine;

public class Paddle : MonoBehaviour {
	public float speed;

	protected Rigidbody2D rigidbody2d;
	protected Vector2 direction;
	
	void Start() 
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
	}

	virtual public void Update() { }
}