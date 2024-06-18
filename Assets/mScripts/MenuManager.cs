using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //public Button playBj;
    //public Button playBac;
    //public Button playR;
    // Start is called before the first frame update
    void Start()
    {
        //playBj.onClick.AddListener(() => bjClicked());
        //playBac.onClick.AddListener(() => bacClicked());
        //playR.onClick.AddListener(() => rClicked());
    }
    public void bjClicked(){
        SceneManager.LoadScene("BlackJack");
        Debug.Log("test");
           }
    public void bacClicked(){
        SceneManager.LoadScene("Baccarat");
    }
    public void rClicked(){
        SceneManager.LoadScene("Roulette");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
