using UnityEngine;

public class AnimatedSkybox : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // Speed of rotation
    public Color startColor = Color.blue; // Initial sky tint color
    public Color endColor = Color.red; // Final sky tint color
    public float colorChangeSpeed = 0.5f; // Speed of color transition

    private Material skyboxMaterial;

    void Start()
    {
        // Cache the skybox material
        skyboxMaterial = RenderSettings.skybox;
    }

    void Update()
    {
        // Rotate the skybox
        skyboxMaterial.SetFloat("_Rotation", Time.time * rotationSpeed);

        // Animate the sky tint color
        Color newColor = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * colorChangeSpeed, 1));
        skyboxMaterial.SetColor("_SkyTint", newColor);
    }
}
