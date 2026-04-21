using UnityEngine;

public class SitAtComputer : MonoBehaviour
{
    public bool isSitting = false; // Flag to track if the player is currently sitting
    public GameObject sitDownCamera; // Reference to the camera that will be used when the player is sitting at the computer
    public GameObject playerCamera; // Reference to the player's main camera
    public GameObject mainPlayerUi; // Reference to the player's main UI canvas to disable when sitting at the computer.
    public GameObject playerToHide; // Reference to the player model to hide when sitting at the computer

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
            //fade screen to black and move the player to the computer position, then fade back in
            isSitting = true;
            playerCamera.SetActive(false);
            sitDownCamera.SetActive(true);
            mainPlayerUi.SetActive(false);
            playerToHide.SetActive(false);
            //disable audio listener on player camera and enable it on sit down camera
            playerCamera.GetComponent<AudioListener>().enabled = false;
            sitDownCamera.GetComponent<AudioListener>().enabled = true;
            //enable mouse pointer for computer interaction
            Cursor.lockState = CursorLockMode.None;
        }
        //press E to leave computer and return to normal player camera. The interact is attached to the player which is hidden.
        else if (Input.GetKeyDown(KeyCode.E) && isSitting)
        {
            isSitting = false;
            playerCamera.SetActive(true);
            sitDownCamera.SetActive(false);
            mainPlayerUi.SetActive(true);
            playerToHide.SetActive(true);
            //enable audio listener on player camera and disable it on sit down camera
            playerCamera.GetComponent<AudioListener>().enabled = true;
            sitDownCamera.GetComponent<AudioListener>().enabled = false;
        }

    }
}
