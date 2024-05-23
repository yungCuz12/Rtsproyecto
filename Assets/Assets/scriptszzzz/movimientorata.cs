using UnityEngine;
using UnityEngine.AI;

public class movimientorata : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    private Animator animator;
    private static readonly int Caminando = Animator.StringToHash("caminar");
    public LayerMask ground;

    public bool comando;



    private void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                comando = true;
                agent.SetDestination(hit.point);
                animator.SetBool("caminar", true);
            }
        }
        if(agent.hasPath == false || agent.remainingDistance <= agent.stoppingDistance ) {

            comando = false;
            animator.SetBool("caminar", false);
        }
        else
        {
            animator.SetBool("caminar", true);
        }
       
    }
}
