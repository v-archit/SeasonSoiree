using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private float jumpForce = 1;

    private Rigidbody2D rigidbodyRef;
    private Collider2D collRef;
    private SpriteRenderer rendRef;

    private bool canDoubleJump = true;

    AudioSource audioSource_Jump;
    private void Start()
    {
        rigidbodyRef = GetComponent<Rigidbody2D>();
        collRef = GetComponent<Collider2D>();
        rendRef = GetComponent<SpriteRenderer>();

        audioSource_Jump = GetComponent<AudioSource>();
    }

    private void Update()
    {
        var moveAxis = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveAxis, 0, 0) * Time.deltaTime * movementSpeed;

        // Rotate player on direction change; if moving left, flipX = true.
        if (!Mathf.Approximately(0, moveAxis)) { rendRef.flipX = moveAxis < 0; }

        bool grounded = IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            ApplyJumpForce(grounded);
        }
    }

    private void ApplyJumpForce(bool groundedJump)
    {
        // Debug.Log("Is grounded jump: " + groundedJump + " Can double jump: " + canDoubleJump);

        //If this is a grounded jump, or the player is allowed to double jump, do the jump code.
        if (groundedJump || canDoubleJump)
        {
            rigidbodyRef.velocity = new Vector2(rigidbodyRef.velocity.x, 0);
            rigidbodyRef.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            audioSource_Jump.Play();

            //If this was a double jump, the double jump has been used; set it to false.
            if (!groundedJump) { canDoubleJump = false; }
        }
    }

    /// <summary>
    /// Checks if the player is on the ground. If they are, note that they may double jump.
    /// </summary>
    /// <returns>Whether the player is on the ground or not.</returns>
    private bool IsGrounded()
    {
        //Start just a little bit above the player, so if the player is very slightly in the ground
        //  as rigidbodies sometimes are, then the ground can still be detected.
        //This ignores ceilings too, because CircleCast ignores colliders it starts inside of, if
        //  "queriesStartInColliders" is off.
        bool grounded = Physics2D.CircleCast
        (
            collRef.bounds.center + Vector3.up * 0.025f,
            collRef.bounds.extents.y,
            Vector2.down,
            0.05f
        );

        if (grounded) { canDoubleJump = true; }
        return grounded;
    }
}
