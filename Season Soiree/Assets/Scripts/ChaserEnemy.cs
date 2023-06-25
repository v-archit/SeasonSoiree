using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An enemy that will chase players that enter a supplied <see cref="ChaseTrigger"/>, and
/// return to its original position when those players exit.
/// </summary>
public class ChaserEnemy : MonoBehaviour
{
    [Tooltip("This enemy will chase the player until they exit this trigger.")]
    [SerializeField] private ChaseTrigger chaseTrigger;
    [Tooltip("If this enemy can fly, it may move up and down while chasing, as opposed to just left and right.")]
    [SerializeField] private bool flying;
    [Tooltip("Measured in units moved per second.")]
    [SerializeField] private float moveSpeed;
    [Tooltip("How long to wait before returning home, when not in chase mode.")]
    [SerializeField] private float returnHomeDelay;

    private SpriteRenderer rendRef;
    private Collider2D collRef;
    private GameObject playerRef;
    private Vector3 homePos;
    private Coroutine returnDelayCorout;

    private void Start()
    {
        if (!chaseTrigger)
        {
            Debug.LogError($"{gameObject.name} was not given a chase trigger; it will never " +
                $"detect the player, and forever stay at its home position.");
        }

        rendRef = GetComponent<SpriteRenderer>();
        collRef = GetComponent<Collider2D>();

        if (flying)
        {
            homePos = transform.position;
        }
        else
        {
            //Raycast down and make home equal to the first hit on solid ground plus this enemy's "radius";
            //in other words, where it should come to rest once gravity does its work
            RaycastHit2D hit = Physics2D.Raycast(collRef.bounds.center, Vector2.down);
            if (hit.collider != null)
            {
                homePos = hit.point + Vector2.up * (collRef.bounds.extents.y + 0.1f);
            }
            else
            {
                homePos = transform.position;
            }
        }
    }

    private void OnEnable()
    {
        chaseTrigger.playerEntered += OnPlayerEntered;
        chaseTrigger.playerExited += OnPlayerExited;
    }
    private void OnDisable()
    {
        chaseTrigger.playerEntered -= OnPlayerEntered;
        chaseTrigger.playerExited -= OnPlayerExited;
    }

    private void OnPlayerEntered(GameObject player) { playerRef = player; }
    private void OnPlayerExited(GameObject player)
    {
        playerRef = null;
        //Run a coroutine that will nullify this reference to it when it finishes, effectively making it a
        //timer; if this corout is null, it either hasn't run, has finished, or has stopped early.
        returnDelayCorout = Coroutilities.DoAfterDelay(this, () => returnDelayCorout = null, returnHomeDelay);
    }

    private void Update()
    {
        //If we've got a player ref, we should be in chase mode.
        if (playerRef)
        {
            //Stop the return delay prematurely, because we're not returning anymore, we're chasing!
            Coroutilities.TryStopCoroutine(this, returnDelayCorout);

            //If this enemy flies, it should beeline to the player whether they're up/down/neither.
            //  If it doesn't fly, it should use it's own Y pos as a target to stay at the same height.
            Transform yTarget = flying ? playerRef.transform : transform;

            MoveTowardTarget(new Vector2(playerRef.transform.position.x, yTarget.position.y));
        }
        //Once the return delay is over, return home.
        else if (returnDelayCorout == null)
        {
            MoveTowardTarget(homePos);
        }
    }

    private void MoveTowardTarget(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        float targetDot = Vector2.Dot(target - (Vector2)transform.position, Vector2.right);

        //If targetDot is nearly perpendicular to global right, target is basically directly above/below; facing
        //direction is negligible
        if (targetDot < -0.1f) { rendRef.flipX = true; }
        else if (targetDot > 0.1f) { rendRef.flipX = false; }
    }

    // This method is to allow the chasing of something other than the player
    public void SetTarget(GameObject target) { playerRef = target; }

    //private void OnCollisionEnter2D(Collision2D other) 
    //{
    //    if(other.gameObject.CompareTag("Apple")) 
    //    { 
    //        Debug.Log("Enemy hit by apple");
    //        gameObject.SetActive(false); }        
    //}

    public Vector3 GetHomePosition() { return homePos; }
}
