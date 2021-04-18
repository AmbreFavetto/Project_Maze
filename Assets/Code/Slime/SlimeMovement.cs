
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{

    public float moveSpeed;

    public Rigidbody2D rb;
    
    public Animator animator;
    public SpriteRenderer slime;

    private Vector3 velocity = Vector3.zero;

   

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        MovePlayerHorizontal(horizontalMovement);
        MovePlayerVertical(verticalMovement);

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x + rb.velocity.y);
        animator.SetFloat("Speed", characterVelocity);
    }

    void MovePlayerHorizontal(float _horizontalMovement)
    {
        Vector3 targetHorizontalVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetHorizontalVelocity, ref velocity, .05f);
    }

    void MovePlayerVertical(float _verticalMovement)
    {
        Vector3 targetVerticalVelocity = new Vector2(rb.velocity.x, _verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVerticalVelocity, ref velocity, .05f);  
    }

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            slime.flipX = false;
        } else if(_velocity < -0.1f)
        {
            slime.flipX = true;
        }
    }
}
