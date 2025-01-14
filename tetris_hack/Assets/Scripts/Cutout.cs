// using UnityEngine;
// using UnityEngine.ProBuilder;

// public class ProBuilderCutout : MonoBehaviour
// {
//     public ProBuilderMesh cube; // The ProBuilder cube
//     public GameObject ballPrefab; // Prefab for the draggable ball
//     public float cutoutRadius = 0.5f; // Radius of the cutout

//     private Vector3 cutoutPosition; // Position of the cutout

//     void Start()
//     {
//         if (cube == null)
//         {
//             Debug.LogError("Assign a ProBuilder cube!");
//             return;
//         }

//         CreateRandomCutout();
//     }

//     void CreateRandomCutout()
//     {
//         // Get the cube's bounds
//         Bounds bounds = cube.GetComponent<MeshRenderer>().bounds;

//         // Generate a random position within the bounds
//         cutoutPosition = new Vector3(
//             Random.Range(bounds.min.x + cutoutRadius, bounds.max.x - cutoutRadius),
//             Random.Range(bounds.min.y + cutoutRadius, bounds.max.y - cutoutRadius),
//             Random.Range(bounds.min.z + cutoutRadius, bounds.max.z - cutoutRadius)
//         );

//         // Modify the cube's mesh to create a spherical cutout
//         ModifyCubeMesh(cutoutPosition, cutoutRadius);
//     }

//     void ModifyCubeMesh(Vector3 position, float radius)
//     {
//         // Get the cube's vertices
//         Vector3[] vertices = cube.positions.ToArray();

//         for (int i = 0; i < vertices.Length; i++)
//         {
//             Vector3 worldPosition = cube.transform.TransformPoint(vertices[i]);

//             // If the vertex is within the cutout radius, move it away
//             if (Vector3.Distance(worldPosition, position) < radius)
//             {
//                 Vector3 direction = (worldPosition - position).normalized;
//                 vertices[i] = cube.transform.InverseTransformPoint(position + direction * radius);
//             }
//         }

//         // Update the ProBuilder mesh
//         cube.positions = new System.Collections.Generic.List<Vector3>(vertices);
//         cube.ToMesh();
//         cube.Refresh();
//     }

//     void OnDrawGizmos()
//     {
//         // Visualize the cutout position in the editor
//         Gizmos.color = Color.red;
//         Gizmos.DrawWireSphere(cutoutPosition, cutoutRadius);
//     }
// }
