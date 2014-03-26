using UnityEngine;
using System.Collections;

public class ExitDoor : MonoBehaviour {

	public string sceneName;

	void OnCollisionEnter2D(Collision2D collision)
	{
		Application.LoadLevel(sceneName);
	}
}
