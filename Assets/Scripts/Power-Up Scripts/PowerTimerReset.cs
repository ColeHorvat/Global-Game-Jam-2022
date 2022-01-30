using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTimerReset : MonoBehaviour
{
    public GameObject playerG;
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;

    private TimerController timerController;
    // Start is called before the first frame update
    void Start()
    {
        playerG = this.gameObject;
        playerController = playerG.GetComponent<PlayerController>();
        spriteRenderer = playerG.GetComponent<SpriteRenderer>();
        timerController = GetComponent<TimerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TimerReset") && playerController.isSoul)
        {
            timerController.TimerReset();
            Destroy(other.gameObject);
        }
    }
}
