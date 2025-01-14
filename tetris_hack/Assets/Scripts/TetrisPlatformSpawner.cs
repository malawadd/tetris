using UnityEngine;
using System.Collections.Generic;

public class TetrisPlatformSpawner : MonoBehaviour
{
    // Reference to our TetrisPlatformGenerator
    public TetrisPlatformGenerator generator;

    // Where to spawn each platform in space
    public Vector3 spawnPos1 = new Vector3(-10, 0, 0);
    public Vector3 spawnPos2 = new Vector3(0, 0, 0);
    public Vector3 spawnPos3 = new Vector3(10, 0, 0);

    // Call this when you want to spawn the 3 platforms
    public void SpawnPlatforms(TetrisPlatformGenerator.TetrisPieceType playerPiece)
    {
        // 1) The correct platform, i.e. missing the player's piece
        GameObject correctPlatform = generator.GeneratePlatform(playerPiece);

        // 2) Two incorrect platforms - we want them missing
        //    something else, so that the player's piece won't fit.
        //    We'll pick two random piece types that are NOT 'playerPiece'
        var allPieces = new List<TetrisPlatformGenerator.TetrisPieceType>
        {
            TetrisPlatformGenerator.TetrisPieceType.I,
            TetrisPlatformGenerator.TetrisPieceType.O,
            TetrisPlatformGenerator.TetrisPieceType.T,
            TetrisPlatformGenerator.TetrisPieceType.S,
            TetrisPlatformGenerator.TetrisPieceType.L
        };
        // Remove the player's piece from that list
        allPieces.Remove(playerPiece);

        // Shuffle them, pick the first two as "missing pieces"
        Shuffle(allPieces);
        TetrisPlatformGenerator.TetrisPieceType missing1 = allPieces[0];
        TetrisPlatformGenerator.TetrisPieceType missing2 = allPieces[1];

        GameObject incorrectPlatform1 = generator.GeneratePlatform(missing1);
        GameObject incorrectPlatform2 = generator.GeneratePlatform(missing2);

        // Now we have 3 platform roots: correctPlatform, incorrectPlatform1, incorrectPlatform2
        // Let's put them into a list and shuffle them before placing them in the scene
        List<GameObject> platformList = new List<GameObject>
        {
            correctPlatform,
            incorrectPlatform1,
            incorrectPlatform2
        };
        ShuffleGameObjects(platformList);

        // We also shuffle the spawn positions
        List<Vector3> positions = new List<Vector3> { spawnPos1, spawnPos2, spawnPos3 };
        ShuffleVectors(positions);

        // Finally, set each platform's position
        for (int i = 0; i < platformList.Count; i++)
        {
            platformList[i].transform.position = positions[i];
        }
    }

    // Utility function to shuffle a list of TetrisPieceTypes
    private void Shuffle(List<TetrisPlatformGenerator.TetrisPieceType> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var temp = list[i];
            int randIndex = Random.Range(i, list.Count);
            list[i] = list[randIndex];
            list[randIndex] = temp;
        }
    }

    // Utility function to shuffle a list of GameObjects
    private void ShuffleGameObjects(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject temp = list[i];
            int randIndex = Random.Range(i, list.Count);
            list[i] = list[randIndex];
            list[randIndex] = temp;
        }
    }

    // Utility function to shuffle a list of Vector3 positions
    private void ShuffleVectors(List<Vector3> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Vector3 temp = list[i];
            int randIndex = Random.Range(i, list.Count);
            list[i] = list[randIndex];
            list[randIndex] = temp;
        }
    }
}
