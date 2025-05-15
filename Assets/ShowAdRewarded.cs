using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShowAdRewarded : MonoBehaviour
{
   
   
    public Text text;
    public bool toRemove;
    public static ShowAdRewarded Instance = null;
    public void Start()
    {
        text.gameObject.SetActive(true);
        text.text = "Welcome!!";
        Instance = this;
    }
    void OnEnable()
    {
        text.text = "Welcome!!";
    }
    public void LoadAd()
    {

        ShowAd();
       

    }
    public void ShowAd()
    {
        if (AdmobVNTIS_Interstitial._isAdLoaded())
        {
            AdmobVNTIS_Interstitial._showInterstitialImmediately();
            GlobalValue.TotalStarEarned += 15;
            GlobalValue.SavedStar += 15;
            
            Toast.showText("You have been awarded 15 stars", 1);
            
            this.gameObject.SetActive(false);
        }
        else
        {
            Toast.showText("Ad can't be loaded", 1);
            this.gameObject.SetActive(false);
        }
        
        
     
        
    }
    

  
  

}


