using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public float dam = 5f;
	public float range = 20f;
	public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
			Shoot();
    }
	void Shoot() {
		RaycastHit shot;
		if(Physics.Raycast(cam.transform.position, cam.transform.forward, out shot, range)) {
			Debug.Log(shot.transform.name);
		}
	}
}
