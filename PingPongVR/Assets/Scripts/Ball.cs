using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private GameObject _lastObjectHit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		setLastHitObject(other.gameObject);
	}

	void OnCollisionEnter(Collision collision)
	{
		setLastHitObject(collision.collider.gameObject);
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
