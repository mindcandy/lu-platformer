using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10;
	public float jumpSpeed = 3000;

	private bool _jumping;

	void Update()
	{

		if(!_jumping && Input.GetKeyDown(KeyCode.Space))
		{
			_jumping = true;
			rigidbody2D.AddForce(new Vector2(0,jumpSpeed));
		}
		if(rigidbody2D.velocity.y == 0)
		{
			_jumping = false;
		}
	}
	
	void FixedUpdate()
	{
		float inputX = Mathf.Round(Input.GetAxis("Horizontal"));
		rigidbody2D.velocity = new Vector2(moveSpeed * inputX,rigidbody2D.velocity.y);
	}
}
