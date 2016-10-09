using UnityEngine;
using System.Collections;
using System;


[RequireComponent (typeof (Rigidbody2D))]

public class Bot_AI : MonoBehaviour {
	public GameObject []prefab_to_generate;

	public float speed,distance,size;
	public GameObject player;
	public int way_to_go;
    float nspeed=0, nexttime=0f,rate=4f;

	void random_way()
	{
		System.Random r = new System.Random ();
		way_to_go=r.Next (1,5);

	}

	// Use this for initialization
	void Start () 
	{	
		player = GameObject.Find ("Player"); // призначаэмо змінній значення об'екта з ієрархії з іменем "player".
	}



	void Update()
	{
		
	}



	void FixedUpdate()
	{  
		nspeed  = speed  * Time.deltaTime;	
	///	Debug.Log (Time.time);
		if(nexttime<Time.time)
		{
			random_way ();
			nexttime = Time.time + rate;
		}

		size = transform.localScale.x-1;// Загальний розмір бота. Визначається по масштабуванню якоїсь однієї осі.
		if(size>8){size=8;} //Обмеження росту кульки гравця.
		distance = Vector3.Distance(player.transform.position, transform.position ); // перший параметр - координати гарвця. Другий - координати бота. 



		if (distance < 5) 
		{ //Якщо дистанція між гравцем і ботом - менше 2 одиниць, дивимось чи гравець більший за бота
		


			if (size <= player.GetComponent<BallController> ().size) { // якщо бота менший за розмір гравця, то бот тікає.
				RunAway ();
			} 
			else 
			
			{ //якщо ні.Здоганяємо.
				transform.position = Vector3.MoveTowards (transform.position, player.transform.position, nspeed/transform.localScale.x);// Метод відповідає за рух у напрямі другого параметра. Третій параметр - швидкість руху.				
			}


		} 
		else //Якщо бот не бачить гравця, бот собі ходить набирає вагу. (просто ходить.)
		
		{
		

			if (way_to_go == 1) {transform.position = Vector3.MoveTowards (transform.position, transform.position+new Vector3(0,5,0), nspeed /transform.localScale.x);}//рухаємось вгору. Додатні "y" 
			if (way_to_go == 2) {transform.position = Vector3.MoveTowards (transform.position, transform.position+new Vector3(5,0,0), nspeed /transform.localScale.x);}//рухаємось вправо.Додатні "х" 
			if (way_to_go == 3) {transform.position = Vector3.MoveTowards (transform.position, transform.position+new Vector3(-5,0,0), nspeed /transform.localScale.x);}//рухаємось вгору. Від'ємні "х"
			if (way_to_go == 4) {transform.position = Vector3.MoveTowards (transform.position, transform.position+new Vector3(0,-5,0), nspeed /transform.localScale.x);}//рухаємось вгору. Від'ємні "у"

		}


	

	}





	//Метод який відповідає за втечу від гравця.


	void RunAway()
	{
		if (transform.position.x < player.transform.position.x) {
		
			if (transform.position.y < player.transform.position.y) {
			
				transform.position = Vector3.MoveTowards (transform.position, player.transform.position+ new Vector3(-5,-5,0), nspeed/transform.localScale.x);

				//transform.Translate (new Vector3 (-speed,-speed,0 )*Time.deltaTime); 




			} else {
				transform.position = Vector3.MoveTowards (transform.position, player.transform.position+ new Vector3(-5,5,0), nspeed/transform.localScale.x);
				//transform.Translate (new Vector3 (-speed,speed,0 )*Time.deltaTime);
			}

		} 
		else 
		{
			if (transform.position.y < player.transform.position.y) {

				transform.position = Vector3.MoveTowards (transform.position, player.transform.position+ new Vector3(5,-5,0), nspeed/transform.localScale.x);
			//	transform.Translate (new Vector3 (speed,-speed,0 )*Time.deltaTime);
			} else {
				transform.position = Vector3.MoveTowards (transform.position, player.transform.position+ new Vector3(5,5,0), nspeed/transform.localScale.x);
				//transform.Translate (new Vector3 (speed,speed,0 )*Time.deltaTime);

			}
		}







	}

	void OnColliderEnter2D()
	{
		random_way ();
	}

	void OnTriggerEnter2D (Collider2D col)
	{    //Якщо торкаэмось  обёэкт з тегом "Хавка", то ми його хаваэм.
		if (col.tag == "food") {

			Destroy (col.gameObject);
			transform.localScale += new Vector3 (0.05f, 0.05f, 0.05f);
			float x, y;

			System.Random r = new System.Random ();

			x = r.Next(-30,40);
			y = r.Next(-40, 40);
			int	choice = r.Next (0,7);
			Vector3 new_point = 	new Vector3 (x,y,0 );



			Instantiate (prefab_to_generate[choice] , new_point,prefab_to_generate[choice].transform.localRotation);

		}
		//Якщо хаваэм обёэкт з тегом "персонаж"
		if (col.tag == "char") {
			if(col.gameObject.GetComponent<BallController>().size < size)
			{
				float player_size = col.gameObject.GetComponent<BallController> ().size; 
				Destroy (col.gameObject);
				transform.localScale += new Vector3 (player_size,player_size,player_size); // .
			}
		}

	}


}
