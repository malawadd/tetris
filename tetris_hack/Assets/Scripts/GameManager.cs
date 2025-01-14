using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Drag your TetrisPlatformSpawner here in the Inspector
    public TetrisPlatformSpawner platformSpawner;

    void Start()
    {
        // Example: let's assume the player's piece is "I" just for testing
        // You can change this to O, T, S, or Z for other tests
        platformSpawner.SpawnPlatforms(TetrisPlatformGenerator.TetrisPieceType.I);
    }
}
