using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private bool gameOver;
	private int score;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	void Start()
	{
		gameOver = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
	}

	void FixedUpdate ()
	{
		//float moveHorizontal = Input.GetAxis("Horizontal");
		//float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (0.0f, 0.0f, 0.9f);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
		rigidbody.position = new Vector3 
			(
				rigidbody.position.x,
				Mathf.Clamp (rigidbody.position.y, -5f, -0.27f),
				rigidbody.position.z
				);
	
	}

	void Update()
	{
		if(gameOver)
		{
			restartText.text = "Press 'R' to Restart";
			Vector3 movement = new Vector3 (0.0f, 0.0f, -0.9f);
			rigidbody.AddForce (movement * speed * Time.deltaTime);
			if(Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
