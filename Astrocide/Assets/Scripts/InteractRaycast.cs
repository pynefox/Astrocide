using UnityEngine;

public class InteractRaycast : MonoBehaviour
{
    public float rayLength = 500f; // Length of the raycast
    public Camera playerCamera; // Reference to the player's camera
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //raycast comes from the camera's position and direction, in the center of the screen
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        //make the raycast visible in the editor for debugging purposes
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

    }
}
