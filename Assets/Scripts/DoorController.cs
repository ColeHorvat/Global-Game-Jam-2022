using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    BoxCollider2D collider;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        if (gameObject.CompareTag("Invisible Platform"))
        {
            collider.enabled = true;
            spriteRenderer.color = new Color(1f,1f,1f,1f);
        }
        else
        {
            collider.enabled = false;
            spriteRenderer.color = new Color(1f,1f,1f,0.35f);
        }

    }

    public void CloseDoor()
    {
        if (gameObject.CompareTag("Invisible Platform"))
        {
            collider.enabled = false;
            spriteRenderer.color = new Color(1f,1f,1f,0.35f);
        }
        else
        {
            collider.enabled = true;
            spriteRenderer.color = new Color(1f,1f,1f,1f);
        }
    }
}
