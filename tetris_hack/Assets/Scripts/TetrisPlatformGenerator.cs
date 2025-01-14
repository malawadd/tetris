using UnityEngine;
using System.Collections.Generic;

public class TetrisPlatformGenerator : MonoBehaviour
{
    // We’ll define an enum for clarity on which piece type we're talking about.
    public enum TetrisPieceType
    {
        I,
        O,
        T,
        S,
        L
    }

    // Assign these in the Inspector to your 5 Tetris piece prefabs (FBX turned into Prefab).
    public GameObject pieceI;
    public GameObject pieceO;
    public GameObject pieceT;
    public GameObject pieceS;
    public GameObject pieceL;

    // A dictionary for easy mapping from TetrisPieceType -> the actual prefab
    private Dictionary<TetrisPieceType, GameObject> pieceMap;

    private void Awake()
    {
        // Setup a quick map/dictionary so we can fetch prefabs by their enum type
        pieceMap = new Dictionary<TetrisPieceType, GameObject>
        {
            { TetrisPieceType.I, pieceI },
            { TetrisPieceType.O, pieceO },
            { TetrisPieceType.T, pieceT },
            { TetrisPieceType.S, pieceS },
            { TetrisPieceType.L, pieceL }
        };
    }

    /// <summary>
    /// Creates a new "platform" by combining several Tetris pieces—except for one missing piece.
    /// If missingPiece == I, that means we do NOT include the I piece, 
    /// so there's theoretically a "gap" for the I piece to fit.
    /// </summary>
    public GameObject GeneratePlatform(TetrisPieceType missingPiece)
    {
        // Create a container to hold our platform’s pieces
        GameObject platformRoot = new GameObject("GeneratedPlatform");

        // Decide which pieces to place. We'll place ALL except the missing one
        List<TetrisPieceType> piecesToPlace = new List<TetrisPieceType>
        {
            TetrisPieceType.I,
            TetrisPieceType.O,
            TetrisPieceType.T,
            TetrisPieceType.S,
            TetrisPieceType.L
        };

        // Remove the "missing" piece from the list so we don't place it.
        piecesToPlace.Remove(missingPiece);

        // Now we have 4 piece types left to place (since we removed 1).
        // Let's do something simple: place them in a random arrangement around (0,0,0).

        // For example, define some spawn offsets around an origin
        // (You can get creative with how you want them arranged!)
        Vector3[] offsets = new Vector3[]
        {
            new Vector3(-2, 0, 0),
            new Vector3( 2, 0, 0),
            new Vector3( 0,  2, 0),
            new Vector3( 0, -2, 0)
        };

        // Shuffle the offsets so the arrangement changes each time
        ShuffleVectorArray(offsets);

        // Now instantiate each piece at one of these offsets relative to the platformRoot
        for (int i = 0; i < piecesToPlace.Count; i++)
        {
            TetrisPieceType pieceType = piecesToPlace[i];
            GameObject prefab = pieceMap[pieceType];

            // Create the piece
            Vector3 spawnPos = platformRoot.transform.position + offsets[i];
            GameObject newPiece = Instantiate(prefab, spawnPos, Quaternion.identity);

            // Remove Camera components from the instantiated piece and its children
            RemoveCameras(newPiece);

            // Parent it under the platformRoot to keep them grouped
            newPiece.transform.SetParent(platformRoot.transform);
        }

        // Optionally: random rotation or other modifications
        // platformRoot.transform.rotation = Random.rotation;

        // Return the entire "platform" we just built
        return platformRoot;
    }

    /// <summary>
    /// Simple utility to shuffle a Vector3 array in-place.
    /// </summary>
    private void ShuffleVectorArray(Vector3[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Vector3 temp = array[i];
            int randomIndex = Random.Range(i, array.Length);
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    /// <summary>
    /// Removes all Camera components from the specified GameObject and its children.
    /// </summary>
    private void RemoveCameras(GameObject obj)
    {
        Camera[] cameras = obj.GetComponentsInChildren<Camera>(true);
        foreach (Camera cam in cameras)
        {
            Destroy(cam); // Remove the Camera component
            Debug.Log($"Removed camera from: {cam.gameObject.name}");
        }
    }
}


