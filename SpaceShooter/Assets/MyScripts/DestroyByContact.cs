using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int damageDone;  
	private GameController gameController;

	void Start(){

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary" )
		{
			return;
		}

		if(other.tag == "Enemy"){

			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
		//

		if (other.tag == "Player")
		{

			gameController.takeDamage(damageDone);
			if(gameController.lives == 0){
				gameController.GameOver ();
				Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
				Destroy(other.gameObject);

			}
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(gameObject);
		}
			


	}
}
