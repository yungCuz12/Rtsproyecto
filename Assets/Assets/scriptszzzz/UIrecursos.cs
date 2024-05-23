using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIrecursos : MonoBehaviour
{
    public creadorderecuersos cheeseEconomy;
    public creadorderecuersos fishEconomy; 
    public creadorderecuersos flyEconomy; 

    public TextMeshProUGUI cheeseText;
    public TextMeshProUGUI fishText; 
    public TextMeshProUGUI flyText;

    public TextMeshProUGUI troopCountText;
    private int troopLimite = 50;

    void Update()
    {
        UpdateResourceUI();
        UpdateTroopCount();
    }

    void UpdateResourceUI()
    {
        cheeseText.text = "Queso: " + cheeseEconomy.currentCheese;
        fishText.text = "Pescado: " + fishEconomy.currentFish;
        flyText.text = "Moscas: " + flyEconomy.currentFly;
    }

void UpdateTroopCount()
{
    int playerTroopCount = GameObject.FindGameObjectsWithTag("Player").Length;
    troopCountText.text = playerTroopCount + " / " + troopLimite;
}
}
