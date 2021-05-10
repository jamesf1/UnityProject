using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
	public GameObject enemyObj;
	private float spawnTimer = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log("incrementing");
		Debug.Log(spawnTimer);
		spawnTimer --;
		if(spawnTimer <= 0) {
			Debug.Log("spawning");
			spawnTimer = 100f;
			GameObject enemy = Instantiate(enemyObj, gameObject.transform);
			enemy.transform.position = transform.position;
			EnemyScript enemyScript = enemy.GetComponent<EnemyScript>();
			enemyScript.Alert();
			
			
		}
    }
}
