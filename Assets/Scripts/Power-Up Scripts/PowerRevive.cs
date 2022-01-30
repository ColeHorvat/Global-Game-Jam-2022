using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PowerRevive : MonoBehaviour
{
    public GameObject playerG;
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    private TimerController timerController;
    private PlayerGrab playerGrab;

    public Material liveManMat;
    
    // Start is called before the first frame update
    void Start()
    {
        playerG = this.gameObject;
        playerController = playerG.GetComponent<PlayerController>();
        spriteRenderer = playerG.GetComponent<SpriteRenderer>();
        timerController = GetComponent<TimerController>();
        playerGrab = GetComponent<PlayerGrab>();

    }

    // Update is called once per frame
    void Update()
    {
        //UnityEngine.Debug.Log(playerController.isSoul);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Revive") && playerController.isSoul)
        {
            Revive();
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            other.gameObject.GetComponent<Light2D>().enabled = false;
        }
    }

    public void Revive()
    {
        playerController.isSoul = false;
        spriteRenderer.material = liveManMat;
        timerController.TimerStop();
        playerGrab.DestroyBody();
    }
}
