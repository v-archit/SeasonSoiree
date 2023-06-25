using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthChanger : MonoBehaviour
{
    public PlayerStateController playerController;
    [SerializeField] float healthDelta;
    [SerializeField] float scaleDelta;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Standing On Lantern");
            if (!playerController)
            {
                playerController = collision.gameObject.GetComponent<PlayerStateController>();
            }
            playerController.ChangeHealth(healthDelta, scaleDelta);
        }
    }
}
