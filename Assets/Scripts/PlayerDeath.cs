using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    public GameObject playerOld;
    public PlayerController playerOldController;
    public GameObject playerPrefab;
    private GameObject playerNew;
    private Rigidbody2D rb2d;
    private bool isDead;
    private CinemachineVirtualCamera playerCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        rb2d = GetComponent<Rigidbody2D>();
        playerOldController = GetComponent<PlayerController>();
        playerCamera = CinemachineVirtualCamera.FindObjectOfType<CinemachineVirtualCamera>();
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
            if (other.gameObject.CompareTag("Spikes") && !playerOldController.isSoul)
            {

                UnityEngine.Debug.Log("SPIKES");
                Quaternion playerRot = playerOld.transform.rotation;

                rb2d.velocity = new Vector2(0, 0);
                rb2d.freezeRotation = false;
                playerOld.transform.rotation = Quaternion.Euler(new Vector3(playerRot.x, playerRot.y, 90));
                rb2d.freezeRotation = true;
            }

            if (playerOldController.isSoul)
            {
                //Handle soul death (Go back to checkpoint)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            playerNew = Instantiate(playerPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            
            playerOldController.enabled = false;
            Destroy(playerOld.GetComponent<PlayerGrab>());
            playerOld.GetComponent<PowerRevive>().enabled = false;
            playerOld.GetComponent<Animator>().enabled = false;
            playerOld.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            playerOld.layer = 7; //Change to layermask later
            
            playerNew.GetComponent<PlayerDeath>().isDead = false;
            playerNew.GetComponent<Rigidbody2D>().freezeRotation = true;
            playerNew.GetComponent<SpriteRenderer>().color = Color.cyan;
            playerNew.GetComponent<PlayerController>().isSoul = true;

            playerCamera.Follow = playerNew.transform;
        }
    }
}
