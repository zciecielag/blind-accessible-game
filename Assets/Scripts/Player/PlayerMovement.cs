using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float movementSpeed = 5f;
    private float horizontal;
    private float jumpPower = 16f;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rigidbody2D;

    void Start()
    {
        
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();
    }

    private void FixedUpdate() 
    {
        rigidbody2D.linearVelocity = new Vector2(horizontal * movementSpeed, rigidbody2D.linearVelocityY);
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
