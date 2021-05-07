using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public AudioSource audioSrc;
	public AudioClip gunSnd;
	public float shootTimer;
	public float shootTime = 1f;
	private float maxSpread = 7f;
	private float range = 40f;
	public float damage = 20f;
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
		audioSrc.PlayOneShot(gunSnd);
		for(int i = 0; i < 50; i++) {
			Debug.Log(cam.transform.forward);
			Debug.Log(Quaternion.Euler(Random.Range(-maxSpread,maxSpread), Random.Range(-maxSpread,maxSpread), Random.Range(-maxSpread,maxSpread)));
			Vector3 dir = Quaternion.Euler(Random.Range(-maxSpread,maxSpread), Random.Range(-maxSpread,maxSpread), Random.Range(-maxSpread,maxSpread)) * cam.transform.forward;
			Debug.Log(dir);
			if(Physics.Raycast(cam.transform.position, dir, out hit, range)) {
				
				Target target = hit.transform.GetComponent<Target>();
				if(target != null) {
					float damageDealt = damage;
					target.TakeDamage(damageDealt);
				}
					
			}
		}
		flashTimer = 0f;
		shootTimer = 0f;
		

	}
}
