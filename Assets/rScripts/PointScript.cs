using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    // Start is called before the first frame update
    //OnTriggerEnter
    public wScript wScript;
    public List<string> numbers = new List<string>();
    public void OnTriggerEnter(Collider col) {
        //Debug.Log(col.gameObject.name);
        if(wScript.GetSpeed() == 0){
            numbers.Add(col.gameObject.name);
            Debug.Log("added: "+col.gameObject.name);
        }
    }
    public string GetNumbers(){
        if(numbers.Count > 0){
            //Debug.Log("getNumbers returns: " + numbers[numbers.Count - 1]);
            return numbers[numbers.Count - 1];
        }
        return "";  
    }
    
    
}
