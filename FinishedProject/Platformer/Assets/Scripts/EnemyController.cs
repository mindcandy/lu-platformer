using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public Transform start;
	public Transform end;
	public float speed = 0.1f;

	private bool startToEnd = true;

	// Update is called once per frame
	void Update () {
		Vector3 destination = GetDestination(); 
		gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,destination,speed);
		if(gameObject.transform.position == destination)
		{
			startToEnd = !startToEnd;
		}	

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

	void OnTriggerEnter2D(Collider2D collider)
	{
		Destroy(gameObject);
	}

}
