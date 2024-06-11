using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerScript : MonoBehaviour
{
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
    private float xx = (float)728.6673;
    private float yy = 0;
    private float timer;
    // tracking aces for conversion between 1 and 11
    List<CardScript> aceList = new List<CardScript>();
    public UnityEngine.UI.Image imgRenderer;
    public void StartHand()
    {
        GetCard();
        
    }
    public void StandCard()
    {
        GetCard();
        //Thread.Sleep(0.5);
        if (handValue <= 16)
        {
            
            StartCoroutine(DelayCard(2f));
            
        }
    }

    // Update is called once per frame
    // add a hand to player /dealer hand
    // use deal card ti assing scirp tan dvlau eot car don table
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

        
        xx += (float)112.0623;
        yy = dCard2.transform.position.y;
        //Debug.Log(dCard2.transform.position.x);
        Vector3 newPosition = new Vector3(xx, yy, 0);
        //Debug.Log(newPosition);

        newObj.GetComponent<RectTransform>().sizeDelta = new Vector2((float)110.2668, (float)149.2806);
        newObj.transform.position = newPosition;
        UnityEngine.UI.Image NewImage = newObj.AddComponent<UnityEngine.UI.Image>(); //Add the Image Component script
        NewImage.sprite = hand[0].GetComponent<SpriteRenderer>().sprite;
        newObj.SetActive(true);



    }
    IEnumerator DelayCard(float delay)
    {
        while (handValue <= 16)
        {
            yield return new WaitForSeconds(delay);
            GetStandCard();
        }
    }

}
