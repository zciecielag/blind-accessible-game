using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 5f;
    private float horizontal;
    private bool isFacingRight = true;
    public Joystick movementJoystick;
    public Rigidbody2D playerRigidBody2D;
    public Animator animator;
    public GameObject spawnPoint;
    private bool isMoving = true;
    public AudioSource audioSource;

    void Start()
    {
        if (spawnPoint != null && spawnPoint.activeSelf == true)
        {
            transform.position = spawnPoint.transform.position;
        }
    }


    void Update()
    {
        horizontal = movementJoystick.Direction.x;

        if (playerRigidBody2D.constraints == RigidbodyConstraints2D.FreezePosition)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        Flip();
    }

    private void FixedUpdate() 
    {
        if((movementJoystick.Horizontal != 0 || movementJoystick.Vertical != 0) && isMoving)
        {
            playerRigidBody2D.linearVelocity = new Vector2(movementJoystick.Direction.x * movementSpeed, movementJoystick.Direction.y * movementSpeed);
            animator.SetFloat("xVelocity", Math.Abs(playerRigidBody2D.linearVelocityX));
            animator.SetFloat("yVelocity", playerRigidBody2D.linearVelocityY);
            animator.SetBool("Moving", true);
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        } else
        {
            playerRigidBody2D.linearVelocity = Vector2.zero;
            animator.SetBool("Moving", false);
            movementJoystick.input = Vector2.zero;
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal > 0f || !isFacingRight && horizontal < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
