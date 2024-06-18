using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BetInput : MonoBehaviour
{
    private string input;
    private bool canRead = false;
    public wScript wheelScript;
    public PointScript pointScript;
    private List<string> validBets = new List<string>();
    private List<string> redList = new List<string>{"32", "19", "21", "25", "34", "27", "36", "30", "23", "5", "16", "1", "14", "9", "18", "7", "12", "3"};
    private List<string> blackList = new List<string>{"15", "4", "2", "17", "6", "13", "11", "8", "10", "24", "33", "20", "31", "22", "29", "28", "35", "26"};
    
    // Start is called before the first frame update
    public void readInput(string str){
        str = str.ToLower();
        
        if(!wheelScript.isSpinClicked() && validBets.Contains(str)){
            input = str;
            Debug.Log(input);
        }
        if(string.IsNullOrEmpty(str) || !validBets.Contains(str)){
            input = null;
        }

    }
    void Start()
    {
        fillValidBets();
    }
    public bool CheckIfWin(){
        if(pointScript.GetNumbers().Equals(input)){
            Debug.Log(input + " black wins");
            return true;
        }else if(redList.Contains(pointScript.GetNumbers()) && input.Equals("red")){
            Debug.Log("red wins");
            return true;
        }else if(blackList.Contains(pointScript.GetNumbers()) && input.Equals("black")){
            Debug.Log("black wins");
            return true;
        }
        return false;
    }
    private void fillValidBets(){
        validBets.Add("red");
        validBets.Add("black");
        for(int i = 0; i<37; i++){
            validBets.Add(i.ToString());
        }
        

    }
    public string getInput(){
        return input;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(wheelScript.isSpinClicked()){
            var uiElements = gameObject.GetComponentsInChildren<Selectable>();
            foreach (var uiElement in uiElements)
            {
                uiElement.interactable = false;
            }
        }
    }
}
