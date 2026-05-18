using UnityEngine;

public class SitAtComputer : MonoBehaviour
{
    public bool isSitting = false; // Flag to track if the player is currently sitting
    public GameObject sitdownLocation; // Reference to the location where the player should be moved when sitting down
    public GameObject player; // Reference to the player GameObject
    public GameObject toolsToHide; // Reference to the tools that should be hidden when sitting down
    public GameObject playerCamHolder; // Reference to the player's camera

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerInteract") && !isSitting)
        {
            // Move the player to the sitdown location
            player.transform.position = sitdownLocation.transform.position;
            //reset camera rotation by calling resetCameraRotation()
            playerCamHolder.GetComponent<PlayerCam>().ResetCameraRotation();
            // Hide the tools
            toolsToHide.SetActive(false);
            //set disableMovement to true on the PlayerMovement script
            player.GetComponent<PlayerMovement>().disableMovement = true;
            isSitting = true;
        }
        
        else if (other.CompareTag("PlayerInteract") && isSitting)
        {
            // Move the player back to the original position
            player.transform.position = sitdownLocation.transform.position;
            //reset camera rotation by calling resetCameraRotation()
            playerCamHolder.GetComponent<PlayerCam>().ResetCameraRotation();
            // Show the tools
            toolsToHide.SetActive(true);
            //set disableMovement to false on the PlayerMovement script
            player.GetComponent<PlayerMovement>().disableMovement = false;
            //refresh offset of the player camera, gets shifted a few degrees when sitting down and standing up
            // -------to be made later-------------
            isSitting = false;
        }

    }
}
