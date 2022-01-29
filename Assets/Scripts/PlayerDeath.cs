using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    public GameObject playerOld;
    public PlayerController playerOldController;
    public GameObject playerPrefab;
    private GameObject playerNew;
    private Rigidbody2D rb2d;
    private bool isDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerOldController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Enter "Death" layer
        if (other.gameObject.layer == 6 && !isDead)
        {
            isDead = true;
            if (other.gameObject.CompareTag("Spikes"))
            {
                if (!playerOldController.isSoul)
                {
                    UnityEngine.Debug.Log("SPIKES");
                    Quaternion playerRot = playerOld.transform.rotation;

                    rb2d.velocity = new Vector2(0, 0);
                    rb2d.freezeRotation = false;
                    playerOld.transform.rotation = Quaternion.Euler(new Vector3(playerRot.x, playerRot.y, 90));
                    rb2d.freezeRotation = true;
                }

            }
            
            playerOld.GetComponent<PlayerController>().enabled = false;
            playerOld.layer = 3;

            playerNew = Instantiate(playerPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            playerNew.GetComponent<Rigidbody2D>().freezeRotation = true;
            playerNew.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }
}
