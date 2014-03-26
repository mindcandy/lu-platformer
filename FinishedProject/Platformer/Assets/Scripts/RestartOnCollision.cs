using UnityEngine;
using System.Collections;

public class RestartOnCollision : MonoBehaviour {

	private bool _restarting = false;
	private SpriteRenderer _playerSprite;

	void OnCollisionEnter2D(Collision2D collision)
	{
		//disable the player controller to stop movement
		collision.gameObject.GetComponent<PlayerController>().enabled = false;
		collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
		Destroy(collision.gameObject.GetComponent<Rigidbody2D>());

		//store the player sprite and set the flag to control the dissapear animation and restart
		_playerSprite = collision.gameObject.GetComponent<SpriteRenderer>();
		_restarting = true;
	}

	void Update()
	{
		//only animate the players demise based on the _restarting flag
		if(_restarting)
		{
			if(_playerSprite.color.a > 0)
			{
				Color playerColor = _playerSprite.color;
				playerColor.a -= 0.05f;
				_playerSprite.color = playerColor;
			}
			else
			{
				StartCoroutine(RestartLevel());
			}
		}
	}

	IEnumerator RestartLevel()
	{
		//wait for a second before reloading the current level
		yield return new WaitForSeconds(1);

		Application.LoadLevel(Application.loadedLevelName);
	}



}
