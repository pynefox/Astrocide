using UnityEngine;

public class UraniumTest : MonoBehaviour
{
    public GameObject blacklightcollider; // Reference to the blacklight collider GameObject
    public Material normalMaterial; // Material to apply when not glowing
    public Material glowingMaterial; // Material to apply when glowing
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when the black light collider touches this object's collider change the material of this object to "glowing", else set it to "normal"
        if (blacklightcollider.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds))
        {
            GetComponent<Renderer>().material = glowingMaterial; // Change to glowing material
        }
        else
        {
            GetComponent<Renderer>().material = normalMaterial; // Change to normal material
        }

    }
}
