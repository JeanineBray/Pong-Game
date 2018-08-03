using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceTowardPlayer : MonoBehaviour
{
    private float bias = 0.5f;
    private Vector3 initialVelocity;
    private Transform playerTransform;
    private float bounceVelocity = 10f;
    private Vector3 lastFrameVelocity;
    private Rigidbody2D rb2d;

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = initialVelocity;
    }

    private void Update()
    {
        lastFrameVelocity = rb2d.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision.contacts[0].normal);
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var bounceDirection = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
        var directionToPlayer = playerTransform.position - transform.position;

        var direction = Vector3.Lerp(bounceDirection, directionToPlayer, bias);

        Debug.Log("Out Direction: " + direction);
        rb2d.velocity = direction * bounceVelocity;
    }
}
