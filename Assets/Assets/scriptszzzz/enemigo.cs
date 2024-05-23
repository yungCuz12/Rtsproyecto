using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemigo : MonoBehaviour
{
    public float velocidad = 5.0f;
    private NavMeshAgent agente;
    private float temporizador = 0.0f;
    private float tiempoCambioDireccion = 7.0f;
    private Transform objetivoActual;
    public string equipo;
    private Animator animador;

    private Dictionary<string, List<Transform>> puntosPorEquipo = new Dictionary<string, List<Transform>>();

  

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animador = GetComponent<Animator>();
        agente.speed = velocidad;


        InicializarPuntosPorEquipo();


        EstablecerDestinoAleatorio();
    }

    void Update()
    {
        temporizador += Time.deltaTime;

        if (temporizador >= tiempoCambioDireccion)
        {
            EstablecerDestinoAleatorio();
            temporizador = 0.0f;
        }

        animador.SetBool("caminar", agente.velocity.magnitude > 0.1f);
        if (objetivoActual != null)
        {
            agente.SetDestination(objetivoActual.position);
        }
    }

    void InicializarPuntosPorEquipo()
    {

        switch (equipo)
        {
            case "Rojo":
                puntosPorEquipo.Add("Rojo", new List<Transform>(Array.ConvertAll(GameObject.FindGameObjectsWithTag("PuntoRojo"), item => item.transform)));
                break;
            case "Azul":
                puntosPorEquipo.Add("Azul", new List<Transform>(Array.ConvertAll(GameObject.FindGameObjectsWithTag("PuntoAzul"), item => item.transform)));
                break;
            case "Verde":
                puntosPorEquipo.Add("Verde", new List<Transform>(Array.ConvertAll(GameObject.FindGameObjectsWithTag("PuntoVerde"), item => item.transform)));
                break;
            default:
                Debug.LogWarning("Equipo desconocido: " + equipo);
                break;
        }
    }

    void EstablecerDestinoAleatorio()
    {
        if (!puntosPorEquipo.ContainsKey(equipo))
        {
            Debug.LogWarning("No se encontraron puntos de destino para el equipo: " + equipo);
            return;
        }

        List<Transform> puntosDeDestino = puntosPorEquipo[equipo];

        if (puntosDeDestino.Count == 0) return;

        objetivoActual = puntosDeDestino[UnityEngine.Random.Range(0, puntosDeDestino.Count)];
    }

}
