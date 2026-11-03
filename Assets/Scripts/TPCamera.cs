
using UnityEngine;

public class TPCamera : MonoBehaviour
{
    public Transform player;

    public Vector3 offset = new Vector3(0f, 3f, -5f);

    public float speed = 5f;
    public float height = 1.5f;

    public float rotationSpeed = 10f;

    private Vector3 velocity;

    public Transform Player
    {
        get => player;
        set => player = value;
    }

    public Vector3 Offset
    {
        get => offset;
        set => offset = value;
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public float Height
    {
        get => height;
        set => height = value;
    }

    private void LateUpdate()
    {
        if (player == null)
            return;
        Vector3 targetPos = player.position +
                            player.rotation * offset;

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPos,
            ref velocity,
            1f / speed
        );

        Vector3 lookTarget = player.position +
                            Vector3.up * height;

        Vector3 direction = lookTarget - transform.position;

        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}
