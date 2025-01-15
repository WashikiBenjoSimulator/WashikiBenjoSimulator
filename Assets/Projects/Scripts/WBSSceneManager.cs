using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WBSSceneManager : SingletonMonoBehaviour<WBSSceneManager>, IAltoManager
{
    void Start()
    {
        LoadSceneAsync("LobbyScene", true);
    }

    void Update(){
        if(!isWait) return;

        waitTime += Time.deltaTime;
        if(waitTime > 3f){
            isWait = false;

            if(isWaitLoad){
                LoadSceneAsync(nextSceneName, true);
            }else{
                UnloadSceneAsync(nextSceneName);
            }
        }
    }

    // ロード中のシーンを管理する
    private static WBSSceneManager instance;

    // ロード中かどうかのフラグ
    private bool isLoadingScene = false;

    // ロード済みのシーンを追跡するリスト
    public HashSet<string> loadedScenes = new HashSet<string>();

    private bool isWait = false;
    private float waitTime = 0f;
    private string nextSceneName = "";
    private bool isWaitLoad = false;

    void IAltoManager.OnInitialize()
    {
        // 初期化処理があればここに書く
    }

    // 非同期にシーンをロードする
    public void LoadSceneAsync(string sceneName, bool additive = false)
    {
        // シーンがロード中なら数秒後にやりなおす
        if (isLoadingScene)
        {
            nextSceneName = sceneName;
            isWait = true;
            isWaitLoad = true;
            return;
        }

        // 二重ロードを防ぐチェック
        if (additive && loadedScenes.Contains(sceneName))
        {
            Debug.Log($"シーン {sceneName} は既にロードされています (Additive)。");
            return;
        }

        // 新しいシーンのロードを開始
        StartCoroutine(LoadSceneCoroutine(sceneName, additive));
    }

    // 非同期にシーンをアンロードする
    public void UnloadSceneAsync(string sceneName)
    {
        // シーンがロード中なら数秒後にやりなおす
        if (isLoadingScene)
        {
            nextSceneName = sceneName;
            isWait = true;
            isWaitLoad = false;
            return;
        }

        // シーンのアンロードを開始
        StartCoroutine(UnloadSceneCoroutine(sceneName));
    }

    // シーンのロードを非同期で行うコルーチン
    private IEnumerator LoadSceneCoroutine(string sceneName, bool additive)
    {
        isLoadingScene = true;

        // シーンのロードを非同期で行う
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, additive ? LoadSceneMode.Additive : LoadSceneMode.Single);

        // ロードが完了するまで待機
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);  // 進行度の表示 (0-1)
            Debug.Log($"シーン {sceneName} ロード進行度: {progress * 100}%");
            yield return null;
        }

        // ロード完了
        if (additive)
        {
            loadedScenes.Add(sceneName);  // Additiveロードの場合、ロード済みシーンとして登録
        }
        else
        {
            loadedScenes.Clear();  // Singleロードの場合、ロード済みシーンをクリア
            loadedScenes.Add(sceneName);  // ロード済みシーンとして登録
        }
        isLoadingScene = false;
        Debug.Log($"シーン {sceneName} のロード完了");
    }

    // シーンのアンロードを非同期で行うコルーチン
    private IEnumerator UnloadSceneCoroutine(string sceneName)
    {
        isLoadingScene = true;

        // シーンのアンロードを非同期で行う
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneName);

        // アンロードが完了するまで待機
        while (!asyncUnload.isDone)
        {
            float progress = Mathf.Clamp01(asyncUnload.progress / 0.9f);  // 進行度の表示 (0-1)
            Debug.Log($"シーン {sceneName} アンロード進行度: {progress * 100}%");
            yield return null;
        }

        // アンロード完了
        loadedScenes.Remove(sceneName);  // アンロードされたらリストから削除
        isLoadingScene = false;
        Debug.Log($"シーン {sceneName} のアンロード完了");
    }

    // ドミトリーシーンに切り替える
    public void ChengeDomitoryScene()
    {
        LoadSceneAsync("DormitoryScene", true);
        UnloadSceneAsync("RobbyScene");
    }

    public void ChengeRobbyScene()
    {
        LoadSceneAsync("CoreScene", false);
        LoadSceneAsync("RobbyScene", true);
    }
}
