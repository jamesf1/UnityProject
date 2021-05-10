using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public enum State {
		IDLE, WALK, RUN, ATTACK, DEAD
	}
	public float walkSpeed = 5f;
	public float runSpeed = 10f;
	public float angularSpeed = 700;
	public float acc;
	public float attackDistance = 2f;
	private GameObject target = null;
	Vector3 move;
	
	private float wanderTimer = 50f;
	private float wanderTime = 50f;
	private float dieTimer = 100f;
	private float wanderDist; 

	private float chaseDistance = 40f;
	
	public State state;
	public UnityEngine.AI.NavMeshAgent navAgent;
	private AnimationState anim;

    // Start is called before the first frame update
    void Start()
    {
		if(target == null) {
			GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
			target = player;
		}
		Debug.Log(target);
        state = State.WALK;
		wanderDist = wanderTime * walkSpeed;
		
		//Randomize enemy movement to create unpredictable behavior
		float moveMod = Random.Range(.9f,1.4f);
		walkSpeed *= moveMod;
		runSpeed *= moveMod;
		navAgent.acceleration = moveMod * acc;
		
		float angularMod = Random.Range(.9f, 1.5f);
		navAgent.angularSpeed = angularSpeed * angularMod;
		
		
    }

    // Update is called once per frame
    void Update()
    {
		if(state == State.WALK)
			Wander();
		else if(state == State.RUN) 
			Chase();
		else if(state == State.DEAD) {
			dieTimer--;
			if(dieTimer < 0)
				Destroy(this.gameObject);
		}

    }
	
	void Wander() {
		navAgent.isStopped= false;
		navAgent.speed = walkSpeed;
		wanderTimer += Time.deltaTime;
		if(wanderTimer >= wanderTime) {
			move = getRandomDest();
		}
		navAgent.SetDestination(move);
		
		if(Vector3.Distance(transform.position, target.transform.position) <= chaseDistance) {
			state = State.RUN;
			AlertFriends();
		}
	}
	void Chase() {
		navAgent.SetDestination(target.transform.position);
	}
	
	public void Alert() {
		if(state != State.RUN) {
			navAgent.isStopped= false;
			navAgent.speed = runSpeed;
			state = State.RUN;
			AlertFriends();
		}
	}
	
	void AlertFriends() {
		GameObject[] friends = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject friend in friends) {
			float friendDist = Vector3.Distance(friend.transform.position, transform.position);
			if(friendDist < chaseDistance)
				friend.GetComponent<EnemyScript>().Alert();
		}
	}
	
	Vector3 getRandomDest() {
			Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * wanderDist;

            randomDirection += transform.position;
           
            UnityEngine.AI.NavMeshHit navHit;
           
            UnityEngine.AI.NavMesh.SamplePosition (randomDirection, out navHit, wanderDist, -1);
           
            return navHit.position;
	}
	
	public void Die() {
		navAgent.isStopped= true;
		state = State.DEAD;
	}
	
	
	

}
