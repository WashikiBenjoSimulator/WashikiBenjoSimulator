using System.Collections;
using System.Collections.Generic;
using GameScript;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CameraDoorScript
{
public class MyCameraOpenDoor : MonoBehaviour {
	public float DistanceOpen=1;
	public InputActionReference leftHandTrigerAction;

	[SerializeField] private GameObject toiletPaper;

	// public GameObject text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, DistanceOpen)){

			
			//ドアがあれば
			if (hit.transform.GetComponent<MyDoorScript.MyDoor>()){
				GameScript.GameManager.Instance.textArea.text = "左トリガーでドアを開ける";
				//左トリガーが押されたら
				if (leftHandTrigerAction.action.WasPerformedThisFrame()){
					hit.transform.GetComponent<MyDoorScript.MyDoor>().OpenDoor(hit.transform.gameObject);
					if(BenjoSceneManager.Instance.IsSceneLoaded(BenjoSceneManager.SceneType.LobbyScene))
					{
						Debug.Log("ロビーからドミトリーへ移動");
						BenjoSceneManager.Instance.ChengeDomitoryScene();
					}
				}
			}
			if(hit.transform.GetComponent<ToiletPaper>())
			{
				GameManager.Instance.textArea.text = "左トリガーでトイレットペーパーを使う";

				if (leftHandTrigerAction.action.WasPerformedThisFrame()){
					GameManager.Instance.isToiletPaperTouch = true;
				}
			}
			if(hit.transform.GetComponent<ToiletFlush>())
			{
				GameManager.Instance.textArea.text = "左トリガーで流す";
				if(leftHandTrigerAction.action.WasPerformedThisFrame()){
					GameManager.Instance.isFlushHandleTouch = true;
					hit.transform.GetComponent<ToiletFlush>().WaterSound();
				}
			}				
		}else return;
	}
}
}