using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	Rigidbody boltRB;
	public float boltSpeed;

	void Start(){

		boltRB = GetComponent<Rigidbody>();
		boltRB.velocity = transform.forward * boltSpeed;

	}
}
