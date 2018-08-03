using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	private Vector3 _previousPosition;
	private Vector3 _velocity;

	// Use this for initialization
	void Start () {
		_previousPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		_velocity = (transform.position - _previousPosition)/ Time.deltaTime;
		_previousPosition = transform.position;
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Ball")
		{
			if (other.gameObject.GetComponent<Ball>().getLastHitObject() != this.gameObject)
			{
				Rigidbody ballRB = other.gameObject.GetComponent<Rigidbody>();
				// get speed of the ball
				float ballMagnitude = ballRB.velocity.magnitude;
				//
				float dp = Vector3.Dot(transform.forward, ballRB.velocity);
				if (dp < 0)
				{
					ballRB.velocity = transform.forward * (ballRB.velocity.magnitude) + _velocity;
				}
				else if (dp >= 0)
				{
					ballRB.velocity = -(transform.forward * (ballRB.velocity.magnitude) + _velocity);
				}

				Vector3 curve = - new Vector3(0, _velocity.y, _velocity.z);
				Debug.Log(curve);
				other.gameObject.GetComponent<Ball>()._curveForce = curve;

			}
			
		}
	}
}
