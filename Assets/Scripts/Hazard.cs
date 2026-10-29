using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawnScript player = other.GetComponent<PlayerRespawnScript>();

            if (player != null)
            {
                player.Respawn();
            }
        }
    }
}
