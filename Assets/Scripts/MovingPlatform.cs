using UnityEngine;
using UnityEngine.Rendering;

public class MovingPlatform : MonoBehaviour
{

    [Header("Waypoints")]
    public Transform[] points;
    [Header("Speed")]
    public float speed = 3f;

    public bool isHazard = false;
    private int curentPoint = 0;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
       rb = GetComponent<Rigidbody>();

        rb.isKinematic = true;

        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Start()
    {
        if (points.Length > 0)
        {
            rb.position = points[0].position;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (points.Length == 0)
        {
            return;
        }

        Transform target = points[curentPoint];

        Vector3 newPos = Vector3.MoveTowards(rb.position, target.position, speed * Time.fixedDeltaTime);

        rb.MovePosition(newPos);
        if(Vector3.Distance(newPos, target.position)<0.01f)
        {
            curentPoint++;

            if (curentPoint >= points.Length)
            {
                curentPoint = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isHazard)
        {
            collision.transform.SetParent(transform, true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isHazard)
        {
            collision.transform.SetParent(null, true);
        }
    }
}
