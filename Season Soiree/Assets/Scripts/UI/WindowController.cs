using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField] float openPositionY;
    [SerializeField] float closedPositionY;
    [SerializeField] float speed = 1f;

    SeasonManager seasonManager;
    Rigidbody2D rigidbodyRef;

    // Start is called before the first frame update
    void Start()
    {
        seasonManager = FindObjectOfType<SeasonManager>();
        rigidbodyRef = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(seasonManager.CurrentSeason == SeasonType.Summer && transform.position.y < openPositionY) 
        { 
            // Allows movement but stops the platfrom from spinning when the player is on it
            rigidbodyRef.constraints = RigidbodyConstraints2D.None;
            rigidbodyRef.constraints = RigidbodyConstraints2D.FreezeRotation;

            Vector3 targetPosition = new Vector3(transform.position.x, openPositionY, transform.position.z);
            rigidbodyRef.velocity = (targetPosition - transform.position) * speed;
        }
        else if(seasonManager.CurrentSeason == SeasonType.Winter && transform.position.y > closedPositionY)
        {
            // Allows movement but stops the platfrom from spinning when the player is on it
            rigidbodyRef.constraints = RigidbodyConstraints2D.None;                     
            rigidbodyRef.constraints = RigidbodyConstraints2D.FreezeRotation;

            Vector3 targetPosition = new Vector3(transform.position.x, closedPositionY, transform.position.z);
            rigidbodyRef.velocity = (targetPosition - transform.position) * speed;
        }
        else { rigidbodyRef.constraints = RigidbodyConstraints2D.FreezeAll; }   // Prevents unwanted movement
    }
}
