using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiretPositionSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetToiretPos()
    {
        Vector3 toiretPos = transform.position;
        GameObject.Find("Toilet").transform.position = new Vector3(toiretPos.x, 1.5f, toiretPos.z);
    }
}
