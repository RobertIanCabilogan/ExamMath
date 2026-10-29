using UnityEngine;

public class PlayerRespawnScript : MonoBehaviour
{
    public Transform respawnPoint;


    public void Respawn()
    {
        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
        }
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        respawnPoint = checkpoint; 
    }
}
