using UnityEngine;
using System.Collections;
using System;

public class BallController : MonoBehaviour {
	public GameObject []prefab_to_generate;

	public GameObject player;
	public Camera cam;
	public float speed,size;
	float nspeed=0;
	public Texture []scins;
    MeshRenderer mesh;

	void Start () {
		mesh = GetComponent<MeshRenderer> ();
		System.Random n = new System.Random ();
		int r = n.Next(0,7);

        mesh.material.mainTexture = scins [r];

	}




	void Update()
	{
		
	}


	// Update is called once per frame

	void FixedUpdate () {
		nspeed = speed * Time.deltaTime;
		player.transform.Translate (new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0) * nspeed/transform.localScale.x);
		size = transform.localScale.x-1;// Загальний розмір гравця. Визначається по масштабуванню якоїсь однієї осі.
		if(size>8){size=8;}

		// Метод Іnput GetAxis  приймаэ значення від -1 до 1 . 0 коли клавіші відпущені. 1 коли натиснута клавіша вправо,  -1 коли вліво.

		cam.orthographicSize = 3 + size;


	}

	// Трігер на знищення хавки і збільшення розмірів іграка
	void OnTriggerEnter2D (Collider2D col)
	{    //Якщо хаваэм обёэкт з тегом "Хавка"
		if (col.tag == "food") {
		
			Destroy (col.gameObject);
			transform.localScale += new Vector3 (0.05f, 0.05f, 0.05f);
		

			//Minimum
			// Х -30
			// Y 40 

			//x30
			//y-40

			float x, y;

			System.Random r = new System.Random ();

			x = r.Next(-30,40);
			y = r.Next(-40, 40);
			int	choice = r.Next (0,7);
			Vector3 new_point = 	new Vector3 (x,y,0 );



			Instantiate (prefab_to_generate[choice] , new_point,prefab_to_generate[choice].transform.localRotation);


		}
		//Якщо хаваэм обёэкт з тегом "Хавка"
		if (col.tag == "char") {

			if(col.gameObject.GetComponent<Bot_AI>().size <= size)
			{
				float player_size = col.gameObject.GetComponent<Bot_AI> ().size; 
				Destroy (col.gameObject);
				transform.localScale += new Vector3 (player_size,player_size,player_size); // .
			}
		}

	}






}
