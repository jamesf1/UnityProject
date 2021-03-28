using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGlide : MonoBehaviour
{
	public float speed = 20;
	public float downDir = -5f;
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
		 Debug.Log("hey");
		 Debug.Log(moveDirection.y);
		 moveDirection.y += downDir * Time.deltaTime;
		 Debug.Log(moveDirection.y);

		 

		

		
		controller.Move(moveDirection);
    }
}
