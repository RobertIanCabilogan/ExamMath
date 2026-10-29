using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    [Header("Patrol Settings")]
    public Transform[] points;
    public float speed = 3f;

    private int currentPoint = 0;
    private int direction = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (points.Length >= 2)
        {
            transform.position = points[0].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (points.Length < 2)
        {
            return;
        }

        Transform target = points[currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            currentPoint += direction;

            if (currentPoint >= points.Length - 1)
            {
                direction = -1;
            }

            else if (currentPoint <= 0)
            {
                direction = 1;
            }
        }
    }
}
