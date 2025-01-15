using System.Collections;
using System.Collections.Generic;
using GameScript;
using Projects.Scripts.Core;
using UnityEngine;

public class PoopManager : SingletonMonoBehaviour<PoopManager>, IAltoManager
{
    public float fallSpeed = 2f;
    private Rigidbody rb;
    [SerializeField] private GameObject hipPos;
    [SerializeField] private GameObject poop;
    public bool isPoop = false;

    void IAltoManager.OnInitialize()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = poop.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Poop()
    {
        isPoop = true;
        poop.transform.position = hipPos.transform.position;
        poop.SetActive(true);

        //自由落下
        rb.AddForce(Vector3.down * fallSpeed, ForceMode.Impulse);
    }

    void OnTrigerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("benki"))
        {
            Debug.Log("うんちがトイレに入った");
            GameManager.Instance.successPoop = true;
        }
    }
}
