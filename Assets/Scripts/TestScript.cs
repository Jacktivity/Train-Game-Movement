using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	public bool turnLeft;
	public bool turnRight;
	public bool onLeft;
	public bool onRight;
	public bool onMid;
	public int speed;

	// Use this for initialization
	void Start () 
	{
		speed = 6;
	}

	// Update is called once per frame
	void Update () {

		onLeft = (transform.position.x < -1.6);
		onRight = (transform.position.x > 1.6);
		onMid = (transform.position.x > -0.1 && transform.position.x <0.1);
	
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			if(!turnLeft)
			{
				turnRight = true;
				onLeft = false;
				onMid = false;
				GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
			}
			else
			{
				turnLeft = false;
			}

		}
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if (!turnRight)
			{
				turnLeft = true;
				onRight = false;
				onMid = false;
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D> ().velocity.y);
			} 
			else 
			{
				turnRight = false;
			}
		}
		if (onLeft) 
		{
			turnLeft = false;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
			transform.position = new Vector2(-1.6f, GetComponent<Rigidbody2D>().position.y);
		}
		if (onRight) 
		{
			turnRight = false;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
			transform.position = new Vector2(1.6f, GetComponent<Rigidbody2D>().position.y);
		}
		if (onMid) 
		{
			turnRight = false;
			turnLeft = false;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
			transform.position = new Vector2(0.0f, GetComponent<Rigidbody2D>().position.y);
		}
		if(!turnLeft && !turnRight)
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
		}
	}
}
