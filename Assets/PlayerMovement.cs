using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 8f;

    private Rigidbody2D rb;
    private StickController stick;

    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stick = GetComponent<StickController>();
    }

    void Update()
    {
        if (GameManager.Instance == null)
            return;

        if (!GameManager.Instance.GameStarted)
            return;

        if (GameManager.Instance.IsPaused)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("PLAYER INPUT");
            if (stick != null && stick.IsStuck)
            {
                Vector2 raw = stick.GetJumpDirection();

                Vector2 jumpDir = new Vector2(raw.x * 0.5f, Mathf.Max(raw.y, 0.7f)).normalized;

                stick.Unstick();

                rb.linearVelocity = Vector2.zero;
                rb.AddForce(jumpDir * jumpForce, ForceMode2D.Impulse);
            }
            else if (isGrounded)
            {
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * 10f;
            Debug.Log("FORCED VELOCITY");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = false;
    }
}