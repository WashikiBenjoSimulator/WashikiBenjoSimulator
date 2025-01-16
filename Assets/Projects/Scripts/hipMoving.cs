using System.Collections;
using System.Collections.Generic;
using GameScript;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class hipMoving : MonoBehaviour
{
    public TextMeshProUGUI textArea;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SeatPosition"))
        {
            GameManager.Instance.isCorrectSeatPos = true;
        }
    }
}
