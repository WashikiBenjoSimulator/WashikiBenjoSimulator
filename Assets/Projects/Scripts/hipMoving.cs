using System.Collections;
using System.Collections.Generic;
using GameScript;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class hipMoving : MonoBehaviour
{
    public TextMeshProUGUI textArea;
    public InputActionReference rightHandTrigerAction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PoopManager.Instance.isPoop == true) return;

        if (rightHandTrigerAction.action.WasPerformedThisFrame() && WBSSceneManager.Instance.loadedScenes.Contains("DormitoryScene"))
        {
            PoopManager.Instance.Poop();
            StartCoroutine(calcScore());
        }
    }

    IEnumerator calcScore()
    {
        yield return new WaitForSeconds(3);
        GameManager.Instance.calcScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SeatPosition"))
        {
            GameManager.Instance.isCorrectSeatPos = true;
        }
    }
}
