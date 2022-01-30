using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private AudioSource source;

    private PlayerController playerC;

    public AudioClip step;
    public AudioClip[] jumpSounds;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        playerC = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Step()
    {
        source.PlayOneShot(step);
    }

    public void Jump()
    {
        source.PlayOneShot(jumpSounds[Random.Range(0,jumpSounds.Length-1)]);
        Step();
    }
}
