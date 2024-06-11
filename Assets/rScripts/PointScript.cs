using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    void OnTriggerEnter(Collider col) {
        Debug.Log(col.gameObject.name);
    }
    
    
}
