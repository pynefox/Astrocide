using UnityEngine;

public class MoveGear : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public Transform gearPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = gearPosition.position;
    }
}
