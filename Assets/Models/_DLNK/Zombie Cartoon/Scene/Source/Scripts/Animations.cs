using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour {

	public GameObject TargetChar;
    public AnimationClip Idle;
	public AnimationClip Attack01Anim;
	public AnimationClip Attack02Anim;
	public AnimationClip Attack03Anim;
	public AnimationClip GetHit01Anim;
	public AnimationClip GetHit02Anim;
	public AnimationClip GetHit03Anim;
	public AnimationClip DieAnim;
	public AnimationClip BlockAnim;
	public AnimationClip IdleSpecialAnim;
	public AnimationClip AppairAnim;
	
	public EnemyScript enemyScript; 
	//private MonoBehaviour CharControl;


	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
		EnemyScript.State state = enemyScript.state;
		if (state == EnemyScript.State.ATTACK)
			TargetChar.GetComponent<Animation>().Play (Attack01Anim.name);

        else if (state == EnemyScript.State.IDLE)
            TargetChar.GetComponent<Animation>().Play(Idle.name);

        else if(state == EnemyScript.State.WALK)
			TargetChar.GetComponent<Animation>().Play("walkzombie");
		else if(state == EnemyScript.State.RUN)
			TargetChar.GetComponent<Animation>().Play("runzombie");
		else if(state == EnemyScript.State.DEAD)
			TargetChar.GetComponent<Animation>().Play(DieAnim.name);
		
	}
}
