using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BankerScript : MonoBehaviour
{
    public BacCardScript cardScript;
    public BacDeckScript deckScript;
    public int handValue = 0;
    public GameObject[] hand;
    public int cardIndex = 0;
    public Text bHandVal;
    private float scale = (float) 1.494164;
    private float thirdCardY = (float) -130;
    private float thirdCardX = (float) 0;
    
    public GameObject bCard3;
    public UnityEngine.UI.Image imgRenderer;
    public void StartHand()
    {
        StartCoroutine(DelayGetFirstCard(1f));
        StartCoroutine(DelayGetSecondCard(3f));
        StartCoroutine(DelayGetThirdCard(4f));
    }

    public int GetFirstCard()
    {


        int cardValue = deckScript.DealCard(hand[0].GetComponent<BacCardScript>());
        //show card on game screen


        imgRenderer = hand[cardIndex].GetComponent<UnityEngine.UI.Image>();
        imgRenderer.sprite = hand[cardIndex].GetComponent<SpriteRenderer>().sprite;
        handValue += cardValue;
        cardIndex++;

        return handValue;
    }
    public int GetSecondCard(){
        int cardValue = deckScript.DealCard(hand[1].GetComponent<BacCardScript>());
        //show card on game screen


        imgRenderer = hand[cardIndex].GetComponent<UnityEngine.UI.Image>();
        imgRenderer.sprite = hand[cardIndex].GetComponent<SpriteRenderer>().sprite;
        handValue += cardValue;
        cardIndex++;

        return handValue;
    }
    public void GetThirdCard(){
        int cardValue = deckScript.DealCard(hand[0].GetComponent<BacCardScript>());
        handValue += cardValue;
        bHandVal.text = handValue.ToString();
        
        var newObj = new GameObject("bCard3", typeof(RectTransform));
        var parent = GameObject.Find("Banker");
        var parentTransform = parent.GetComponent<Transform>();
        newObj.transform.parent = parentTransform;
        var bCard2 = GameObject.Find("bCard2");

        
        
        
        
        //UnityEngine.Vector3 newPosition = new UnityEngine.Vector3(thirdCardX, thirdCardY, thirdCardX);
        
        newObj.transform.localScale = new UnityEngine.Vector3(scale, scale, scale);
        newObj.GetComponent<RectTransform>().sizeDelta = new UnityEngine.Vector2((float)110.2668, (float)149.2806);
        newObj.transform.position = bCard3.transform.position;
        UnityEngine.Quaternion newRotation = UnityEngine.Quaternion.Euler (0,0, 90);
        newObj.transform.rotation = newRotation;
        UnityEngine.UI.Image NewImage = newObj.AddComponent<UnityEngine.UI.Image>(); //Add the Image Component script
        NewImage.sprite = hand[0].GetComponent<SpriteRenderer>().sprite;
        newObj.SetActive(true);
    }
    IEnumerator DelayGetFirstCard(float delay){
        yield return new WaitForSeconds(delay);
        GetFirstCard();
        bHandVal.text = handValue.ToString();
    }
    IEnumerator DelayGetSecondCard(float delay){
        yield return new WaitForSeconds(delay);
        GetSecondCard();
        bHandVal.text = handValue.ToString();
    }
    IEnumerator DelayGetThirdCard(float delay){
        yield return new WaitForSeconds(delay);
        GetThirdCard();
        bHandVal.text = handValue.ToString();
    }
    void Update(){
        if(handValue>=10){
            handValue %= 10;
            Debug.Log("fart");
            bHandVal.text = handValue.ToString();
        }
    }
    public int GetHandVal(){
        return handValue;
    }
}
