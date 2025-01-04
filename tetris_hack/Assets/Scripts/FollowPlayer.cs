using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;    // Drag the player (or the piece) transform here
    public Vector3 offset;      // Offset to keep some distance behind/above the player

    void LateUpdate()
    {
        if (player != null)
        {
            // Update camera position with offset
            transform.position = player.position + offset;

            // Optionally look at the player
            // transform.LookAt(player.position);
        }
    }
}
