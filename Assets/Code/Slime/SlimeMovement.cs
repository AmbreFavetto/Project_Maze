
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 dir;

    void FixedUpdate()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
    }
}
