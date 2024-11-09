using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 5f;
    private float horizontal;
    private bool isFacingRight = true;
    [SerializeField] private Joystick movementJoystick;
    [SerializeField] private Rigidbody2D rigidbody2D;

    void Start()
    {
        
    }


    void Update()
    {
        horizontal = movementJoystick.Direction.x;

        Flip();
    }

    private void FixedUpdate() 
    {
        if(movementJoystick.Direction.y != 0 || movementJoystick.Direction.x != 0)
        {
            rigidbody2D.linearVelocity = new Vector2(movementJoystick.Direction.x * movementSpeed, movementJoystick.Direction.y * movementSpeed);
        } else
        {
            rigidbody2D.linearVelocity = Vector2.zero;
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
