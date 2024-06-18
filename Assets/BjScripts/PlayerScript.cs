
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // script for both dealer and player
    public CardScript cardScript;
    public DeckScript deckScript;
    //total value of player/dealer hands
    public int handValue = 0;
    //bet amount
    private int money = 1000;
    // array of card objects played
    public GameObject[] hand;
    public GameObject Player;
    //index of next card
    public int cardIndex = 0;
    private float xx = (float)112.0623;
    private float yy = 0;
    private float scale = (float) 1.494164;
    private float upnumber = 250;
    public Text pHandVal;

    public bool bust = false;
    // tracking aces for conversion between 1 and 11
    List<CardScript> aceList = new List<CardScript>();
    public UnityEngine.UI.Image imgRenderer;
    public void StartCard1()
    {
        StartCoroutine(DelayCard(0.75f));
        
        
    }
    public void StartCard2(){
        StartCoroutine(DelayCard(2.25f));
        
    }
    public void HitCard() {
        
        if (handValue < 21)
        {
            
            GetHitCard();
            Debug.Log("Hit Card hand Value: " + handValue);
        }
        else
        {
            print("fart");
        }
    }

    // Update is called once per frame
    // add a hand to player /dealer hand
    
    public int GetCard()
    {


        int cardValue = deckScript.DealCard(hand[cardIndex].GetComponent<CardScript>());
        //show card on game screen
        
        imgRenderer = hand[cardIndex].GetComponent<UnityEngine.UI.Image>();
        imgRenderer.sprite = hand[cardIndex].GetComponent<SpriteRenderer>().sprite;
        handValue += cardValue;
        Debug.Log("added " + handValue + " to intial handVal");
        if (cardValue == 11)
        {
            aceList.Add(hand[0].GetComponent<CardScript>());
        }
        if (handValue > 21 && aceList.Count > 0)
        {
            handValue -= 10;
            aceList.RemoveAt(0);
            Debug.Log("removed 10");
        }

        cardIndex++;

        return handValue;
    }

    public void GetHitCard() {
        int cardValue = deckScript.DealCard(hand[0].GetComponent<CardScript>());
        if (cardValue == 11)
        {
            aceList.Add(hand[0].GetComponent<CardScript>());
        }
        var newObj = new GameObject("hitCard", typeof(RectTransform));
        var parent = GameObject.Find("Player");
        var parentTransform = parent.GetComponent<Transform>();
        newObj.transform.parent = parentTransform;
        var pCard2 = GameObject.Find("pCard2");

        handValue += cardValue;
        //decides which value of ace to use
       
        upnumber += 50;
        if (handValue > 21 && aceList.Count > 0)
        {
            handValue -= 10;
            aceList.RemoveAt(0);
            Debug.Log("removed 10");
        }
        else if(handValue>21){
            bust = true;
            Debug.Log("Player Busts!");
        }
        Debug.Log(xx);
        //xx += pCard2.transform.position.x;
        xx = 140 + upnumber;
        //Debug.Log("new player xx value: " + xx);
        yy = pCard2.transform.position.y;
        
        Vector3 newPosition = new Vector3(xx, yy, 0);
        
        newObj.transform.localScale = new Vector3(scale,scale,scale);
        newObj.GetComponent<RectTransform>().sizeDelta = new Vector2((float)110.2668, (float)149.2806);
        newObj.transform.position = newPosition;
        UnityEngine.UI.Image NewImage = newObj.AddComponent<UnityEngine.UI.Image>(); //Add the Image Component script
        NewImage.sprite = hand[0].GetComponent<SpriteRenderer>().sprite;
        newObj.SetActive(true);


    }
    public bool GetBust(){
        return bust;
    }
    public int GetHandVal(){
        return handValue;
    }
    public int GetCard2Val(){
        var pCard2 = GameObject.Find("pCard2");
        return pCard2.GetComponent<CardScript>().GetValue();
    }
    IEnumerator DelayCard(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetCard();
        pHandVal.text = handValue.ToString();
        if(handValue ==21){
            pHandVal.text = "BLACKJACKKKK";
        }
        Debug.Log("Inital hand value: " + handValue);
    }
    
   
}
