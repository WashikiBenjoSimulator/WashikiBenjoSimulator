using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Projects.Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace GameScript
{
public class GameManager : SingletonMonoBehaviour<GameManager>, IAltoManager
{
    public TextMeshProUGUI textArea;
    public TextMeshProUGUI timeArea;
    // [SerializeField] private GameObject toiletObj;
    [SerializeField] private GameObject seatObj;
    [SerializeField] private GameObject poopObj;
    [SerializeField] private GameObject hipObj;
    public float time = 0;

    public int score = 100;
    public bool successPoop = false;
    public InputActionReference rightHandTrigerAction;


    // Start is called before the first frame update
    void Start()
    {
        textArea.text = "ドアに近づく";
    }

    // Update is called once per frame
    void Update()
    {
        if(WBSSceneManager.Instance.loadedScenes.Contains("DormitoryScene"))
        {
            time += Time.deltaTime;
            timeArea.text = "残り時間: " + (60-time); 
        }else time = 0;
    }

    public void calcScore()
    {
        //得点計算
        if(Vector3.Distance(hipObj.transform.position, seatObj.transform.position) > 0.5f)
        {
            GameManager.Instance.score -= 20;
            textArea.text = "\nトイレから離れすぎ -20";
        }
        if(successPoop == false)
        {
            GameManager.Instance.score -= 40;
            textArea.text += "\nうんちがトイレから外れたよ -40";
        }
        if(time > 60)
        {
            GameManager.Instance.score -= 100;
            textArea.text += "\n時間切れ -100";
        }

        timeArea.text = "スコア: " + GameManager.Instance.score;
        if(score < 60)
        {
            textArea.text += "\n失敗した";
        }

        StartCoroutine(changeScene());
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(3);
        WBSSceneManager.Instance.ChengeRobbyScene();
    }

    void IAltoManager.OnInitialize()
    {

    }
}}
