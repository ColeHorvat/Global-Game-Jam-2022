using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    
    const float TIMER_MAX = 10f;

    public float timer;

    public bool timerGoing;

    private PlayerDeath playerDeath;
    // Start is called before the first frame update
    void Start()
    {
        playerDeath = GetComponent<PlayerDeath>();
        timer = TIMER_MAX;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerGoing)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                //Timer is functional
                playerDeath.KillSoul();
            }
        }
    }

    public void TimerStart()
    {
        timer = TIMER_MAX;
        timerGoing = true;
        
        //Show timer on screen
    }

    public void TimerStop()
    {
        timer = TIMER_MAX;
        timerGoing = false;
        
        //Stop showing timer on screen
    }

    public void TimerReset()
    {
        timer = TIMER_MAX;
        timerGoing = true;
    }
}
