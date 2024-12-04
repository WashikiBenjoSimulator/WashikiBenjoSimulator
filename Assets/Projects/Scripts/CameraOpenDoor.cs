using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BenkiUI;

namespace CameraDoorScript
{
public class CameraOpenDoor : MonoBehaviour {
	public float DistanceOpen=3;
	// public GameObject text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, DistanceOpen))
		{
			if (hit.transform.GetComponent<DoorScript.Door> ())
				BenkiUI.UIManager.Instance.textArea.text = "Eキーでドアを開ける";

			if (Input.GetKeyDown(KeyCode.E))
				hit.transform.GetComponent<DoorScript.Door> ().OpenDoor(hit.transform.gameObject);
				// Debug.Log(hit.collider.gameObject.name);
		}else{
			// text.SetActive (false);
			BenkiUI.UIManager.Instance.textArea.text = "ドアに近づく";
		}
	}
}
}