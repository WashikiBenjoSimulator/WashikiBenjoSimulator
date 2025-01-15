using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CameraDoorScript
{
public class MyCameraOpenDoor : MonoBehaviour {
	public float DistanceOpen=1;
	public InputActionReference leftHandTrigerAction;

	// public GameObject text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, DistanceOpen)){
			//何もなければリターン
			if (!hit.transform.GetComponent<MyDoorScript.MyDoor>()){
				return;
			}

			if (hit.transform.GetComponent<MyDoorScript.MyDoor>()){
				GameScript.GameManager.Instance.textArea.text = "左トリガーでドアを開ける";

				//左トリガーが押されたら
				if (leftHandTrigerAction.action.WasPerformedThisFrame()){
					Debug.Log("ドアを開ける");
					hit.transform.GetComponent<MyDoorScript.MyDoor>().OpenDoor(hit.transform.gameObject);
					
					foreach (var item in WBSSceneManager.Instance.loadedScenes)
					{
						Debug.Log(item);
					}

					if(WBSSceneManager.Instance.loadedScenes.Contains("LobbyScene"))
					{
						Debug.Log("ロビーからドミトリーへ移動");
						WBSSceneManager.Instance.ChengeDomitoryScene();
					}
				}
			}
		}
	}
}
}