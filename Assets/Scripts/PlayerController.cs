using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private Camera m_camera;
    private Rigidbody2D rb;
    private new Collider2D collider;

    private Vector2 velocity;
    private float inputAxis;

    public float moveSpeed = 8f;
    public float maxJumpHeight = 5f;
    public float maxJumpTime = 1f;
    
    

    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f); // nhay la parablol nen thoi gian se chia 2
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f),2);

    public bool grouded { get; private set; }
    public bool jumping { get; private set; }
    public bool running => Mathf.Abs(velocity.x) > 0.25f || Mathf.Abs(inputAxis) > 0.25f;
    public bool sliding => (inputAxis > 0f && velocity.x < 0f) || (inputAxis < 0f && velocity.x > 0f); // dot ngot chuyen huong

    
    private void Awake()
    {
       
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }

        else
        {
            Instance = this;
        }

        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();  
        m_camera = Camera.main;
    }

    private void OnEnable()
    {
        rb.isKinematic = false;
        collider.enabled = true;
        velocity = Vector2.zero;
        jumping = false;
    }

    private void OnDisable()
    {
        rb.isKinematic = true;
        collider.enabled = false;
        velocity = Vector2.zero;
        jumping = false;
    }

    private void Update()
    {
        Move();
        grouded = rb.Raycast(Vector2.down);
        if( grouded )
        {
            GroundedMovement();
            
        }

        ApplyGravity();
       
    }



    private void Move()
    {
        //inputAxis = joystick.Horizontal();
       inputAxis = Input.GetAxisRaw("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime);

        
        if (rb.Raycast(Vector2.right * velocity.x))
        {
            velocity.x = 0f;
        }
        Flip();
    }

    //public void Jump()
    //{
    //    velocity.y = Mathf.Max(velocity.y, 0f);
    //    jumping = velocity.y > 0;
    //    if ( grouded )
    //    {
    //        velocity.y = jumpForce * 1.5f;
    //        jumping = true;
    //        AudioManager.instance.Play("Mariojump");
    //    }
    //    else
    //    {
    //        jumping = false;
    //    }
       
    //}
    private void GroundedMovement()
    {
        velocity.y = Mathf.Max(velocity.y, 0f);
        jumping = velocity.y > 0;
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpForce;
            jumping = true;
            AudioManager.instance.Play("Mariojump");
        }

    }
    private void ApplyGravity()
    {
        bool falling = velocity.y < 0 || !Input.GetButton("Jump"); // kiem tra mario dang roi
        float multiplier = falling ? 2f : 1f;
        velocity.y += gravity * multiplier * Time.deltaTime;

        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        position += velocity * Time.fixedDeltaTime;

        // Gioi han vi tri nguoi choi
        Vector2 leftEdge = m_camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = m_camera.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);

        rb.MovePosition(position);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (transform.DotTest(collision.transform, Vector2.down))
            {
                velocity.y = jumpForce / 2f;
                jumping = true;
              
            }
        }    
        if(collision.gameObject.layer != LayerMask.NameToLayer("PowerUp"))
        {
            if(transform.DotTest(collision.transform,Vector2.up))
            {
                velocity.y = 0f;
     
            }
        }
    }

    private void Flip()
    {
        if(velocity.x > 0f)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if(velocity.x < 0f)
        {
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
    }

    
}
