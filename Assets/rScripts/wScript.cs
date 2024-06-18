using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wScript : MonoBehaviour
{
    public float Speed;
    private bool spinClicked = false;
    private int timer = 0;
    private int numSpinClicked = 0;
    public GameObject Pointer;
    
    
    // Start is called before the first frame update
    public void StartSpin()
    {
        if(numSpinClicked == 0){
            timer = 0;
            Speed = Mathf.FloorToInt(Random.Range(400.0f, 800.0f));
            spinClicked = true;
            numSpinClicked++;
            Debug.Log(Speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spinClicked)
        {
            Rotate();
            timer++;
            //Debug.Log(timer);
        }
    }
    void Rotate() {
        if (spinClicked)
        {
            transform.Rotate(0, 0, Speed * Time.deltaTime);
            if (timer > 0 && Speed > 0)
            {
                Stop();
            }
        }
    }
    public void Stop() {
        Speed = Speed - 0.1f;
        if (Speed <= 0) {
            Speed = 0;
            Pointer.GetComponent<BoxCollider>().enabled = true;
            

        }
    }
    public float GetSpeed(){
        return Speed;
    }
    public bool isSpinClicked(){
        return spinClicked;
    }
    
}
