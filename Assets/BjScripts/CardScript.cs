using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int value = 0;

    public int GetValue(){
        return value;
    }
    public void SetValue(int newVal){
        value = newVal;
    }
    public string GetSpriteName(){
        return GetComponent<SpriteRenderer>().sprite.name;
    }
    public void SetSprite(Sprite newSprite){
        
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
    public void Reset(){
        Sprite back = GameObject.Find("DeckController").GetComponent<DeckScript>().GetCardBack();
        gameObject.GetComponent<SpriteRenderer>().sprite = back;
        value = 0;
    }
}
