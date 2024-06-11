using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button SpinBtn;
    public wScript wheelScript;
    
    void Start()
    {
        SpinBtn.onClick.AddListener(() => SpinClicked());
    }

    private void SpinClicked() {
        wheelScript.StartSpin();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
