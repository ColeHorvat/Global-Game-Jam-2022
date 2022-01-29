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
    private bool isDead;
    
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
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
            
            UnityEngine.Debug.Log(this.gameObject);
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

            playerNew = Instantiate(playerPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            playerNew.GetComponent<PlayerDeath>().isDead = false;
            playerNew.GetComponent<Rigidbody2D>().freezeRotation = true;
            playerNew.GetComponent<SpriteRenderer>().color = Color.cyan;
            playerNew.GetComponent<PlayerController>().enabled = true;
            playerNew.GetComponent<PlayerController>().isSoul = true;
            
            playerNew.layer = 0;
        }
    }
}
