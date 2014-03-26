using UnityEngine;
using System.Collections;

public class TokenController : MonoBehaviour {

	private bool _obtained;

	private SpriteRenderer _spriteRenderer;

	void OnTriggerEnter2D(Collider2D collider) 
	{
		_obtained = true;
		_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		if(_obtained)
		{
			if(_spriteRenderer.color.a > 0)
			{
				Color color = _spriteRenderer.color;
				color.a -= 0.05f;
				_spriteRenderer.color = color;
				gameObject.transform.Translate(0,0.1f,0);
			}
			else
			{
				TextMesh scoreText = Camera.main.GetComponentInChildren<TextMesh>();
				int newScore = int.Parse(scoreText.text)+1;
				scoreText.text = newScore.ToString();
				Destroy (gameObject);
			}
		}
	}
}
