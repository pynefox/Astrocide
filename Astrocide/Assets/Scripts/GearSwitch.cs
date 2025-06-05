using UnityEngine;

public class GearSwitch : MonoBehaviour
{
    public GameObject emptyhand; // Reference to the empty hand GameObject
    public GameObject redlight; // Reference to the red light GameObject
    public GameObject whitelight; // Reference to the white light GameObject
    public GameObject purplelight; // Reference to the purple light GameObject

    public GameObject redbeam; //spotlight game object for red light
    public GameObject whitebeam; //spotlight game object for white light
    public GameObject purplebeam; //spotlight game object for purple light

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        emptyhand.SetActive(true);
        redlight.SetActive(false);
        whitelight.SetActive(false);
        purplelight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //cycle through the available game objects when the player uses scroll wheel, looping back to the first one after the last
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // Scroll up
        {
            if (emptyhand.activeSelf)
            {
                emptyhand.SetActive(false);
                redlight.SetActive(true);
            }
            else if (redlight.activeSelf)
            {
                redlight.SetActive(false);
                whitelight.SetActive(true);
            }
            else if (whitelight.activeSelf)
            {
                whitelight.SetActive(false);
                purplelight.SetActive(true);
            }
            else if (purplelight.activeSelf)
            {
                purplelight.SetActive(false);
                emptyhand.SetActive(true);
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // Scroll down
        {
            if (emptyhand.activeSelf)
            {
                emptyhand.SetActive(false);
                purplelight.SetActive(true);
            }
            else if (purplelight.activeSelf)
            {
                purplelight.SetActive(false);
                whitelight.SetActive(true);
            }
            else if (whitelight.activeSelf)
            {
                whitelight.SetActive(false);
                redlight.SetActive(true);
            }
            else if (redlight.activeSelf)
            {
                redlight.SetActive(false);
                emptyhand.SetActive(true);
            }
        }

        //hold click to use the currently active beam if the corresponding light is active
        if (Input.GetMouseButton(0)) // Left mouse button held down
        {
            if (redlight.activeSelf)
            {
                redbeam.SetActive(true);
            }
            else
            {
                redbeam.SetActive(false);
            }
            if (whitelight.activeSelf)
            {
                whitebeam.SetActive(true);
            }
            else
            {
                whitebeam.SetActive(false);
            }
            if (purplelight.activeSelf)
            {
                purplebeam.SetActive(true);
            }
            else
            {
                purplebeam.SetActive(false);
            }
        }
        else // Left mouse button released
        {
            redbeam.SetActive(false);
            whitebeam.SetActive(false);
            purplebeam.SetActive(false);
        }

    }

}
