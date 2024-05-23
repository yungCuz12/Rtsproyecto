using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class creadorderecuersos : MonoBehaviour
{
    public enum ResourceType { Molino, Rio, Campo }
    public ResourceType resourceType = ResourceType.Molino;

    private int baseCheeseAmount = 10; 
    private int baseFishAmount = 10; 
    private int baseFlyAmount = 10; 

    private float baseCheeseTimeInterval = 20f; 
    private float baseFishTimeInterval = 25f; 
    private float baseFlyTimeInterval = 30f; 

    private float timer;
    public int currentCheese = 0;
    public int currentFish = 0;
    public  int currentFly = 0;
    private int tropasCount = 0;

    void Start()
    {
        switch (resourceType)
        {
            case ResourceType.Molino:
                timer = baseCheeseTimeInterval;
                break;
            case ResourceType.Rio:
                timer = baseFishTimeInterval;
                break;
            case ResourceType.Campo:
                timer = baseFlyTimeInterval;
                break;
        }
        Debug.Log("Sistema de economía iniciado para " + resourceType.ToString() + ". Tiempo de producción inicial: " + timer + " segundos.");
    }

    void Update()
    {
        if (tropasCount > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                switch (resourceType)
                {
                    case ResourceType.Molino:
                        int cheeseToAdd = baseCheeseAmount + tropasCount;
                        currentCheese += cheeseToAdd;
                        Debug.Log("Queso producido: " + cheeseToAdd + ". Queso total: " + currentCheese);
                        timer = Mathf.Max(baseCheeseTimeInterval - tropasCount, 7); 
                        break;

                    case ResourceType.Rio:
                        int fishToAdd = baseFishAmount + tropasCount;
                        currentFish += fishToAdd;
                        Debug.Log("Pescado producido: " + fishToAdd + ". Pescado total: " + currentFish);
                        timer = Mathf.Max(baseFishTimeInterval - tropasCount, 7); 
                        break;

                    case ResourceType.Campo:
                        int flyToAdd = baseFlyAmount + tropasCount;
                        currentFly += flyToAdd;
                        Debug.Log("Moscas producidas: " + flyToAdd + ". Moscas total: " + currentFly);
                        timer = Mathf.Max(baseFlyTimeInterval - tropasCount, 7); 
                        break;
                }
                Debug.Log("Nuevo tiempo de producción: " + timer + " segundos.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tropasCount++;
            Animator animator = other.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("chambear", true);
            }
            Debug.Log("Tropa añadida. Total de tropas: " + tropasCount);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tropasCount--;
            Animator animator = other.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("chambear", false);
            }
            Debug.Log("Tropa retirada. Total de tropas: " + tropasCount);
        }
    }
}
