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
	void Start () {
		speed = 10;
	}

	// Update is called once per frame
	void Update () {

		onLeft = (transform.position.x <= -1.4);
		onRight = (transform.position.x >= 1.6);
		onMid = (transform.position.x == 0);
	
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			if(!turnLeft)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
				turnRight = true;
				onLeft = false;
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
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D> ().velocity.y);
				turnLeft = true;
				onRight = false;
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
		}
		if (onRight) 
		{
			turnRight = false;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
		}
		if (onMid) 
		{
			turnRight = false;
			turnLeft = false;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
		}
		if(!turnLeft && !turnRight)
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
		}
	}
}
