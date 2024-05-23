using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnenemigo : MonoBehaviour
{
    public GameObject tropaRataPrefab;
    public GameObject tropaGatoPrefab;
    public GameObject tropaAra�aPrefab;

    public Transform[] spawnPoints;

    public float tiempoProximaRata = 15f;
   public float tiempoProximoGato = 30f;
   public float tiempoProximaAra�a = 20f;

    public float tiempoRata = 15f;
    public float tiempoGato = 30f;
    public float tiempoAra�a = 20f;

    private int contadorTropasInvocadas = 1;

    void Update()
    {
        tiempoProximaRata -= Time.deltaTime;
        tiempoProximoGato -= Time.deltaTime;
        tiempoProximaAra�a -= Time.deltaTime;

        if (tiempoProximaRata <= 0 && contadorTropasInvocadas < 10)
        {
            InvocarTropa(tropaRataPrefab);
            tiempoProximaRata = tiempoRata;
        }

        if (tiempoProximoGato <= 0 && contadorTropasInvocadas < 10)
        {
            InvocarTropa(tropaGatoPrefab);
            tiempoProximoGato = tiempoGato;
        }

        if (tiempoProximaAra�a <= 0 && contadorTropasInvocadas < 10)
        {
            InvocarTropa(tropaAra�aPrefab);
            tiempoProximaAra�a = tiempoAra�a;
        }
    }

    void InvocarTropa(GameObject tropaPrefab)
    {
        if (spawnPoints.Length == 0)
        {
            return;
        }

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(tropaPrefab, spawnPoint.position, spawnPoint.rotation);

        contadorTropasInvocadas++;
    }
}
