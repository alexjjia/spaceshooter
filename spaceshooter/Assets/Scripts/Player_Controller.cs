using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {
	private float speed; //speed modifier.
	public float prevMoveSpeed; //stores maximum speed recorded by movementSpeed.
	public float movementSpeed; //stored by the input.
	private float tiltrate;

	public Texture2D crosshair;
	private int crosshairScale = 1;

	// Use this for initialization
	void Start () {

		speed = 10f;	
		tiltrate = 10f;
		prevMoveSpeed = .01f;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		
		movementSpeed = Input.GetAxis ("Throttle") * speed;
		if (movementSpeed >= 0) {
			if (movementSpeed > Mathf.Abs (prevMoveSpeed)) {
				prevMoveSpeed = movementSpeed; //resets the player's movement speed to be that of last highest value.
			}

		} else { //when 's' is pressed.
			if (prevMoveSpeed > 0) {
				prevMoveSpeed += movementSpeed*.01f;
			}

		}

		this.transform.Rotate (-1*Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), Input.GetAxis ("Tilt")*tiltrate);
		this.transform.Translate (0, 0, prevMoveSpeed); 
	}

	void OnGUI()
	{
		if (crosshair != null) {
			GUI.DrawTexture (new Rect ((Screen.width - crosshair.width * crosshairScale) / 2, (Screen.height - crosshair.height * crosshairScale) / 2, crosshair.width * crosshairScale, crosshair.height * crosshairScale), crosshair);
		}
	}
}
