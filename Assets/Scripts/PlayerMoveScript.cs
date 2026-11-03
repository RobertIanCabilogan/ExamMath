using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMoveScript : MonoBehaviour
{
    public float speed = 5f;
    public float boostMult = 2f;
    public float rotationSpd = 90f;

    public float scale = 0.2f;
    public float minScale = 0.4f;
    public float maxScale = 3f;

    public float jumpHeight = 4f;

    private Rigidbody rb;

    private bool boost = false;
    private bool isGround = true;

    private float horizontal;
    private float vertical;
    private float rotationInput;

    private bool jumpInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // Read movement input
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Read rotation input
        rotationInput = 0f;

        if (Input.GetKey(KeyCode.X))
        {
            rotationInput = 1f;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            rotationInput = -1f;
        }

        // Read jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            jumpInput = true;
        }

        HandleScaling();
        HandleSpeed();
    }

    private void FixedUpdate()
    {
        Move();
        HandleRotation();
    }

    void Move()
    {
        Vector3 movement = new Vector3(
            horizontal,
            0f,
            vertical
        ).normalized;

        float currentSpeed = boost ? speed * boostMult : speed;

        Vector3 moveDirection = transform.TransformDirection(movement);

        Vector3 targetPosition = rb.position +
                                 moveDirection * currentSpeed * Time.fixedDeltaTime;

        rb.MovePosition(targetPosition);

        if (jumpInput)
        {
            rb.AddForce(
                Vector3.up * jumpHeight,
                ForceMode.Impulse
            );

            isGround = false;
            jumpInput = false;
        }
    }

    void HandleRotation()
    {
        if (rotationInput != 0f)
        {
            Quaternion rotation = Quaternion.Euler(
                0f,
                rotationInput * rotationSpd * Time.fixedDeltaTime,
                0f
            );

            rb.MoveRotation(rb.rotation * rotation);
        }
    }

    void HandleScaling()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            float newScale = transform.localScale.x + scale;

            if (newScale > maxScale)
            {
                newScale = minScale;
            }

            transform.localScale = Vector3.one * newScale;
        }
    }

    void HandleSpeed()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            boost = !boost;
        }
    }

    public float CurrentSpeed
    {
        get
        {
            return boost ? speed * boostMult : speed;
        }
    }

    public bool IsBoostActive
    {
        get
        {
            return boost;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}

