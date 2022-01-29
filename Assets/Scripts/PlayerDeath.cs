using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    public GameObject playerCurrent;
    public PlayerController playerCurrentController;
    public GameObject playerPrefab;
    private GameObject playerNew;
    private Rigidbody2D rb2d;
    private bool isDead;
    private CinemachineVirtualCamera playerCamera;
    private PowerRevive powerRevive;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrent = this.gameObject;
        isDead = false;
        rb2d = GetComponent<Rigidbody2D>();
        playerCurrentController = GetComponent<PlayerController>();
        playerCamera = CinemachineVirtualCamera.FindObjectOfType<CinemachineVirtualCamera>();
        powerRevive = GetComponent<PowerRevive>();
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
            if (other.gameObject.CompareTag("Spikes") && !playerCurrentController.isSoul)
            {
                Quaternion playerRot = playerCurrent.transform.rotation;

                rb2d.velocity = new Vector2(0, 0);
                rb2d.freezeRotation = false;
                playerCurrent.transform.rotation = Quaternion.Euler(new Vector3(playerRot.x, playerRot.y, 90));
                rb2d.freezeRotation = true;
                MakeNewPlayer();
            }

            if (playerCurrentController.isSoul)
            {
                KillSoul();
            }




        }
    }

    private void MakeNewPlayer()
    {
        playerNew = Instantiate(playerPrefab,
            new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);

        //New Player Components
        PlayerDeath playerNewDeath = playerNew.GetComponent<PlayerDeath>();
        PlayerGrab playerNewGrab = playerNew.GetComponent<PlayerGrab>();
        PowerRevive playerNewRevive = playerNew.GetComponent<PowerRevive>();
        Animator playerNewAnimator = playerNew.GetComponent<Animator>();
        Rigidbody2D playerNewRb2d = playerNew.GetComponent<Rigidbody2D>();
        SpriteRenderer playerNewSpriteRenderer = playerNew.GetComponent<SpriteRenderer>();
        PlayerController playerNewController = playerNew.GetComponent<PlayerController>();
        TimerController playerNewTimerController = playerNew.GetComponent<TimerController>();

        //Set Current Player Components
        playerCurrentController.enabled = false;
        Destroy(playerCurrent.GetComponent<PlayerGrab>());
        playerCurrent.GetComponent<PowerRevive>().enabled = false;
        playerCurrent.GetComponent<Animator>().enabled = false;
        playerCurrent.GetComponent<Rigidbody2D>().constraints =
            RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        playerCurrent.layer = 7; //Change to layermask later

        //Set New Player Components
        playerNewDeath.isDead = false;
        playerNewRb2d.freezeRotation = true;
        playerNewSpriteRenderer.color = Color.cyan;
        playerNewController.isSoul = true;
        playerNewTimerController.TimerStart();

        playerCamera.Follow = playerNew.transform;
    }

    public void KillSoul()
    {
        //Handle soul death (Go back to checkpoint)
        if (CheckpointController.lastCheckpointPos != Vector2.zero)
        {
            playerCurrent.transform.position = CheckpointController.lastCheckpointPos;
            powerRevive.Revive();
        }
        //Handle object reset
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
