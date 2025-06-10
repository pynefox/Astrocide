using UnityEngine;

public class GearSway : MonoBehaviour
{
    public float breathinterval; // Time between each sway in seconds when the player is idle
    public float breathamount; // Amount of sway when the player is idle
    public float activeswayinterval; // Time between each sway in seconds when the player is active
    public float activeswayamount; // Amount of sway when the player is active
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //idle sway if the player is not moving, otherwise active sway
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            // Idle sway
            transform.localPosition = new Vector3(
                Mathf.Sin(Time.time * (2 * Mathf.PI / breathinterval)) * breathamount,
                transform.localPosition.y,
                transform.localPosition.z
            );
        }
        else
        {
            // Active sway
            transform.localPosition = new Vector3(
                Mathf.Sin(Time.time * (2 * Mathf.PI / activeswayinterval)) * activeswayamount,
                transform.localPosition.y,
                transform.localPosition.z
            );
        }
    }
}
