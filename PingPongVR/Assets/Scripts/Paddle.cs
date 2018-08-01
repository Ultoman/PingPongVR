using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
		
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Triggered");
		if (other.gameObject.tag == "Ball")
		{
			Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
			Debug.Log(rb.velocity.sqrMagnitude);
			rb.velocity = transform.forward * (rb.velocity.magnitude + 0.5f);
			
			
		}
	}
}
