using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraDoorScript
{
public class CameraOpenDoor : MonoBehaviour {
	public float DistanceOpen=1;
	// public GameObject text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, DistanceOpen))
		{
			if(hit.collider == null) return;

			if (hit.collider.CompareTag("Door"))
			{
				GameScript.GameManager.Instance.textArea.text = "Eキーでドアを開ける";

				if (Input.GetKeyDown(KeyCode.E))
				hit.transform.GetComponent<DoorScript.Door> ().OpenDoor(hit.transform.gameObject);
				// Debug.Log(hit.collider.gameObject.name);
			}
		}
	}
}
}