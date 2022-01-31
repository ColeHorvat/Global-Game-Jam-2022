using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTeleport : MonoBehaviour
{
    private PlayerController playerController;

    private PlayerGrab playerGrab;

    private bool isGettingBodyPos;

    private Vector2 linkedBodyPos;

    public GameObject linkedBody;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerGrab = GetComponent<PlayerGrab>();

    }

    // Update is called once per frame
    void Update()
    {
        if (linkedBody)
            linkedBodyPos = linkedBody.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Teleport") && playerController.isSoul)
        {
            

            transform.position = new Vector2(linkedBodyPos.x, linkedBodyPos.y + 1f);
            
            playerGrab.DestroyBody();
            
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
