using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjs;
    public float checkRadius;

    private float moveX;
    private bool isJump;
    private Animator animator;
    private Rigidbody2D rb;
    private bool facingRight;
    private bool isGround;
    private Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float MovementSmoothing = .01f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ProcessInputs();
        Animate();
    }
    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjs);
        Move();
    }

    private void ProcessInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isJump = true;
        }
    }
    
    private void Move()
    {
        Vector3 targetV = new Vector2((moveX * Time.fixedDeltaTime) * 10f, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetV, ref m_Velocity, MovementSmoothing);

        if (isJump)
        {
            Debug.Log("here");
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isJump = false;

        if (moveX > 0 || moveX < 0)
        {
            animator.SetFloat("Speed", 1);           
        }
        else if (isGround)
        {
            animator.SetFloat("Speed", 0);
            rb.velocity = Vector3.zero;
        }
    }

    private void Animate()
    {
        if (moveX < 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveX > 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
