using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Note: Developed with knowledge from this tutorial: https://www.youtube.com/watch?v=Sqb-Ue7wpsI&t=3432s
public class PMovement : MonoBehaviour
{
	public float speed ; 
	public AudioClip ouchSnd;
	public AudioClip finishSnd;
	public AudioClip finishSnd2;
	public AudioSource audioSrc;
    private Vector3 moveDirection = Vector3.zero;
	private float jumpHeight = 10f;
	private float damageHeight = 20f;
	private float invulnTime= 0f; //player is invulnerable shortly after a hit
	private float vspeed = 0f;
	private float gravity = 15f;
	private int health = 4;
	private bool finishSndPlayed = false;
	 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
         CharacterController controller = GetComponent<CharacterController>();
		 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		 moveDirection = transform.TransformDirection(moveDirection);
		 moveDirection *= speed * Time.deltaTime;
		 
		 
		if( controller.isGrounded && Input.GetKeyDown(KeyCode.Space) ) 
			Jump();
		if(Input.GetKeyDown(KeyCode.Return))
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		vspeed -= gravity * Time.deltaTime;
		moveDirection.y = vspeed * Time.deltaTime;
		
		controller.Move(moveDirection);
		
		invulnTime--;
    }
	
	void OnCollisionEnter(Collision collision) {
		GameObject obj = collision.gameObject;
		if(obj.tag == "nextScene")
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		//else if(obj.tag == "Enemy")
		//	takeDamage();
	}
	
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Enemy" && invulnTime <= 0f)
			takeDamage();
		else if(other.gameObject.tag == "Finish" && finishSndPlayed == false) {
			GameObject[] spawners = GameObject.FindGameObjectsWithTag("spawn");
			foreach(GameObject spawner in spawners) {
				spawner.GetComponent<SpawnerScript>().enabled = true;
			}
			finishSndPlayed = true;
			audioSrc.PlayOneShot(finishSnd);
			audioSrc.PlayOneShot(finishSnd2);
		}		
	}
	
	void takeDamage() {
		audioSrc.PlayOneShot(ouchSnd);
		invulnTime = 10f;
		health--;
		vspeed = damageHeight;
		if(health <= 0)
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	void Jump() {

		vspeed = jumpHeight;
	}
}
