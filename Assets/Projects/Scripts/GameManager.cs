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
    // Start is called before the first frame update
    void Start()
    {
        textArea.text = "ドアに近づく";
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "DormitoryScene") return;
        
    }

    void IAltoManager.OnInitialize()
    {
        // throw new System.NotImplementedException();
    }
}}
