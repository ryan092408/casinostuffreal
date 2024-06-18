using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class DealerScript : MonoBehaviour
{
    public CardScript cardScript;
    public DeckScript deckScript;
    //total value of player/dealer hands
    public int handValue = 0;
    //bet amount
    
    // array of card objects played
    public GameObject[] hand;
    public GameObject Player;
    //index of next card
    public int cardIndex = 0;
    private float scale = (float) 1.494164;
    private float xx = (float)112.0623;
    private float yy = 0;
    private float upnumber = 250;
    public Text dHandVal;
    // tracking aces for conversion between 1 and 11
    List<CardScript> aceList = new List<CardScript>();
    public UnityEngine.UI.Image imgRenderer;
    public bool Over = false;
    public bool isOver(){
        Debug.Log("Over is: " + Over);
        return Over;
    }
    public void StartHand()
    {
        StartCoroutine(DelayGetCard(1.5f));
        
        
    }
    public void StandCard()
    {
        GetCard();
        
        if (handValue <= 16)
        {
            
            StartCoroutine(DelayCard(2f));
            
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

    public void GetStandCard()
    {
        int cardValue = deckScript.DealCard(hand[0].GetComponent<CardScript>());
        handValue += cardValue;
        dHandVal.text = handValue.ToString();
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
        var newObj = new GameObject("hitCard", typeof(RectTransform));
        var parent = GameObject.Find("Dealer");
        var parentTransform = parent.GetComponent<Transform>();
        newObj.transform.parent = parentTransform;
        var dCard2 = GameObject.Find("dCard2");

        upnumber += 50;
        xx = 140 + upnumber;
        Debug.Log("new dealer xx value: " + xx);
        yy = dCard2.transform.position.y;
        
        UnityEngine.Vector3 newPosition = new UnityEngine.Vector3(xx, yy, 0);
        
        newObj.transform.localScale = new UnityEngine.Vector3(scale, scale, scale);
        newObj.GetComponent<RectTransform>().sizeDelta = new UnityEngine.Vector2((float)110.2668, (float)149.2806);
        newObj.transform.position = newPosition;
        UnityEngine.UI.Image NewImage = newObj.AddComponent<UnityEngine.UI.Image>(); //Add the Image Component script
        NewImage.sprite = hand[0].GetComponent<SpriteRenderer>().sprite;
        newObj.SetActive(true);



    }
    public int GetHandVal(){
        return handValue;
    }
    IEnumerator DelayCard(float delay)
    {
        while (handValue <= 16)
        {
            yield return new WaitForSeconds(delay);
            GetStandCard();
            dHandVal.text = handValue.ToString();
        }
        if(handValue >21){
            dHandVal.text = "Too Many";
        }
        Over = true;
    }
    IEnumerator DelayGetCard(float delay){
        yield return new WaitForSeconds(delay);
        GetCard();
        dHandVal.text = handValue.ToString();
    }

}
