using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool isPressed;
    private BoxCollider2D collider;
    public GameObject[] activationObjects;
    public Sprite pressedSprite;
    public Sprite unpressedSprite;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = pressedSprite;
            foreach (var activationObject in activationObjects)
            {
                DoorController doorController = activationObject.GetComponent<DoorController>();
                doorController.OpenDoor();
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = unpressedSprite;
            foreach (var activationObject in activationObjects)
            {
                DoorController doorController = activationObject.GetComponent<DoorController>();
                doorController.CloseDoor();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Body") || other.gameObject.CompareTag("Player"))
        {
            isPressed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Body") || other.gameObject.CompareTag("Player"))
        {
            isPressed = false;
        }
    }
}
