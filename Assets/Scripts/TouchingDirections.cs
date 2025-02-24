using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    private Rigidbody rb;
    private CapsuleCollider2D col;
    private Animator animator;
    private RaycastHit2D[] groundHits = new RaycastHit2D[5];
    private RaycastHit2D[] wallHits = new RaycastHit2D[5];
    private RaycastHit2D[] ceilingHits = new RaycastHit2D[5];
    public float groundDistance = 0.05f;
    public float wallDistance = 0.2f;
    public float ceilingDistance = 0.05f;
    public ContactFilter2D contactFilter;

    [SerializeField]
    private bool _isGrounded = false;

    public bool IsGrounded
    {
        get { return _isGrounded; }
        set
        {
            _isGrounded = value;
            animator.SetBool(AnimationStrings.isGrounded, value);
        }
    }

    [SerializeField]
    private bool _isOnWall = false;

    public bool IsOnWall
    {
        get { return _isOnWall; }
        set
        {
            _isOnWall = value;
            animator.SetBool(AnimationStrings.isOnWall, value);
        }
    }

    [SerializeField]
    private bool _isOnCeiling = false;

    public bool IsOnCeiling
    {
        get { return _isOnCeiling; }
        set
        {
            _isOnCeiling = value;
            animator.SetBool(AnimationStrings.isOnCeiling, value);
        }
    }

    private Vector2 WallCheckDirection => transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        IsGrounded = col.Cast(Vector2.down, contactFilter, groundHits, groundDistance) > 0;
        IsOnWall = col.Cast(WallCheckDirection, contactFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = col.Cast(Vector2.up, contactFilter, ceilingHits, ceilingDistance) > 0;
    }
}
