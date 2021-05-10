using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public float health = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void TakeDamage(float damage) {
		health -= damage;
		
		if(health <=0)
			GetComponent<EnemyScript>().Die();
	}
	
}
