using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static Vector2 lastCheckpointPos;

    private PowerRevive revive;

    private bool isActivated;
    // Start is called before the first frame update
    void Start()
    {
        revive = GetComponent<PowerRevive>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Checkpoint") && !isActivated)
        {
            Debug.Log(isActivated);
            lastCheckpointPos = other.transform.position;
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            revive.Revive();
            
        }
    }
}
