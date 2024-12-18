using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Projects.Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameScript
{
public class GameManager : SingletonMonoBehaviour<GameManager>, IAltoManager
{
    public TextMeshProUGUI textArea;
    [SerializeField] private GameObject toiletObj;
    [SerializeField] private GameObject toiletDoorObj;
    [SerializeField] private GameObject seatObj;
    [SerializeField] private GameObject poopObj;
    [SerializeField] private GameObject player;
    private bool isPlayGame = false;
    public bool isToilet = false;
    public bool canPoop = false;

    // Start is called before the first frame update
    void Start()
    {
        isPlayGame = false;
        textArea.text = "ドアに近づく";
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "RobbyRoom")
        {
            isPlayGame = true;
        }else return;
        
        textArea.text = "トイレに入る";
        if(isToilet)
        {
            textArea.text = "用を足す";

            Vector3 seatPos = toiletObj.transform.position;
            seatObj.transform.position = new Vector3(seatPos.x, 1.5f, seatPos.z);
        }

        if(canPoop)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {

            }
        }
    }

    void IAltoManager.OnInitialize()
    {

    }
}}
