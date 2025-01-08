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
    [SerializeField] private GameObject seatObj;
    [SerializeField] private GameObject poopObj;
    [SerializeField] private GameObject hipObj;
    private bool isPlayGame = false;
    public bool isToilet = false;
    public bool canPoop = false;

    public float time = 0;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        isPlayGame = false;
        textArea.text = "ドアに近づく";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

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
                textArea.text = "用を足した";
                
                PoopManager.Instance.Poop();
            }
        }
    }

    public void calcScore()
    {
        //得点計算
        if(Vector3.Distance(hipObj.transform.position, seatObj.transform.position) > 0.5f)
        {
            GameManager.Instance.score -= 20;
            textArea.text = "トイレから離れすぎ -50";
        }
        if(Vector3.Distance(poopObj.transform.position, toiletObj.transform.position) > 0.5f)
        {
            GameManager.Instance.score -= 40;
            textArea.text = "満足に用を足せていない -50";
        }
        if(time > 60)
        {
            GameManager.Instance.score -= 100;
            textArea.text = "時間切れ -100";
        }

        textArea.text = "スコア: " + GameManager.Instance.score;
        if(score < 60)
        {
            textArea.text = "失敗した";
        }
    }

    void IAltoManager.OnInitialize()
    {

    }
}}
