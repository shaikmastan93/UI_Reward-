using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    // Reference to the BarMeter2x3x script
    [SerializeField] CurrencyMultiplier barMeter;

    // Reference to a TextMeshProUGUI for displaying total coins
    [SerializeField] TextMeshProUGUI totalCoinsText;

    private float totalCoins;

    void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Called when the "Next" button is pressed
    public void OnNextbuttonPress()
    {
        // Implement your logic for what should happen when the "Next" button is pressed
        Debug.Log("Next Button Pressed");
    }

    // Adds coins to the total and updates the UI
    public void AddCoins(float coins)
    {
        totalCoins += coins;
        UpdateTotalCoinsUI();
    }

    // Updates the total coins UI text
    public void UpdateTotalCoinsUI()
    {
        totalCoinsText.text = "Total Coins: " + totalCoins;
    }
}
