using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textArea;
    // Start is called before the first frame update
    void Start()
    {
        textArea.text = "Approach the door and press the E key.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
