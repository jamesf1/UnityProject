using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public float dam = 5f;
	public float shootTimer;
	public float shootTime = 1f;
	public float range = 20f;
	public float damageFalloff;
	public float damage;
	public Camera cam;
	public GameObject muzzleFlash;
	
	private float flashTimer = 1f;
	private float flashTime = .1f;
    // Start is called before the first frame update
    void Start()
    {
        shootTimer = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
		flashTimer += Time.deltaTime;
		shootTimer += Time.deltaTime;
		if(flashTimer >= flashTime) 
			muzzleFlash.SetActive(false);
		else
			muzzleFlash.SetActive(true);
        if(Input.GetMouseButtonDown(0) && shootTimer >= shootTime)
			Shoot();
    }
	void Shoot() {
		RaycastHit hit;

		if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)) {
			
			Target target = hit.transform.GetComponent<Target>();
			if(target != null) {
				float dist = Vector3.Distance(transform.position, hit.transform.position);
				float damageDealt = (range / (dist * damageFalloff)) * damage;
				Debug.Log(damageDealt);
			}
				
		}
		flashTimer = 0f;
		shootTimer = 0f;
		

	}
}
