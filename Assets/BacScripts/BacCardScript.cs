using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacCardScript : MonoBehaviour
{
    public int value = 0;

    public int GetValue()
    {
        return value;
    }
    public void SetValue(int newVal)
    {
        value = newVal;
    }
    public string GetSpriteName()
    {
        return GetComponent<SpriteRenderer>().sprite.name;
    }
    public void SetSprite(Sprite newSprite)
    {

        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}
