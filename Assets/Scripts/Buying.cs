using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Buying : MonoBehaviour
{
    public float price = 50f; // Przykładowa cena
    public TextMeshProUGUI priceText;
    public Menus menus;
    public Button buyButton;
    public bool isBought = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menus = GameObject.FindGameObjectWithTag("Menus").GetComponent<Menus>();
        priceText.text = "Price: " + price.ToString("F2");
    }

    public void BuyProduct()
    {
        Debug.Log("Buying product for: " + price);
        if (menus.money >= price && !isBought)
        {
            isBought = true;
            buyButton.interactable = false; // Disable the button after purchase
            menus.UpdateMoney(-price);
        }
        else
        {
            Debug.Log("Not enough money!");
        }
        Debug.Log("Current money: " + menus.money);
    }
}
