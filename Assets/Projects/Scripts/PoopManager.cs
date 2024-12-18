using System.Collections;
using System.Collections.Generic;
using Projects.Scripts.Core;
using UnityEngine;

public class PoopManager : SingletonMonoBehaviour<PoopManager>, IAltoManager
{
    public float fallSpeed = 9.8f;
    private Rigidbody rb;
    [SerializeField] private GameObject hip;

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
        if(rb != null)
        {
            rb.AddForce(Vector3.down * fallSpeed);
        }
    }

    public void Poop()
    {
        transform.position = hip.transform.position;
        //自由落下

    }
}
