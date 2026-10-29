using UnityEngine;

public class PlayerMovement : MonoBehaviour
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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Move();
        HandleRotation();
        HandleScaling();
        HandleSpeed();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 Movement = new Vector3(x, 0f, z).normalized;

        float currentSpeed = boost ? speed * boostMult : speed;

        transform.Translate(Movement *  currentSpeed * Time.deltaTime, Space.Self);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGround = false;
        }
    }

    void HandleRotation()
    {
        if (Input.GetKey(KeyCode.X))
        {
            transform.Rotate(Vector3.up * rotationSpd * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(Vector3.up * -rotationSpd * Time.deltaTime, Space.World);
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
            return boost ? speed  * boostMult : speed;
        }
    }

    public bool IsBoostActive
    {
        get { return boost; }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}

