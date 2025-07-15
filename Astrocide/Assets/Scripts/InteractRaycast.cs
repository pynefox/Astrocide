using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InteractRaycast : MonoBehaviour
{
    public float rayLength = 500f; // Length of the raycast
    public Camera playerCamera; // Reference to the player's camera

    [SerializeField] private float indicatorTimer = 0.5f; //time it takes to interact with an object while the raycast is touching it and the player is holding the interact button
    [SerializeField] private float maxIndicatorTimer = 0.5f; //maximum time the indicator can be shown

    [SerializeField] private Image indicatorImage; //UI image that shows the interaction progress

    [SerializeField] private KeyCode interactKey = KeyCode.E; //Key to interact with objects

    [SerializeField] private UnityEvent onInteract; //Event to call when the player interacts with an object

    private bool shouldUpdate = false;

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

        //check if the raycast hits an object tagged with "toggleTest"
        if (Physics.Raycast(ray, out RaycastHit hit, rayLength) && hit.collider.CompareTag("toggleTest"))
        {
            //if the player is holding the interact key
            if (Input.GetKey(interactKey))
            {
                //show the indicator image and update its fill amount based on the timer
                shouldUpdate = true;
                indicatorImage.fillAmount = Mathf.Clamp01(indicatorImage.fillAmount + Time.deltaTime / maxIndicatorTimer);
                
                //if the fill amount reaches 1, invoke the interaction event
                if (indicatorImage.fillAmount >= 1f)
                {
                    onInteract.Invoke();
                    indicatorImage.fillAmount = 0f; //reset the indicator
                }
            }
            else
            {
                //if the player is not holding the interact key, reset the indicator
                shouldUpdate = false;
                indicatorImage.fillAmount = 0f;
            }
        }
        else
        {
            //if the raycast does not hit an object, reset the indicator
            shouldUpdate = false;
            indicatorImage.fillAmount = 0f;
        }

    }
}
