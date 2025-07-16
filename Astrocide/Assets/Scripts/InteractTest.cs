using UnityEngine;

public class InteractTest : MonoBehaviour
{
    private bool isOn = false;
    public Material toggleOnMaterial; // Material to apply when the object is toggled on
    public Material toggleOffMaterial; // Material to apply when the object is toggled off
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
        if (other.CompareTag("PlayerInteract") && !isOn)
        {
            GetComponent<Renderer>().material = toggleOnMaterial;
            isOn = true;
        }
        else if (other.CompareTag("PlayerInteract") && isOn)
        {
            GetComponent<Renderer>().material = toggleOffMaterial;
            isOn = false;
        }
    }
}
