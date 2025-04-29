using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BatMovement : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1);
        Vector3 newPos = Vector3.Lerp(pointA, pointB, t);
        transform.position = newPos;

        // Going towards B (moving forward) → back turned
        // Going towards A (turning back) → face turned

        bool goingToA = Mathf.PingPong(Time.time * speed, 2f) > 1f;

        // Face/back direction: face when facing A, back when facing B
        spriteRenderer.flipX = !goingToA;
    }
}