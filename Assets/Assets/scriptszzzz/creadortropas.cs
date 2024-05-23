using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class creadortropas : MonoBehaviour
{
    public creadorderecuersos cheeseEconomy; 
    public creadorderecuersos fishEconomy; 
    public creadorderecuersos flyEconomy; 

    public GameObject ratPrefab; 
    public GameObject catPrefab; 
    public GameObject spiderPrefab; 

    public Transform ratSpawnPoint; 
    public Transform catSpawnPoint; 
    public Transform spiderSpawnPoint; 

    private int ratCost = 15;
    private int catCost = 15;
    private int spiderCost = 10;

    public TextMeshProUGUI errorMessage;

    private int troopLimit = 50;
    public GameObject tiendagay;
    public GameObject botonabrir;

    public void PurchaseRat()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length >= troopLimit)
        {
            errorMessage.text = "Límite de tropas alcanzado.";
            return;
        }

        if (cheeseEconomy.currentCheese >= ratCost)
        {
            cheeseEconomy.currentCheese -= ratCost;
            Instantiate(ratPrefab, ratSpawnPoint.position, ratSpawnPoint.rotation);
            errorMessage.text = ""; 
        }
        else
        {
            errorMessage.text = "No tienes suficiente queso para comprar una rata.";
        }
    }

    public void PurchaseCat()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length >= troopLimit)
        {
            errorMessage.text = "Límite de tropas alcanzado.";
            return;
        }

        if (fishEconomy.currentFish >= catCost)
        {
            fishEconomy.currentFish -= catCost;
            Instantiate(catPrefab, catSpawnPoint.position, catSpawnPoint.rotation);
            errorMessage.text = ""; 
        }
        else
        {
            errorMessage.text = "No tienes suficiente pescado para comprar un gato.";
        }
    }

    public void PurchaseSpider()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length >= troopLimit)
        {
            errorMessage.text = "Límite de tropas alcanzado.";
            return;
        }

        if (flyEconomy.currentFly >= spiderCost)
        {
            flyEconomy.currentFly -= spiderCost;
            Instantiate(spiderPrefab, spiderSpawnPoint.position, spiderSpawnPoint.rotation);
            errorMessage.text = ""; // Limpiar el mensaje de error
        }
        else
        {
            errorMessage.text = "No tienes suficientes moscas para comprar una araña.";
        }
    }

   

    public void ShowStore()
    {
        tiendagay.SetActive(true);
        botonabrir.SetActive(false);
    }

    public void HideStore()
    {
        tiendagay.SetActive(false);
        botonabrir.SetActive(true);
    }
}
