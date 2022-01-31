using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    public bool isLifting;
    public Transform endPoint;
    public float moveSpeed;
    public Transform startPoint;
    public Vector2 newPosition;
    public bool isConstant;
    public bool isRepeating;
    public float startTimer;

    private BoxCollider2D platformCollider;
    // Start is called before the first frame update
    void Start()
    {
        isLifting = false;
        platformCollider = GetComponent<BoxCollider2D>();
        newPosition = startPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        startTimer -= Time.deltaTime;
        if (isLifting && startTimer < 0)
        {
            newPosition += new Vector2(moveSpeed * Time.deltaTime, moveSpeed * Time.deltaTime);
            newPosition.y = Mathf.Clamp(newPosition.y, startPoint.position.y, endPoint.position.y);
            newPosition.x = Mathf.Clamp(newPosition.x, startPoint.position.x, endPoint.position.x);

            transform.position = newPosition;
        }
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Body"))
        {
            startTimer = 0.5f;
            isLifting = true;
        }
    }
    
}
