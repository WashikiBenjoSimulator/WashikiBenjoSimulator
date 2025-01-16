using System;
using System.Collections.Generic;
using Projects.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BenjoSceneManager : SingletonMonoBehaviour<BenjoSceneManager>,IAltoManager
{
    // シーンの種類を管理するためのenum
    public enum SceneType
    {
        LobbyScene,
        CoreScene,
        DormitoryScene
    }

    // 現在ロードされているシーンを管理するリスト
    private List<SceneType> loadedScenes = new List<SceneType>();

    // CoreSceneは必ず最初にロードされ、他のシーンは切り替え
    void Start()
    {
        
    }

    // シーンをロードする関数
    public void LoadScene(SceneType sceneType)
    {
        if (sceneType == SceneType.CoreScene)
        {
            // CoreSceneは常にロードされている
            if (!IsSceneLoaded(SceneType.CoreScene))
            {
                // CoreSceneがロードされていない場合はロードする
                SceneManager.LoadScene("CoreScene", LoadSceneMode.Additive);
                loadedScenes.Add(SceneType.CoreScene);
            }
        }
        else
        {
            // LobbySceneまたはDormitorySceneの管理
            if (sceneType == SceneType.LobbyScene)
            {
                if (!IsSceneLoaded(SceneType.LobbyScene))
                {
                    // LobbySceneが既にロードされていない場合は、他のシーンがあればアンロードする
                    UnloadScene(SceneType.DormitoryScene);
                    SceneManager.LoadScene("LobbyScene", LoadSceneMode.Additive);
                    loadedScenes.Add(SceneType.LobbyScene);
                }
            }
            else if (sceneType == SceneType.DormitoryScene)
            {
                if (!IsSceneLoaded(SceneType.DormitoryScene))
                {
                    // DormitorySceneが既にロードされていない場合は、他のシーンがあればアンロードする
                    UnloadScene(SceneType.LobbyScene);
                    SceneManager.LoadScene("DormitoryScene", LoadSceneMode.Additive);
                    loadedScenes.Add(SceneType.DormitoryScene);
                }
            }
        }
    }

    // シーンがロードされているかを確認する関数
    public bool IsSceneLoaded(SceneType sceneType)
    {
        return loadedScenes.Contains(sceneType);
    }

    // シーンをアンロードする関数
    private void UnloadScene(SceneType sceneType)
    {
        if (IsSceneLoaded(sceneType))
        {
            SceneManager.UnloadSceneAsync(sceneType.ToString());
            loadedScenes.Remove(sceneType);
        }
    }

    // すべてのシーンをアンロードする関数（例: ゲーム終了時に使用）
    public void UnloadAllScenes()
    {
        foreach (SceneType sceneType in new List<SceneType>(loadedScenes))
        {
            UnloadScene(sceneType);
            loadedScenes.Clear();
        }
    }

    // シーンの切り替えを行う関数
    public void ChengeDomitoryScene()
    {
        LoadScene(SceneType.DormitoryScene);
        UnloadScene(SceneType.LobbyScene);
    }

    public void ChengeLobbyScene()
    {
        LoadScene(SceneType.LobbyScene);
        UnloadScene(SceneType.DormitoryScene);
    }

    void IAltoManager.OnInitialize()
    {
        // 初期化処理があればここに書く
    }
}
