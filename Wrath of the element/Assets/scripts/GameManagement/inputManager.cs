using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class inputManager {

	public static bool Submit()
	{
		return Input.GetButtonDown ("Submit");
	}
    public static bool Cancel()
    {
        return Input.GetButtonDown("Cancel");
    }
    public static bool Pause(){
		return Input.GetButtonDown ("Pause");
	}
	public static bool Jump_p1(){
		return Input.GetButtonDown ("Jump_p1");
	}
	public static bool Jump_p2(){
		return Input.GetButtonDown ("Jump_p2");
	}
	public static bool Jump_p3(){
		return Input.GetButtonDown ("Jump_p3");
	}
	public static bool Jump_p4(){
		return Input.GetButtonDown ("Jump_p4");
	}
	public static bool Dash_p1(){
		return Input.GetButtonDown ("Dash_p1");
	}
	public static bool Dash_p2(){
		return Input.GetButtonDown ("Dash_p2");
	}
	public static bool Dash_p3(){
		return Input.GetButtonDown ("Dash_p3");
	}
	public static bool Dash_p4(){
		return Input.GetButtonDown ("Dash_p4");
	}
	public static float Move_p1(){
		float r = 0.0f;
		r += Input.GetAxis ("movec_p1");
		r += Input.GetAxis ("movek_p1");
		return Mathf.Clamp (r, -1.0f, 1.0f);
	}
	public static float Move_p2(){
		float r = 0.0f;
		r += Input.GetAxis ("movec_p2");
		r += Input.GetAxis ("movek_p2");
		return Mathf.Clamp (r, -1.0f, 1.0f);
	}
	public static float Move_p3(){
		float r = 0.0f;
		r += Input.GetAxis ("movec_p3");
		r += Input.GetAxis ("movek_p3");
		return Mathf.Clamp (r, -1.0f, 1.0f);
	}
	public static float Move_p4(){
		float r = 0.0f;
		r += Input.GetAxis ("movec_p4");
		r += Input.GetAxis ("movek_p4");
		return Mathf.Clamp (r, -1.0f, 1.0f);
	}
	public static float Horizontal(){
		float r = 0.0f;
		r += Input.GetAxis ("Horizontal");
		r += Input.GetAxis ("Horizontal");
		r = Mathf.Clamp (r, -1.0f, 1.0f);
		if (r > 0) {
			r = 1;
		} else if (r < 0) {
			r = -1;
		}
		return r;
	}

}
