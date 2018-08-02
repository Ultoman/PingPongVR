using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	private Vector3 _previousPosition;
	private Vector3 _velocity;

	private bool _ballHit = false;
	// Use this for initialization
	void Start () {
		_previousPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		

		_velocity = (transform.position - _previousPosition)/ Time.deltaTime;
		_previousPosition = transform.position;
		
		if (_velocity.magnitude > 0.001)
		{
			Debug.Log(_velocity.magnitude);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Triggered");
		if (other.gameObject.tag == "Ball")
		{
			if (other.gameObject.GetComponent<Ball>().getLastHitObject() != this.gameObject)
			{
				Rigidbody ballRB = other.gameObject.GetComponent<Rigidbody>();
				Debug.Log(ballRB.velocity.sqrMagnitude);
				float ballMagnitude = ballRB.velocity.magnitude;
				ballRB.velocity = transform.forward * (ballRB.velocity.magnitude) + _velocity;
			
				_ballHit = true;
			}
			
		}
	}
}
