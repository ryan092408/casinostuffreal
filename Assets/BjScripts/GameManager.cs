using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    int deal = 0;
    private bool standClicked = false;
    
    void Start()
    {
       //listeners for buttons
       DealBtn.onClick.AddListener(() => DealClicked());
       HitBtn.onClick.AddListener(() => HitClicked());
       StandBtn.onClick.AddListener(() => StandClicked());
       //BetBtn.onClick.AddListener(() => BetClicked());
       ResetBtn.onClick.AddListener(() => ResetClicked());

    
    }
    private void ResetClicked() {
        SceneManager.LoadScene("BlackJack");
    }
    private void DealClicked(){
        if (deal == 0) {
            GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle();

            playerScript.StartHand();
            dealerScript.StartHand();
            deal++;
        }
    }
    private void HitClicked() {
        if (!standClicked && deal>0)
        {
            playerScript.HitCard();
        }
    
    }
    private void StandClicked() {
        if (deal > 0)
        {
            standClicked = true;
            dealerScript.StandCard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
