using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public enum State {
		IDLE, WALK, RUN, ATTACK
	}
	public float walkSpeed = 5f;
	public float runSpeed = 5f;
	public float attackDistance = 2f;
	Vector3 move;
	
	private float wanderTimer = 50f;
	private float wanderTime = 50f;
	private float wanderDist; 

	
	public State state;
	public UnityEngine.AI.NavMeshAgent navAgent;
	private AnimationState anim;

    // Start is called before the first frame update
    void Start()
    {
        state = State.WALK;
		wanderDist = wanderTime * walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Wander();

    }
	
	void Wander() {
		navAgent.isStopped= false;
		navAgent.speed = walkSpeed;
		wanderTimer += Time.deltaTime;
		if(wanderTimer >= wanderTime) {
			move = getRandomDest();
		}
		navAgent.SetDestination(move);


		
		
	}
	
	Vector3 getRandomDest() {
			Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * wanderDist;

            randomDirection += transform.position;
           
            UnityEngine.AI.NavMeshHit navHit;
           
            UnityEngine.AI.NavMesh.SamplePosition (randomDirection, out navHit, wanderDist, -1);
           
            return navHit.position;
	}
	
	

}
