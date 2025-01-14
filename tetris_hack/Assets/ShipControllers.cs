using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float lookRateSpeed = 90f;
    public float rollSpeed = 90f;
    private float activeRollSpeed;
    public float rollAcceleration = 2f; // Acceleration for rolling

    private Vector2 lookInput, mouseDistance;
    private Vector2 screenCenter;

    public GameObject[] tetrisPiecePrefabs;
    private GameObject activePiece;



    // Start is called before the first frame update
    void Start()
    {
        // 1. Spawn a random Tetris piece as a child of this GameObject (the 'ship')
        if (tetrisPiecePrefabs != null && tetrisPiecePrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, tetrisPiecePrefabs.Length);
            activePiece = Instantiate(
                tetrisPiecePrefabs[randomIndex],
                transform.position,
                transform.rotation,
                transform // parent it under the ship so it moves/rotates together
            );
        }

        // 2. The rest of your existing initialization
        screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseInput();
        HandleRotation();
        HandleMovement();
    }

    private void HandleMouseInput()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.x;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;
    }

    private void HandleRotation()
    {
        float rotationX = -mouseDistance.y * lookRateSpeed * Time.deltaTime;
        float rotationY = mouseDistance.x * lookRateSpeed * Time.deltaTime;

        // Rolling the ship with acceleration
        float targetRollSpeed = Input.GetAxisRaw("Roll") * rollSpeed;
        activeRollSpeed = Mathf.Lerp(activeRollSpeed, targetRollSpeed, rollAcceleration * Time.deltaTime);

        transform.Rotate(rotationX, rotationY, activeRollSpeed * Time.deltaTime, Space.Self);
    }

    private void HandleMovement()
    {
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        Vector3 movement = (transform.forward * activeForwardSpeed) +
                           (transform.right * activeStrafeSpeed) +
                           (transform.up * activeHoverSpeed);

        transform.position += movement * Time.deltaTime;
    }
}
