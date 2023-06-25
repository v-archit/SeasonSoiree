using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPopupText : MonoBehaviour
{
    public string sentence;
    public GameObject infoBox;
    public bool timed_message;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !timed_message)
        {
            ActivateText();
        }
    }

    public void ActivateText()
    {
        infoBox.SetActive(true);
        infoBox.GetComponentInChildren<Text>().text = sentence;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !timed_message)
        {
            DeactivateText();
        }
    }

    public void DeactivateText()
    {
        infoBox.SetActive(false);
    }
}
