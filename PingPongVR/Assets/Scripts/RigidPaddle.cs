using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidPaddle : MonoBehaviour {

    public float curveDiff = 5;

    private Vector3 _previousPosition;
	private Vector3 _velocity;
    private Vector3 _curveVector;
    private Rigidbody paddleRB;

    // Use this for initialization
    void Start()
    {
        _previousPosition = transform.position;
        paddleRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _velocity = (transform.position - _previousPosition)/ Time.deltaTime;
        _previousPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
            Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();
            float dot = Vector3.Dot(ballRB.velocity, _velocity);
            if (Mathf.Abs(dot) < 3)
            {
                Vector3 curve = _velocity * -1;
			    Debug.Log(curve);
			    collision.collider.gameObject.GetComponent<Ball>().setCurveForce(curve);
            }
            
            /*
            float dp = Vector3.Dot(transform.forward, ballRB.velocity);
            //frontside
            if (dp < 0)
            {
                ballRB.velocity = transform.forward * (ballMagnitude) + (_velocity * .4f);
            }
            //backside
            else if (dp >= 0)
            {
                ballRB.velocity = -(transform.forward * (ballMagnitude) + (_velocity * .4f));
            }
            */
            //Boost scalar
            //ballRB.velocity = new Vector3(ballRB.velocity.x * 2.35f, ballRB.velocity.y * .22f, ballRB.velocity.z * .22f)

    }
}
