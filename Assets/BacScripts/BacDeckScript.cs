using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacDeckScript : MonoBehaviour
{
    public Sprite[] cardSprites;
    private int[] cardValues = new int[52];
    int cIndex = 0;
    void Start()
    {
        GetCardValues();
        string cValDebug = "";
        for (int i = 0; i < cardValues.Length; i++)
        {
            cValDebug += cardValues[i] + ",";
        }
        Debug.Log(cValDebug);
    }

    // Update is called once per frame
    void GetCardValues()
    {
        int num = 0;

        for (int i = 0; i < cardSprites.Length; i++)
        {
            num = i;
            num %= 13;
            if (num == 10 || num == 12 || num == 11)
            {
                num = 9;

            }
            

            cardValues[i] = num + 1;

        }

    }

    public void Shuffle()
    {
        for (int i = cardSprites.Length - 1; i > 0; i--)
        {
            int j = Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * cardSprites.Length - 1) + 1;
            Sprite temp = cardSprites[i];
            cardSprites[i] = cardSprites[j];
            cardSprites[j] = temp;

            int tempVal = cardValues[i];
            cardValues[i] = cardValues[j];
            cardValues[j] = tempVal;
        }
        string cValDebug = "";
        for (int i = 0; i < cardValues.Length; i++)
        {
            cValDebug += cardValues[i] + ",";
        }
        Debug.Log(cValDebug);

    }
    public int DealCard(BacCardScript cardScript)
    {
        cardScript.SetSprite(cardSprites[cIndex]);
        cardScript.SetValue(cardValues[cIndex]);
        cIndex++;
        return cardScript.GetValue();
    }
    
}