using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wScript : MonoBehaviour
{
    public float Speed;
    private bool spinClicked = false;
    private int timer = 0;
    public GameObject Pointer;
    
    // Start is called before the first frame update
    public void StartSpin()
    {
        Speed = Mathf.FloorToInt(Random.Range(600.0f, 1200.0f));
        spinClicked = true;
        Debug.Log(Speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (spinClicked)
        {
            Rotate();
            timer++;
        }
    }
    void Rotate() {
        if (spinClicked)
        {
            transform.Rotate(0, 0, Speed * Time.deltaTime);
            if (timer > 5000 && Speed > 0)
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
            spinClicked = false;
        }
    }
    
}
