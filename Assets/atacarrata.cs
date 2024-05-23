using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class atacarrata : StateMachineBehaviour
{
    NavMeshAgent rata;
    controlatacar controlatacar;
    Rata tipo;
 
    public float ataquedistan = 1.1f;

    public float velocidadataque ;
    private float timerataque;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
 {
        rata = animator.GetComponent<NavMeshAgent>();
        controlatacar = animator.GetComponent<controlatacar>();
        tipo = animator.GetComponent<Rata>();

        switch (tipo.tipoTropa)
        {
            case Rata.TipoTropa.Raton:
                velocidadataque = 1f;
                break;
            case Rata.TipoTropa.Gato:
                velocidadataque = 0.5f; // Gatos atacan más lento
                break;
            case Rata.TipoTropa.Escorpion:
                velocidadataque = 2f; // Escorpiones atacan más rápido
                break;
        }
        controlatacar.setatacar();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      if(controlatacar.Objetivo != null && animator.transform.GetComponent<movimientorata>().comando == false)
        {
            mirarpresa();
            Debug.Log("voy por ese puto");
           // rata.SetDestination(controlatacar.Objetivo.position);

            if (timerataque <= 0)
            {
                atacar();
                timerataque = 1f / velocidadataque;
                Debug.Log("Atacando...");
            }
            else
            {
                timerataque -= Time.deltaTime;
                Debug.Log("Esperando para atacar, tiempo restante: " + timerataque);
            }


            //esta en rango

            float distanciaobjetivo = Vector3.Distance(controlatacar.Objetivo.position, animator.transform.position);

            if (distanciaobjetivo > ataquedistan || controlatacar.Objetivo==null)
            {
               
                animator.SetBool("atacar", false);
            }
            
        }
        else
        {

            animator.SetBool("atacar", false);
        }
    }

    private void atacar()
    {

        //atacando
        var danoinfligido = controlatacar.daño;

        controlatacar.Objetivo.GetComponent<Rata>().recibirdano(danoinfligido);
    }

    private void mirarpresa()
    {
      Vector3 direccion  = controlatacar.Objetivo.position - rata.transform.position;
        rata.transform.rotation = Quaternion.LookRotation(direccion);

        var yrotacion = rata.transform.eulerAngles.y;
        rata.transform.rotation = Quaternion.Euler(0, yrotacion, 0);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
       
    }

    
}
