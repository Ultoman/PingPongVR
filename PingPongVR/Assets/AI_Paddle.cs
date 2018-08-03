using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Paddle : MonoBehaviour
{
    public Ball target;
    public float lerpSpeed = .5f;
    public Vector3 startPos;

    private bool shouldFollow = false;

	// Use this for initialization
	void Start ()
    {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(target.getLastHitObject().tag == "Paddle")
        {
            shouldFollow = true;
        }


        Vector3 lerpPos;
        if(shouldFollow)
        {
            lerpPos = target.gameObject.transform.position;
        }
        else
        {
            lerpPos = startPos;
        }


        lerpPos.x = transform.position.x;

        transform.position = Vector3.Lerp(transform.position, lerpPos, lerpSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            shouldFollow = false;
        }
    }
}
