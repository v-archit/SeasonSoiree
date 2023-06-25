using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] PlayerStateController playerController;
    [SerializeField] Vector2 entranceLocation;
    [SerializeField] Vector2 exitLocation;
    [SerializeField] Vector2 playerScale;

    public SetPopupText popupText;

    Vector2 targetLocation;

    // Start is called before the first frame update
    private void Start()
    {
        targetLocation = exitLocation;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject == playerController.gameObject)
        {
            Vector2 otherScale = other.gameObject.transform.localScale;
            if(playerController.getScale() * .0015f >= 0.1) 
            {
                StartCoroutine(PopupText());
                return;                                                                 // Return if player is too big to fit through pipe
            }                       
             
            other.gameObject.transform.position = targetLocation;

            // Flip teleport target location based on where the player enters the pipe
            if(targetLocation == exitLocation) { targetLocation = entranceLocation; }
            else { targetLocation = exitLocation; }
        }
    }

    IEnumerator PopupText()
    {
        popupText.ActivateText();
        yield return new WaitForSeconds(3.0f);
        popupText.DeactivateText();
    }
}
