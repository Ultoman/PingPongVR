using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelForce : MonoBehaviour {

	private Vector3 _forceDirection;
	public GameObject ball;
	public float speed = 0;
	// Use this for initialization
	void Start () {
		_forceDirection = transform.Find("ForceDirection").transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Dot(ball.GetComponent<Rigidbody>().velocity, _forceDirection) < 0)
		{
			_forceDirection *= -1;
		}
	}

	void FixedUpdate()
	{

	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Ball")
		{
			Rigidbody rb = other.GetComponent<Rigidbody>();
			rb.AddForce(_forceDirection * speed);
		}
		
	}
}
