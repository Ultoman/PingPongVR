using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

	private Rigidbody rb;
	public float xForce, yForce, zForce;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.AddForce(new Vector3(xForce,yForce,zForce));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//rb.AddForce(new Vector3(0,-70,0));
		
	}
}
