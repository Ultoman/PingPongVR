using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidPaddle : MonoBehaviour {

    private Vector3 _previousPosition;
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

    }

    void OnCollisionEnter(Collision collision)
    {
            
        Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();
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
        ballRB.velocity = new Vector3(ballRB.velocity.x * 2.35f, ballRB.velocity.y * .22f, ballRB.velocity.z * .22f);
        //ballRB.velocity = new Vector3(transform.forward * ballMagnitude * 2.35f, ballRB.velocity.y * .22f, ballRB.velocity.z * .22f);

        //Vector3 curve = (-new Vector3(0, _velocity.y, _velocity.z)) * 2.8f;
        //collision.gameObject.GetComponent<Ball>()._curveForce = curve;


    }
}
