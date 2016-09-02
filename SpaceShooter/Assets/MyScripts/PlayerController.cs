using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {

	public float zMin , zMax;
	
}
public class PlayerController : MonoBehaviour {

	public float speed;
	public Boundary bounds;
	Rigidbody rb;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextShot;
	AudioSource shootSound;
	void Start(){

		rb = GetComponent<Rigidbody>();
		shootSound = GetComponent<AudioSource>();
	}

	void Update(){
		if(Input.GetButton("Fire1")&& Time.time > nextShot ){
			nextShot = Time.time + fireRate;
			Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
			shootSound.Play();
		}
	}
	void FixedUpdate(){

		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (0.0f,0.0f, moveVertical);
		rb.velocity = movement * speed;
		rb.position = new Vector3 (0.0f,0.0f,Mathf.Clamp(rb.position.z,bounds.zMin,bounds.zMax));

	}
}
