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
        public bool isCorrectSeatPos = false;
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
            if (WBSSceneManager.Instance.loadedScenes.Contains("DormitoryScene"))
            {
                time += Time.deltaTime;
                timeArea.text = "残り時間: " + (60 - time);
            }
            else time = 0;
        }

        public void calcScore()
        {
            //得点計算
            if (isCorrectSeatPos)
            {
                score -= 20;
                textArea.text = "\nトイレから離れすぎ -20";
            }
            if (!successPoop)
            {
                score -= 40;
                textArea.text += "\nトイレに入っていない -40";
            }
            if (TouchDetection.Instance.isToiletPaperTouch == true)
            {
                score += 5;
                textArea.text += "\nトイレットペーパーを使った +5";
            }
            if (TouchDetection.Instance.isFlushHandleTouch == true)
            {
                score += 5;
                textArea.text += "\nきちんと流した +5";
            }

            timeArea.text = "スコア: " + score;
            if (score < 60)
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
    }
}
