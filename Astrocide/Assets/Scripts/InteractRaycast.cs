using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InteractRaycast : MonoBehaviour
{
    public float rayLength = 500f; // Length of the raycast
    public Camera playerCamera; // Reference to the player's camera

    [SerializeField] private float indicatorTimer = 0.5f; //time it takes to interact with an object while the raycast is touching it and the player is holding the interact button

    [SerializeField] private Image indicatorImage; //UI image that shows the interaction progress

    [SerializeField] private KeyCode interactKey = KeyCode.E; //Key to interact with objects

    [SerializeField] private UnityEvent onInteract; //Event to call when the player interacts with an object

    [SerializeField] private GameObject interactSensor;
    [SerializeField] private float interactSensorActiveTime = 0.1f; // Duration in seconds

    private float interactSensorTimer = 0f;



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

        // Handle interactSensor activation timer
        if (interactSensorTimer > 0f)
        {
            interactSensor.SetActive(true);
            interactSensorTimer -= Time.deltaTime;
        }
        else
        {
            interactSensor.SetActive(false);
        }

        //interact with an object with interactsensor if the raycast hits it and the timer is filled. 
        if (Physics.Raycast(ray, out RaycastHit hit, rayLength) && hit.collider.CompareTag("Interactable") && Input.GetKey(interactKey))
        {
            // Show the interaction indicator
            indicatorImage.fillAmount += Time.deltaTime / indicatorTimer;
            // If the interaction is complete, call the onInteract event
            if (indicatorImage.fillAmount >= 1f)
            {
                onInteract.Invoke();
                // Activate interactSensor for a set duration
                interactSensorTimer = interactSensorActiveTime;

                indicatorImage.fillAmount = 0f; // Reset the indicator
            }
        }
        else
        {
            // Hide the interaction indicator if not interacting
            indicatorImage.fillAmount = 0f;
        }


    }
}
