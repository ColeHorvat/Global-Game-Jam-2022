using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal; //2019 VERSIONS

public class CheckpointController : MonoBehaviour
{
    public static Vector2 lastCheckpointPos;

    private PowerRevive revive;
    public LayerMask bodyLayer;

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
            //Handle going over checkpoint
            
//            Debug.Log(isActivated);
            lastCheckpointPos = other.transform.position;
            
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            other.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            other.gameObject.GetComponentInChildren<Light2D>().color = new Color(1,0.5f,0);
            revive.Revive();
            
        }
    }

    public void ResetObjects()
    {
        GameObject[] activeBodies = GameObject.FindGameObjectsWithTag("Body");
        GameObject[] revives = GameObject.FindGameObjectsWithTag("Revive");
        GameObject[] teleports = GameObject.FindGameObjectsWithTag("Teleport");
        GameObject[] timerResets = GameObject.FindGameObjectsWithTag("TimerReset");
        GameObject[] movingPlatforms = GameObject.FindGameObjectsWithTag("Moving Platform");
        
        foreach (var body in activeBodies)
            Destroy(body);

        foreach (var platform in movingPlatforms)
        {
            //Debug.Log(platform);
            MovingPlatformController platformController = platform.GetComponent<MovingPlatformController>();
            platformController.isLifting = false;
            platform.transform.position = platformController.startPoint.position;
            platformController.newPosition = platformController.startPoint.position;
        }

        EnableObjects(revives);
        EnableObjects(teleports);
        EnableObjects(timerResets);
        
    }

    private void EnableObjects(GameObject[] objectArray)
    {
        foreach (var objectInstance in objectArray)
        {
            objectInstance.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            objectInstance.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            objectInstance.gameObject.GetComponent<Light2D>().enabled = true;
        }
    }


    
}
