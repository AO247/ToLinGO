using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    public float money = 200f; // Przykładowa wartość początkowa
    public TextMeshProUGUI moneyText;
    public int strike = 0;
    public TextMeshProUGUI strikeText;

    void Start()
    {
        ResetStrike();
        UpdateMoney(0);
    }

    public void UpdateMoney(float amount)
    {
        money += amount;
        moneyText.text = "Money: " + money.ToString("F2");
    }

    public void UpdateStrike()
    {
        strike++;
        strikeText.text = "Strikes: " + strike.ToString();
    }

    public void ResetStrike()
    {
        strike = 0;
        strikeText.text = "Strikes: " + strike.ToString();
    }
}
