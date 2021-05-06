using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGlide : MonoBehaviour
{
	public float speed = 80;
	public float downDir = -20f;
	private Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
         CharacterController controller = GetComponent<CharacterController>();
		 
		
		 
		 moveDirection = transform.forward;
		 //moveDirection = transform.TransformDirection(moveDirection);
		 moveDirection *= speed * Time.deltaTime;
		 moveDirection.y += downDir * Time.deltaTime;

		
		controller.Move(moveDirection);
		
		//disable glide when hit the ground
		if(controller.isGrounded)  {
			PMovement move = GetComponent<PMovement>();
			move.enabled = true;
			enabled = false;
		}
    }
}
