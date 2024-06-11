using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BacGameManager : MonoBehaviour
{
    public Button DealBtn;
    public Button ResetBtn;

    //public BacPlayerScript playerScript;
    public BankerScript bankerScript;
    // Start is called before the first frame update
    void Start()
    {
        DealBtn.onClick.AddListener(() => DealClicked()); 
    }
    private void DealClicked() {
        bankerScript.StartHand();
    
    }
    private void ResetClicked() {
        SceneManager.LoadScene("Baccarat");

    
            
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
