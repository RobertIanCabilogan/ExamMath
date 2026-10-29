using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [Header("Waypoints")]
    public Transform[] points;
    [Header("Speed")]
    public float speed = 3f;

    public bool isHazard = false;
    private int curentPoint = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (points.Length > 0)
        {
            transform.position = points[0].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (points.Length == 0)
        {
            return;
        }

        Transform target = points[curentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, target.position)<0.01f)
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
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isHazard)
        {
            collision.transform.SetParent(null);
        }
    }
}
