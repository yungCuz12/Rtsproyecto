using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnenemigo : MonoBehaviour
{
    public GameObject tropaRataPrefab;
    public GameObject tropaGatoPrefab;
    public GameObject tropaArañaPrefab;

    public Transform[] spawnPoints;

    public float tiempoProximaRata = 15f;
   public float tiempoProximoGato = 30f;
   public float tiempoProximaAraña = 20f;

    public float tiempoRata = 15f;
    public float tiempoGato = 30f;
    public float tiempoAraña = 20f;

    private int contadorTropasInvocadas = 1;

    void Update()
    {
        tiempoProximaRata -= Time.deltaTime;
        tiempoProximoGato -= Time.deltaTime;
        tiempoProximaAraña -= Time.deltaTime;

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

        if (tiempoProximaAraña <= 0 && contadorTropasInvocadas < 10)
        {
            InvocarTropa(tropaArañaPrefab);
            tiempoProximaAraña = tiempoAraña;
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
