using UnityEngine;

public class StickController : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool IsStuck { get; private set; }

    private Vector2 stickNormal;
    private Transform currentCircle;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsStuck) return;

        if (!other.CompareTag("Circle")) return;


        Vector2 dir = (transform.position - other.transform.position).normalized;
        stickNormal = dir;

        Stick(other.transform);
    }

    void Stick(Transform circle)
    {
        IsStuck = true;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = 0f;

        transform.SetParent(circle);


        CircleScore cs = circle.GetComponent<CircleScore>();
        if (cs != null && !cs.scored)
        {
            cs.scored = true;
            ScoreManager.Instance.AddScore();
        }
    }

    public Vector2 GetJumpDirection()
    {
        return stickNormal.normalized;
    }

    public void Unstick()
    {
        if (!IsStuck) return;

        IsStuck = false;
        currentCircle = null;

        transform.SetParent(null);
        rb.gravityScale = 1f;
    }
}
