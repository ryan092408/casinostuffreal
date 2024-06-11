using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankerScript : MonoBehaviour
{
    public BacCardScript cardScript;
    public BacDeckScript deckScript;
    public int handValue = 0;
    public GameObject[] hand;
    public int cardIndex = 0;
    private float xx = (float)728.6673;
    private float yy = 0;
    private float timer;
    
    public UnityEngine.UI.Image imgRenderer;
    public void StartHand()
    {
        GetCard();
    }

    public int GetCard()
    {


        int cardValue = deckScript.DealCard(hand[0].GetComponent<BacCardScript>());
        //show card on game screen


        imgRenderer = hand[cardIndex].GetComponent<UnityEngine.UI.Image>();
        imgRenderer.sprite = hand[cardIndex].GetComponent<SpriteRenderer>().sprite;
        handValue += cardValue;
        cardIndex++;

        return handValue;
    }
}
