using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player;

    public float moveSpeed = 10.0f;
    public float jumpForce = 5.0f;
    public float gravity = 10.0f;

    public int keys;

    // jump function
    private Vector3 jump;
    public int jumpCount = 2;
    //private bool canDoubleJump = false; //Make the player able to double jump
    private Rigidbody rg;
    // private float disToGround = 1.0f;
    public LayerMask GroundLayerMask;
    private float inputX;
    private bool isGrounded = false;
    public bool isJumping = false;


    // Flip
    private bool isFacingRight = true;

    // Fire
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Launch the reed
    public GameObject reedPrefab;
    public int reed_count = 1;


    // Animation
    public Animator animator;

    void Awake()
    {
        player = this;
    }

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rg.velocity = new Vector3(inputX * moveSpeed, rg.velocity.y, 0);
        Physics.gravity = new Vector3(0, gravity, 0);
        // isGrounded = Physics.Raycast(transform.position, Vector3.down, disToGround); old check ground method
        // isGrounded = Physics.OverlapCircle(groundCheck.position, 0.1f, ground);
        isGrounded = GroundCheck();
        // Debug.Log(isGrounded);
        if(isGrounded)
        {
            animator.SetBool("IsJumping", false);
            jumpCount = 1;
        } else {
            animator.SetBool("IsJumping", true);
        }


        GameObject go = GameObject.Find("reed");
        // 
        if(go !== null)
        {
            Debug.Log('Find!');
        }
    }

    private bool GroundCheck()
    {
        float extraHeightText = 2;
        bool raycastHit = Physics.Raycast(rg.position, Vector3.down, extraHeightText, GroundLayerMask);
        Debug.DrawLine(rg.position, new Vector3(rg.position.x, rg.position.y-2, rg.position.z), Color.red);
        return raycastHit;
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        inputX = value.ReadValue<Vector2>().x;
        animator.SetFloat("Speed", Mathf.Abs(inputX));
        // Flip the character
        if (inputX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (inputX < 0 && isFacingRight)
        {
            Flip();
        }
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if(value.performed && jumpCount > 0)
        {
            Jump();
            jumpCount -= 1;
        }
    }

    private void Jump()
    {
        rg.velocity = new Vector3(rg.velocity.x, jumpForce, 0);
    }

    public void OnFire(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            Shoot();
        }
    }

    
    // Launch the reed platform
    public void LaunchReed(InputAction.CallbackContext value)
    {
        if(value.performed && reed_count > 0)
        {
            Instantiate(reedPrefab, firePoint.position, firePoint.rotation);
            reed_count -= 1;
        }
    }

    private void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }


    // This flip method cannot be applied to a non-centered 2d character properly.
    private void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
