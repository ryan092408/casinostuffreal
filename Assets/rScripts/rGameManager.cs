using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class rGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button SpinBtn;
    public Button ResetBtn;
    public wScript wheelScript;
    public BetInput betInput;
    public PointScript pointScript;
    public TMP_Text msg;
    
    void Start()
    {
        SpinBtn.onClick.AddListener(() => SpinClicked());
        ResetBtn.onClick.AddListener(() => ResetClicked());
    }

    private void SpinClicked() {
        if(!string.IsNullOrEmpty(betInput.getInput())){
            wheelScript.StartSpin();
        }
    }
    private void ResetClicked(){
        SceneManager.LoadScene("Roulette");
    }
    // Update is called once per frame
    void Update()
    {
        if(wheelScript.GetSpeed() == 0){
            if(wheelScript.GetSpeed() == 0 && betInput.CheckIfWin()){
                msg.text = "you win";
            }else{
                msg.text = "you lose";
            }
        }
    }
}
