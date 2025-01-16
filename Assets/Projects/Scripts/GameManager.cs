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
        public bool isPoop = false;
        public bool isToiletPaperTouch = false;
        public bool isFlushHandleTouch = false;

        private bool isFinish = false;

        private float calcTime = 0;

        private bool finishGame = false;


        // Start is called before the first frame update
        void Start()
        {
            textArea.text = "ドアに近づく";
        }

        // Update is called once per frame
        void Update()
        {
            // if (WBSSceneManager.Instance.loadedScenes.Contains("DormitoryScene"))
            // {
            //     time += Time.deltaTime;
            //     timeArea.text = "残り時間: " + (60 - time);
            // }
            // else time = 0;

            if(BenjoSceneManager.Instance.IsSceneLoaded(BenjoSceneManager.SceneType.DormitoryScene) && !isFinish)
            {
                time += Time.deltaTime;
                timeArea.text = "Time: " + time + "s";
            }

            if (time > 60 || isPoop == true)
            {
                textArea.text = "流しましょう";

                isFinish = true;
            }
            if (isFinish)
            {
                calcTime += Time.deltaTime;
                if (calcTime > 10f && !finishGame)
                {
                    textArea.text = "終了\nスコアを計算中...";
                    BenjoSceneManager.Instance.ChengeLobbyScene();
                    calcScore();
                    finishGame = true;
                }
            }

        }

        public void calcScore()
        {
            //得点計算
            if (isCorrectSeatPos)
            {
                score -= 20;
                textArea.text += "\nトイレから離れすぎ -20";
            }
            if (!successPoop)
            {
                score -= 40;
                textArea.text += "\nトイレに入っていない -40";
            }
            if (isToiletPaperTouch == true)
            {
                score += 5;
                textArea.text += "\nトイレットペーパーを使った +5";
            }
            if (isFlushHandleTouch == true)
            {
                score += 5;
                textArea.text += "\nきちんと流した +5";
            }

            timeArea.text = "スコア: " + score;
            if (score < 60)
            {
                textArea.text += "\n失敗した";
            }

            BenjoSceneManager.Instance.UnloadAllScenes(); //シーンのアンロード
        }

        void IAltoManager.OnInitialize()
        {

        }
    }
}
