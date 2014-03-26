using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

	public Transform start;
	public Transform end;
	public float platformDelay = 3.0f;

	private bool startToEnd = true;

	Vector3 _currentDestination;

	void Start()
	{
		SetCurrentVelocity();
	}

	void FixedUpdate () 
	{
		if(Vector3.Distance(gameObject.transform.position,_currentDestination) < 0.1f)
		{
			startToEnd = !startToEnd;
			SetCurrentVelocity();
		}	
	}
	
	void SetCurrentVelocity()
	{
		_currentDestination = GetDestination(); 
		Vector3 distance = _currentDestination - gameObject.transform.position;
		rigidbody2D.velocity = new Vector2(distance.x/platformDelay,distance.y/platformDelay);
	}

	Vector3 GetDestination()
	{
		if(startToEnd)
		{
			return end.position;
		}
		else
		{
			return start.position;
		}
	}

}
