﻿using System.Collections;
using System.Collections.Generic;
using GameScript;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace DoorScript
{
	[RequireComponent(typeof(AudioSource))]
	
	public class Door : MonoBehaviour {
	public bool open;
	public float smooth = 1.0f;
	float DoorOpenAngle = -90.0f;
    float DoorCloseAngle = 0.0f;
	public AudioSource asource;
	public AudioClip openDoor,closeDoor;
	
	// Use this for initialization
	void Start () {
		asource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (open)
		{
            var target = Quaternion.Euler (0, DoorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);
	
		}
		else
		{
            var target1= Quaternion.Euler (0, DoorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * 5 * smooth);
	
		}  
	}

	public void OpenDoor(GameObject door){
		Debug.Log(door.name);
		open =!open;
		asource.clip = open?openDoor:closeDoor;
		asource.Play ();

		//ここにシーン遷移の処理
		if(door.name == "Door"){
			Invoke("LoodDormitoryScene", 3.0f);
		}
	}

	private void LoodDormitoryScene()
	{
		SceneManager.LoadScene("DormitoryScene", LoadSceneMode.Additive);
		SceneManager.UnloadSceneAsync("RobbyScene");
	}
}
}