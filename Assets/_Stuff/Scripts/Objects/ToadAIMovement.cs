using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ToadAIMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float accelerationTime = 2f;
    public float maxSpeed = 3f;
    private Vector2 movement;
    private float timeLeft;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += accelerationTime;
        }
    }
 
    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }
}
