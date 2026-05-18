using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    void Start()
    {
        //stores camera's initial rotation relative to the player, can be used to reset the camera if needed.
        // -------to be made later-------------
        //prints the difference in rotation between the camera and the player


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate camera
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //rotate orientation
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void ResetCameraRotation()
    {
        xRotation = 0f;
        yRotation = 0f;
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
