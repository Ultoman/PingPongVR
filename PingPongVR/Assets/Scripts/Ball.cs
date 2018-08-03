using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float _maxSpeed = 10f;
	public Vector3 _curveForce = Vector3.zero;

	private GameObject _lastObjectHit;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
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
		if (_curveForce != Vector3.zero)
		{
			rb.AddForce(_curveForce);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		setLastHitObject(other.gameObject);
	}

	void OnCollisionEnter(Collision collision)
	{
		setLastHitObject(collision.collider.gameObject);
		if (collision.collider.gameObject.tag == "Wall"){
			_curveForce = Vector3.zero;
		}

	}

	private void setLastHitObject(GameObject go)
	{
		_lastObjectHit = go;
	}

	public GameObject getLastHitObject()
	{
		return _lastObjectHit;
	}
}
