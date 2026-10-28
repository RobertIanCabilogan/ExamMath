using UnityEngine;

public class TPCamera : MonoBehaviour
{
    public Transform player;

    public Vector3 offset = new Vector3(0f, 3f, 0f);
    public float speed = 5f;
    public float height = 1.5f;

    private void LateUpdate()
    {
        if(player == null) return;

        Vector3 targetPos = player.position + player.rotation * offset;

        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);

        Vector3 lookTarget = player.position + Vector3.up * height;
        transform.LookAt(lookTarget);
    }
}
