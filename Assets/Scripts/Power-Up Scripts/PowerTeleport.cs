using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTeleport : MonoBehaviour
{
    private PlayerController playerController;

    private PlayerGrab playerGrab;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerGrab = GetComponent<PlayerGrab>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Teleport") && playerController.isSoul)
        {
            Vector2 lastBodyPos = PlayerDeath.lastBodyPos;

            transform.position = new Vector2(lastBodyPos.x, lastBodyPos.y + 0.1f);
            
            playerGrab.DestroyBody();
        }
    }
}
