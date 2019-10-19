using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Testing UI controller
/// </summary>
public class UIController : MonoBehaviour {

    /// <summary>
    /// This is the image of the Health
    /// </summary>
    public Image FillImage;

    /// <summary>
    /// Set (update) health variable of the Player (this is just updating it not saving)
    /// </summary>
    public PlayerData DataAsset;

    /// <summary>
    /// Update on start
    /// Called from ---> OnStartEvent
    /// </summary>
    public void OnInitialize()
    {
        UpdateUI();
    }

    /// <summary>
    /// Adding health to Player
    /// Called from ---> "++" UI button
    /// </summary>
    public void AddHealth()
    {
        FillImage.fillAmount += 0.1f;
        UpdateAsset();
        UpdateUI();
    }

    /// <summary>
    /// Decreasing health of player
    /// Called from ---> "--" UI button
    /// </summary>
    public void SubHealt()
    {
        FillImage.fillAmount -= 0.1f;
        UpdateAsset();
        UpdateUI();
    }

    /// <summary>
    /// Update Players current health on UI
    /// </summary>
    public void UpdateUI()
    {
        FillImage.fillAmount = DataAsset.Health;
    }

    /// <summary>
    /// Update players health in PlayerData Scriptable Object 
    /// </summary>
    private void UpdateAsset()
    {
        DataAsset.Health = FillImage.fillAmount;
    }
}
