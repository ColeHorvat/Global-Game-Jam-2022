using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip hoverOver;
    public AudioClip clickButton;

    private bool exitRoutine = false;
    private bool playRoutine = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (exitRoutine)
            StartCoroutine(ExitGame());

        if (playRoutine)
            StartCoroutine(StartGame());
    }


    public void HoverOver()
    {
        audioSource.PlayOneShot(hoverOver);
    }

    public void ClickButton()
    {
        audioSource.PlayOneShot(clickButton);
    }

    public void QuitGame()
    {
        exitRoutine = true;
    }

    public void PlayGame()
    {
        playRoutine = true;
    }

    IEnumerator StartGame()
    {

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(1);

    }

    IEnumerator ExitGame()
    {

        yield return new WaitForSeconds(1);

        Application.Quit();

    }
}
