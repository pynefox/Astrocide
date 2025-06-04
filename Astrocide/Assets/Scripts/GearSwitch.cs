using UnityEngine;

public class GearSwitch : MonoBehaviour
{
    public GameObject purplelight; // Reference to the purple light GameObject
    public GameObject redlight; // Reference to the red light GameObject
    public GameObject whitelight; // Reference to the white light GameObject
    public GameObject emptyhand; // Reference to the empty hand GameObject
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
        //cycle through the available lights when the player presses the "E" key
        if (Input.GetKeyDown(KeyCode.E))
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
    }
}
