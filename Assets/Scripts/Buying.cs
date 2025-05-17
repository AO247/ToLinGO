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
    public bool isHat = false;
    public Image productImage;
    public GameObject player; // Image component to show the product
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menus = GameObject.FindGameObjectWithTag("Menus").GetComponent<Menus>();
        priceText.text = "Price: " + price.ToString("F2");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void BuyProduct()
    {
        Debug.Log("Buying product for: " + price);
        if (menus.money >= price && !isBought)
        {
            isBought = true;
            if (isHat)
            {
                player.GetComponent<ChangePlayerOutfit>().isEquippedHat = true;
                player.GetComponent<ChangePlayerOutfit>().ChangeHat(productImage); // Assuming productImage has the hat sprite
            }
            else if (!isHat)
            {
                player.GetComponent<ChangePlayerOutfit>().isEquippedCostume = true;
                player.GetComponent<ChangePlayerOutfit>().ChangeCostume(productImage); // Assuming productImage has the hat sprite
            }
            menus.UpdateMoney(-price);
            priceText.text = "Equipped"; // Change button text to "Equipped"
        }
        else if (menus.money < price && !isBought)
        {
            Debug.Log("Not enough money!");
        }
        else if (isBought && isHat)
        {
            if (player.GetComponent<ChangePlayerOutfit>().isEquippedHat)
            {
                Debug.Log("Removing hat");
                priceText.text = "Equip"; // Assuming productImage has the hat sprite
                player.GetComponent<ChangePlayerOutfit>().isEquippedHat = false;
                player.GetComponent<ChangePlayerOutfit>().ChangeHat(null);
                Debug.Log("Hat removed");
                // Assuming productImage has the hat sprite
            }
            else
            {
            player.GetComponent<ChangePlayerOutfit>().isEquippedHat = true;
            player.GetComponent<ChangePlayerOutfit>().ChangeHat(productImage);
            priceText.text = "Equipped"; // Assuming productImage has the hat sprite
            }
        }
        else if (isBought && !isHat)
        {
            if (player.GetComponent<ChangePlayerOutfit>().isEquippedCostume)
            {
                player.GetComponent<ChangePlayerOutfit>().isEquippedCostume = false;
                player.GetComponent<ChangePlayerOutfit>().ChangeCostume(null);
                priceText.text = "Equip"; // Assuming productImage has the hat sprite
            }
            else
            {
                player.GetComponent<ChangePlayerOutfit>().isEquippedCostume = true;
                player.GetComponent<ChangePlayerOutfit>().ChangeCostume(productImage);
                priceText.text = "Equipped"; // Assuming productImage has the hat sprite
            }
        }
    }
}
