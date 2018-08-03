using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncer : MonoBehaviour
{
    private Vector3 initialVelocity;
    private float minVelocity = 10f;
    private Vector3 lastFrameVelocity;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = initialVelocity;
	}
	
	// Update is called once per frame
	void Update ()
    {
        lastFrameVelocity = rb2d.velocity;
	}

    void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        Debug.Log("Out Direction: " + direction);
        rb2d.velocity = direction * Mathf.Max(speed, minVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bounce(collision.contacts[0].normal);
    }
}
