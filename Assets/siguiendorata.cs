using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class siguiendorata : StateMachineBehaviour
{
    controlatacar controlatacar;
    NavMeshAgent rata;
    public float rangoataque = 1f;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        rata = animator.transform.GetComponent<NavMeshAgent>();
        controlatacar = animator.transform.GetComponent<controlatacar>();
       
        controlatacar.setcorretear();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (controlatacar.Objetivo == null) {


            animator.SetBool("siguiendo", false);

        }
        else
        {
            if (animator.transform.GetComponent<movimientorata>().comando==false)
            {
               
                rata.SetDestination(controlatacar.Objetivo.position);
                animator.transform.LookAt(controlatacar.Objetivo);
                

                float distanciaobjetivo = Vector3.Distance(controlatacar.Objetivo.position, animator.transform.position);
               
                if (distanciaobjetivo < rangoataque)
                {
                   rata.SetDestination(animator.transform.position);

                    Debug.Log("ya te cargo la chingada");
                  
                    animator.SetBool("atacar", true);

                   
                }
               
            }
        }

      


    }



}
