using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject uI;

    public void OnStart()
    {
        Debug.Log("Clicked Start");
        Time.timeScale = 1;
        AudioSource[] audioSources = GameObject.FindObjectsOfType<AudioSource>();
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].name == "AudioSource_Click")
            {
                audioSources[i].Play();
            }
        }
        SceneManager.LoadScene("HouseArea");
    }

    public void OnResume()
    {
        Debug.Log("Clicked Resume");
        AudioSource[] audioSources = GameObject.FindObjectsOfType<AudioSource>();
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].name == "AudioSource_Click")
            {
                audioSources[i].Play();
            }
        }
        uI.GetComponent<UIManager>().ButtonPress("resume");
    }

    public void OnOptions()
    {
        Debug.Log("Clicked Options");
        AudioSource[] audioSources = GameObject.FindObjectsOfType<AudioSource>();
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].name == "AudioSource_Click")
            {
                audioSources[i].Play();
            }
        }
        uI.GetComponent<UIManager>().ButtonPress("options");
    }

    public void OnBack()
    {
        Debug.Log("Clicked Back");
        AudioSource[] audioSources = GameObject.FindObjectsOfType<AudioSource>();
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].name == "AudioSource_Click")
            {
                audioSources[i].Play();
            }
        }
        uI.GetComponent<UIManager>().ButtonPress("back");
    }

    public void OnCreedits()
    {
        Debug.Log("Clicked Credits");
        AudioSource[] audioSources = GameObject.FindObjectsOfType<AudioSource>();
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].name == "AudioSource_Click")
            {
                audioSources[i].Play();
            }
        }
        SceneManager.LoadScene("Credits");
    }

    public void OnMainMenu()
    {
        Debug.Log("Clicked Main Menu");
        AudioSource[] audioSources = GameObject.FindObjectsOfType<AudioSource>();
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].name == "AudioSource_Click")
            {
                audioSources[i].Play();
            }
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void OnQuit()
    {
        Debug.Log("Clicked Quit");
        AudioSource[] audioSources = GameObject.FindObjectsOfType<AudioSource>();
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].name == "AudioSource_Click")
            {
                audioSources[i].Play();
            }
        }
        Application.Quit();
    }

    public void OnReset()
    {
        Debug.Log("Clicked Reset");
        AudioSource[] audioSources = GameObject.FindObjectsOfType<AudioSource>();
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].name == "AudioSource_Click")
            {
                audioSources[i].Play();
            }
        }
        SceneManager.LoadScene("HouseArea");
    }

    public void ToggleMusic()
    {
        AudioSource[] audioSources = GameObject.FindObjectsOfType<AudioSource>();
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].name == "AudioSource_Background")
            {
                if (GetComponent<Toggle>().isOn == true)
                {
                    audioSources[i].Play();
                }
                else
                {
                    audioSources[i].Stop();
                }
            }
        }
    }

   
}
