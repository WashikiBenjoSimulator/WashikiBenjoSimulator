using System.Collections;
using System.Collections.Generic;
using GameScript;
using Projects.Scripts.Core;
using UnityEngine;

public class PoopManager : SingletonMonoBehaviour<PoopManager>, IAltoManager
{
    public float fallSpeed = 9.8f;
    private Rigidbody rb;
    [SerializeField] private GameObject hip;
    [SerializeField] private GameObject hipPos;
    [SerializeField] private GameObject poop;

    void IAltoManager.OnInitialize()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Poop()
    {
        poop.SetActive(true);
        transform.position = hip.transform.position;
        //自由落下
        rb.AddForce(Vector3.down * fallSpeed, ForceMode.Impulse);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("toilet"))
        {
            poop.SetActive(false);
            GameManager.Instance.calcScore();
        }
    }
}
