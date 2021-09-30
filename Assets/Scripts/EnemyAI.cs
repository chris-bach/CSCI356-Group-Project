using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour{
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;

	private NavMeshAgent nm;
	public Transform target;
    [SerializeField] private float viewDistance = 5F;
    [SerializeField] private float attackDistance = 1f;
	public enum AIState{idle,running,attacking}
	public AIState aiState = AIState.idle;
	Animator charAnim;

    void Start(){
    	charAnim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    	nm = GetComponent<UnityEngine.AI.NavMeshAgent>();
    	StartCoroutine(Think());
    }

    void Update(){
        
    }

    IEnumerator Think(){
    	while(true){
    		float dist = Vector3.Distance(target.position,transform.position);

            switch (aiState) {
                case AIState.idle:
                    if (dist < viewDistance) aiState = AIState.running;
                    charAnim.SetTrigger("Idle");
                    nm.SetDestination(transform.position);
                    break;
                case AIState.running:
                    nm.SetDestination(target.position);
                    charAnim.SetTrigger("Running");
                    if (dist > viewDistance) {
                        aiState = AIState.idle;
                    }
                    else if (dist < attackDistance)
                    {
                        aiState = AIState.attacking;
                    }
                    break;
                case AIState.attacking:
                    if (dist < attackDistance) aiState = AIState.attacking;
                    charAnim.SetTrigger("Attacking");
                    Destroy(gameObject);


                    if(OnEnemyKilled != null){
                        OnEnemyKilled();
                    }
                    /*
                    if (dist > viewDistance)
                    {
                        aiState = AIState.idle;
                    }
                    else if (dist < viewDistance && dist > attackDistance)
                    {
                        aiState = AIState.running;
                    }*/
                    break;
                default:
    				break;
    		}
    		//Wait for 1 second and then go through the loop again, more efficient than updating every frame
    		yield return new WaitForSeconds(0.2F);
    	}
    }

}
