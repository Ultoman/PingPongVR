using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float _maxSpeed = 10f;
	public static float _wallForce = 1;
	private Vector3 _curveForce = Vector3.zero;

	private GameObject _lastObjectHit;
	private GameObject _lastPaddleHit;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		_lastObjectHit = null;
		_lastPaddleHit = null;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(rb.velocity.magnitude > _maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * _maxSpeed;
        }
	}

	void FixedUpdate()
	{
		if (_curveForce.magnitude > 1)
		{
			rb.AddForce(_curveForce);
		}
	}

	/*
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("asdf");
		setLastHitObject(other.gameObject);
	}
	*/

	void OnCollisionEnter(Collision collision)
	{
		setLastHitObject(collision.collider.gameObject);
		if (collision.collider.tag == "Paddle")
		{
			setLastHitPaddle(collision.collider.gameObject);
		}
		if (collision.collider.tag == "Wall")
		{
			_curveForce *= .5f;//= Vector3.zero;
		}

	}

	void OnCollisionStay(Collision collision)
	{
		
	}

	void OnCollisionExit(Collision collision)
	{
		if (_lastObjectHit == _lastPaddleHit){
			Debug.Log("Collision off");
			Physics.IgnoreCollision(_lastPaddleHit.GetComponent<Collider>(), this.GetComponent<Collider>(), true);
		}
		else
		{
			Debug.Log("Collision on");
			if (_lastPaddleHit != null)
				Physics.IgnoreCollision(_lastPaddleHit.GetComponent<Collider>(), this.GetComponent<Collider>(), false);
		}
		
	}

	private void setLastHitObject(GameObject go)
	{
		_lastObjectHit = go;
	}

	private void setLastHitPaddle(GameObject go)
	{
		_lastPaddleHit = go;
	}

	public GameObject getLastHitObject()
	{
		return _lastObjectHit;
	}

	public void setCurveForce(Vector3 curveForce)
	{
		_curveForce = curveForce;
	}
}
