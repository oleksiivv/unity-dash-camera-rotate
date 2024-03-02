using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSkinItem : MonoBehaviour
{
    public bool isDefault=false;

    public GameObject buyButton, chooseButton;

    public GameObject isAvailableFlag;

    public Text priceText;

    public int price;

    public int id;

    public Image image;

    public Color32 normalColor, activeColor;

    public Text coinsAmount;

    public List<ShopSkinItem> items;

    void Start(){
        ShowState();
    }

    public void ShowState(){
        coinsAmount.text = PlayerPrefs.GetInt("coins", 0).ToString();

        image.GetComponent<Image>().color = normalColor;
        buyButton.SetActive(true);
        priceText.gameObject.SetActive(true);

        priceText.text = price.ToString();
        
        if(IsAvailable()){
            buyButton.SetActive(false);
            isAvailableFlag.SetActive(true);
            priceText.gameObject.SetActive(false);

            if(IsCurrent()){
                buyButton.SetActive(false);

                isAvailableFlag.SetActive(false);

                image.GetComponent<Image>().color = activeColor;
            }
        }
    }

    public void Buy(){
        if(PlayerPrefs.GetInt("coins", 0) >= price){
            PlayerPrefs.SetInt("skin_available_"+id.ToString(), 1);
            PlayerPrefs.SetInt("current_skin", id);
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - price);

            foreach(var item in items)item.ShowState();
        }
    }

    public void Choose(){
        if(IsAvailable()){
            PlayerPrefs.SetInt("current_skin", id);

            foreach(var item in items)item.ShowState();
        }
    }

    public bool IsCurrent(){
        return PlayerPrefs.GetInt("current_skin", 0) == id;
    }

    public bool IsAvailable(){
        return isDefault || PlayerPrefs.GetInt("skin_available_"+id.ToString(), 0) == 1;
    }
}
