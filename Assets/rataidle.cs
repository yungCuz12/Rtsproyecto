using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rataidle : StateMachineBehaviour
{
    controlatacar controlatacar;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        controlatacar = animator.transform.GetComponent<controlatacar>();
        controlatacar.setidle();
   }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks

   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (controlatacar.Objetivo != null)
        {
            animator.SetBool("siguiendo",true) ;
        }
   }

 
  
}
