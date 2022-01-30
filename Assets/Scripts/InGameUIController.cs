using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour
{
    public TimerController timeCon;

    public Slider soulSlider;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeCon != null)
        {
            soulSlider.value = timeCon.timer/timeCon.TIMER_MAX;
        }
    }
}
