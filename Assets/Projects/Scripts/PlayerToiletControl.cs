using System.Collections;
using System.Collections.Generic;
using GameScript;
using UnityEngine;

public class PlayerToiletControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "SeatPositon")
        {
            
        }
        if(collision.gameObject.name == "PoopPosition")
        {
           GameManager.Instance.canPoop = true; 
        }
    }
}
