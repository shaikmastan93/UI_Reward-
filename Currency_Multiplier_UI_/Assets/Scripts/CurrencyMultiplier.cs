using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CurrencyMultiplier : MonoBehaviour
{

    // Movement
    private float totalEarningCoins;

    // Exposed for editing in the Inspector
    [SerializeField] public int rewardedCoins;

    // UI Elements
    [SerializeField] private TextMeshProUGUI video2xCoins;
    [SerializeField] private TextMeshProUGUI normalCoinsInLevel;

    // Animator and Slider
    [SerializeField] private Animator anim;
    public bool stopAnim;

    // Arrow Position and Multiplier
    public RectTransform arrow;
    private float multi;

    private bool isVideoButtonPressed = false;

    public void Start()
    {
        // Initialize rewardedCoins to a default value
        // This can be edited in the Unity Inspector
        // rewardedCoins = 100;
    }

    public void Update()
    {
        if (!stopAnim)
        {
            _BarValue();
          

            // Method to determine the multiplier based on arrow position
            if (-69 < arrow.localPosition.x && 69 > arrow.localPosition.x)
            {
                Debug.Log("3X");
                multi = 3.0f;
            }
            else if (-176 < arrow.localPosition.x && 185 > arrow.localPosition.x)
            {
                Debug.Log("2X");
                multi = 2.0f;
            }
            else if (-257 < arrow.localPosition.x && 257 > arrow.localPosition.x)
            {
                Debug.Log("X1.5");
                multi = 1.5f;
            }
        }
    }

    public void _BarValue()
    {
        if (!stopAnim && !isVideoButtonPressed)
        {
            // Calculate total earned coins and update the UI
            totalEarningCoins = rewardedCoins * multi;
            video2xCoins.text = "+ " + (totalEarningCoins);
            

            // Assuming normalCoinsInLevel should also be updated

        }
        
    }

    public void OnVideoButtonPress()
    {
        // Method called when the video button is pressed
        anim.enabled = false;
        stopAnim = true;
        isVideoButtonPressed = true;
        normalCoinsInLevel.text = totalEarningCoins.ToString();

        // Stop further calculations or UI updates
        // Additional logic can be added here if needed
    }

    public void VideoSuccessFullyWatched(bool isSuccess)
    {
        if (isSuccess && !isVideoButtonPressed)
        {
            // Assuming UIManager is a singleton or has a static instance
            UIManager.instance.AddCoins(totalEarningCoins);
         

        }
    }


}
