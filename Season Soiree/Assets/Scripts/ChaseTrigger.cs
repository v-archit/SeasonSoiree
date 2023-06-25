using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTrigger : MonoBehaviour
{
    /// <summary>
    /// Fired when a player enters this trigger.
    /// <br/><i>Parameter: The player that entered.</i>
    /// </summary>
    public Action<GameObject> playerEntered;
    /// <summary>
    /// Fired when a player exits this trigger.
    /// <br/><i>Parameter: The player that exited.</i>
    /// </summary>
    public Action<GameObject> playerExited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InvokeIfPlayer(playerEntered, collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InvokeIfPlayer(playerExited, collision.gameObject);
    }

    private void InvokeIfPlayer(Action<GameObject> thingToInvoke, GameObject potentialPlayer)
    {
        if (potentialPlayer.CompareTag("Player"))
        {
            thingToInvoke?.Invoke(potentialPlayer);
        }
    }
}