using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlarbase : MonoBehaviour
{
    public float vidaMaxima = 1000f;
    public  float vida;
    public HealthTracker healthTracker;

    public GameObject spawnerEnemigo;

    private float temporizadorAtaque = 0.0f;
    private float tiempoEntreAtaques = 5.0f;

    public string tagEnemigo;
    public string BasePlayer;
    public string tagAliado;

    public Material materialBaseJugador;
    public Material materialBaseRojo;
    public Material materialSinDueno;

    public List<GameObject> tropasEnemigasCercanas = new List<GameObject>();
    public List<GameObject> tropasAliadasCercanas = new List<GameObject>();

    public Renderer baseRenderer;

    public GameObject victoriaCanvas;
    public GameObject derrotaCanvas;



    void Start()
    {
        vida = vidaMaxima;
        actualizarVida();
        baseRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        temporizadorAtaque += Time.deltaTime;

        if (temporizadorAtaque >= tiempoEntreAtaques)
        {
            temporizadorAtaque = 0.0f;
            ProcesarAtaque();
        }

        // Actualizar las listas de tropas cercanas
        ActualizarListasDeTropas();

      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagEnemigo) || other.CompareTag(tagAliado))
        {
            GameObject tropa = other.gameObject;

            if (tropa.CompareTag(tagEnemigo) && !tropasEnemigasCercanas.Contains(tropa))
            {
                tropasEnemigasCercanas.Add(tropa);
            }
            else if (tropa.CompareTag(tagAliado) && !tropasAliadasCercanas.Contains(tropa))
            {
                tropasAliadasCercanas.Add(tropa);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagEnemigo) || other.CompareTag(tagAliado))
        {
            GameObject tropa = other.gameObject;

            if (tropasEnemigasCercanas.Contains(tropa))
            {
                tropasEnemigasCercanas.Remove(tropa);
            }
            else if (tropasAliadasCercanas.Contains(tropa))
            {
                tropasAliadasCercanas.Remove(tropa);
            }
        }
    }

    void ProcesarAtaque()
    {
        if (tropasEnemigasCercanas.Count > 0 && tropasAliadasCercanas.Count == 0)
        {
            float danio = 100 + (tropasEnemigasCercanas.Count * 100);
            vida -= danio;
            actualizarVida();

            if (vida <= 0)
            {
                if (CompareTag("BasePlayer"))
                {
                   
                    vida = 0;
                    actualizarVida();
                   
                }
                else
                {
                    
                    tag = "SinDueno";
                    if (spawnerEnemigo != null)
                    {
                        Destroy(spawnerEnemigo);
                       
                    }
                }
            }
        }

        if (CompareTag("SinDueno") && tropasEnemigasCercanas.Count > 0)
        {
            StartCoroutine(ReconquistarBase());
        }
    }

    void ActualizarListasDeTropas()
    {
        tropasEnemigasCercanas.RemoveAll(tropa => tropa == null || !tropa.activeInHierarchy);
        tropasAliadasCercanas.RemoveAll(tropa => tropa == null || !tropa.activeInHierarchy);
    }

    IEnumerator ReconquistarBase()
    {
        yield return new WaitForSeconds(10);

        if (tropasEnemigasCercanas.Count > 0)
        {
            tag = BasePlayer;
            vida = vidaMaxima;
            actualizarVida();

            // Cambiar el material de la base
            if (tag == "BasePlayer")
            {
                baseRenderer.material = materialBaseJugador;
            }
            else if (tag == "BaseEnemiga" +
                "")
            {
                baseRenderer.material = materialBaseRojo;
            }
            else if (tag == "SinDueno")
            {
                baseRenderer.material = materialSinDueno;
            }
        }
    }

    void actualizarVida()
    {
        healthTracker.UpdateSliderValue(vida, vidaMaxima);
    }

   

}
