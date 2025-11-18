using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D()
    {
        Debug.Log("Collision");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
