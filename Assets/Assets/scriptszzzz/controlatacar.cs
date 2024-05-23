using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlatacar : MonoBehaviour
{
   public Transform Objetivo;
    public Material idle;
    public Material corretenado;
    public Material atacando;

    public bool esnpc;

   public int daño;
    public string equipo;

   

    private void OnTriggerEnter(Collider other)
    {
        controlatacar controlObjetivo = other.GetComponent<controlatacar>();
        if (controlObjetivo != null && controlObjetivo.equipo != equipo)
        {
            Objetivo = other.transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        controlatacar controlObjetivo = other.GetComponent<controlatacar>();
        if (controlObjetivo != null && controlObjetivo.equipo != equipo)
        {
            Objetivo = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        controlatacar controlObjetivo = other.GetComponent<controlatacar>();
        if (controlObjetivo != null && Objetivo != null && other.transform == Objetivo.transform && controlObjetivo.equipo == equipo)
        {
            Objetivo = null;
        }
    }

    public void setidle()
    {
      // GetComponent<Renderer>().material=idle;
    }

    public void setcorretear()
    {
       // GetComponent<Renderer>().material = corretenado;
    }

    public void setatacar()
    {
       // GetComponent<Renderer>().material = atacando;
    }

    private void OnDrawGizmo()
    {
        //distancia de seguir
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.6f * 13.8351f);
        //distancia de ataque
         Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
        //dustancio de paro
         Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 1.2f);

    }
}
