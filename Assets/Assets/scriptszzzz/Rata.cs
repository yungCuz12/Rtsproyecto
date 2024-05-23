using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rata : MonoBehaviour
{
     private float vida;
    public float vidamaxima;

    public HealthTracker healthTracker;

    public enum TipoTropa { Raton, Gato, Escorpion }
    public TipoTropa tipoTropa;

    void Start()
    {
        managerslect.Instance.allUnitList.Add(gameObject);
        vida = vidamaxima;
        actualizarvida();
    }

    

    private void OnDestroy()
    {
        managerslect.Instance.allUnitList.Remove(gameObject);
    }

    private void actualizarvida()
    {
        healthTracker.UpdateSliderValue(vida,vidamaxima);

        if (vida <= 0)
        {
            //nuerteXD
            Destroy(gameObject);
        }
    }

    internal void recibirdano(int danoinfligido)
    {
       
        vida -= danoinfligido;
        actualizarvida();
    }


}
