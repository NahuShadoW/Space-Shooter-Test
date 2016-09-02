using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject[] enemies;
	public Vector3 spawnValues;
	public GUIText livesText;
	public GUIText restartText;
	public GUIText gameOverText;
	private bool gameOver;
	private bool restart;
	public int lives;
	public int enemyCount;
	public float startWait;
	public float spawnWait;
	public float waveWait;

	void Start ()
	{
		SpawnWaves ();
		lives = 3;
		showLives();
		gameOverText.text = "";
		restartText.text = "";
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel ("MainMenuScene");
			}
		}


		if(Input.GetKeyDown(KeyCode.Escape)){

			Application.Quit();

		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < enemyCount; i++)
			{
				GameObject enemy = enemies [Random.Range (0, enemies.Length)];
				Vector3 spawnPosition = new Vector3 ( spawnValues.x, spawnValues.y,Random.Range (-spawnValues.z,spawnValues.z));
				Quaternion spawnRotation = Quaternion.Euler(0.0f,270f,0.0f);
				Instantiate (enemy, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	
	void showLives (){

		livesText.text = "Lives Left: " + lives;
	}
	public void takeDamage (int damage){

		lives = lives - damage;
		showLives();

	}

	public void GameOver(){

		if(lives == 0){

			gameOverText.text = "Game Over";
			gameOver = true;
		}

	}
}
