using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mouselook : MonoBehaviour
{
	[SerializeField]
	private float lookSpeed = 5;
	public float initialRot = 50f;
	private Vector2 rotation = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
		rotation.y = initialRot;
    }

    // Update is called once per frame
    void Update()
    {
        rotation.x -= Input.GetAxis("Mouse Y");
		rotation.y += Input.GetAxis("Mouse X");
		rotation.x = Mathf.Clamp(rotation.x, -20f, 20f);
		transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
		Quaternion quatRot = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
		Camera.main.transform.localRotation = quatRot;
    }
}
