using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Note: Developed with knowledge from this tutorial: https://www.youtube.com/watch?v=Sqb-Ue7wpsI&t=3432s
public class PMovement : MonoBehaviour
{
	private float speed = 7f; 
    private Vector3 moveDirection = Vector3.zero;
	private float jumpHeight = 10f;
	private float vspeed = 0f;
	private float gravity = 15f;
	
	 
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
		vspeed -= gravity * Time.deltaTime;
		moveDirection.y = vspeed * Time.deltaTime;
		
		controller.Move(moveDirection);
    }
	

	void Jump() {

		vspeed = jumpHeight;
	}
}
