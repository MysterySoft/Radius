using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject prefab_to_spawn, current_enemy;

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
		
		if (current_enemy == null) 
		{
		
			//Instantiate (prefab_to_spawn,transform.position,prefab_to_spawn.transform.localRotation);

			Instantiate (prefab_to_spawn,transform.position,prefab_to_spawn.transform.localRotation ,transform);

			current_enemy = transform.Find ("Enemy(Clone)").gameObject;
		
		}

	}
}
