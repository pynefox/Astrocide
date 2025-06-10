using UnityEngine;

public class UraniumTest : MonoBehaviour
{
    public Material normalMaterial; // Material to apply when not glowing
    public Material glowingMaterial; // Material to apply when glowing

    private int triggersPresent = 0;

    void Start()
    {
        GetComponent<Renderer>().material = normalMaterial;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("purplelightbeam"))
        {
            triggersPresent++;
            GetComponent<Renderer>().material = glowingMaterial;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("purplelightbeam"))
        {
            triggersPresent = Mathf.Max(0, triggersPresent - 1);
            if (triggersPresent == 0)
            {
                GetComponent<Renderer>().material = normalMaterial;
            }
        }
    }

    void Update()
    {
        // If a trigger disappears without calling OnTriggerExit, triggersPresent may be > 0.
        // Check if any purplelightbeam triggers are still present.
        if (triggersPresent > 0)
        {
            bool found = false;
            Collider[] overlaps = Physics.OverlapSphere(transform.position, 1.0f); // Adjust radius as needed
            foreach (var col in overlaps)
            {
                if (col.CompareTag("purplelightbeam"))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                triggersPresent = 0;
                GetComponent<Renderer>().material = normalMaterial;
            }
        }
    }
}
