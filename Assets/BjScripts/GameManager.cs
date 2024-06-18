using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEditor.Build.Reporting;
using TMPro;
using UnityEngine.Rendering.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Game buttons
    public Button DealBtn;
    public Button HitBtn;
    public Button StandBtn;
    public Button BetBtn;
    public Button ResetBtn;
    //access player and dealer hands
    public PlayerScript playerScript;
    public DealerScript dealerScript;
    private int deal = 0;
    
    private bool canStand = false;
    private bool canReset = false;
    private bool canHit = false;
    public TMP_Text text;
    public Text pHandVal;
    public Text dHandVal;

    public TMP_Text tBet;
    public TMP_Text Balance;
    private int betVal;
    private int balanceVal = 100;
    private bool addedToBalance = false;


    private bool standClicked = false;

    //Text Msg = UI.Find("Msg");
    
    void Start()
    {
       //listeners for buttons
       DealBtn.onClick.AddListener(() => DealClicked());
       HitBtn.onClick.AddListener(() => HitClicked());
       StandBtn.onClick.AddListener(() => StandClicked());
       BetBtn.onClick.AddListener(() => BetClicked());
       ResetBtn.onClick.AddListener(() => ResetClicked());

    
    }
    private void ResetClicked() {
        if(canReset){
            SceneManager.LoadScene("BlackJack");
        }
        
    }
    public void DealClicked(){
        if (deal == 0) {
            GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle();

            playerScript.StartCard1();
            dealerScript.StartHand();
            playerScript.StartCard2();
            deal++;
            
        }
        Debug.Log(pHandVal.text);
        pHandVal.text = playerScript.GetHandVal().ToString();   
    }
    private void HitClicked() {
        if (!standClicked && deal>0 && canHit)
        {
            playerScript.HitCard();
            pHandVal.text = playerScript.GetHandVal().ToString();
        }
        if(playerScript.GetBust()){
            text.text = "Player Busts!";
            pHandVal.text = "Too Many";
        }
    
    }
    private void StandClicked() {
        if (deal > 0 && canStand)
        {
            standClicked = true;
            dealerScript.StandCard();
            dHandVal.text = dealerScript.GetHandVal().ToString();
            canStand = false;
            canReset = true;
            
        }
        
        
        }
    private void BetClicked(){
        if(balanceVal >0){
        balanceVal -=20;
        betVal +=20;
        }
    }
    

    // Update is called once per frame
    //ff
    void Update()
    {
       int dVal = dealerScript.GetHandVal();
       int pVal = playerScript.GetHandVal();
       if(dealerScript.GetHandVal() > 16){
            if(dVal< 22 && dVal>pVal && pVal <22){
                text.text = "Dealer Wins!";
                canReset = true;
            }else if(pVal>21){
                text.text = "Player Busts!";
                
            }
            else if(((dVal<pVal && pVal<22) || dVal>21) && !addedToBalance){
                text.text = "Player Wins!";
                balanceVal += betVal * 2;
                addedToBalance = true;
                canReset = true;
            }else if(dVal == pVal && !addedToBalance){
                text.text = "Push!";
                balanceVal += betVal;
                addedToBalance = true;
                canReset = true;
            }
       } 
       if(playerScript.GetHandVal() >= 21){
            StandClicked();
       }
       if(playerScript.GetCard2Val() > 0){
            canHit = true;
       }
       if(playerScript.GetCard2Val()>0){
            canStand=true;
       }
       
       tBet.text = "total bet: " + betVal;
       Balance.text = "coins: " + balanceVal;
       
    }
}
