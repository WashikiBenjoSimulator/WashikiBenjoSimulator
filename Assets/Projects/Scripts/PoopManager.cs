using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using GameScript;
using Projects.Scripts.Core;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.InputSystem;

public class PoopManager : SingletonMonoBehaviour<PoopManager>, IAltoManager
{
    [SerializeField] private GameObject hipPos;
    [SerializeField] private GameObject poop;
    [SerializeField] private GameObject parent;

    public bool isPoop = false;

    public InputActionReference rightHandTrigerAction;


    void IAltoManager.OnInitialize()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rightHandTrigerAction.action.WasPerformedThisFrame())
        {
            Debug.Log("Pooping!!!!!!");
        }
    }

    public void Poop()
    {
        // isPoop = true;
        // poop.transform.position = hipPos.transform.position;
        // poop.SetActive(true);

        Instantiate(poop, hipPos.transform.position, Quaternion.identity, parent.transform);
    }
}
