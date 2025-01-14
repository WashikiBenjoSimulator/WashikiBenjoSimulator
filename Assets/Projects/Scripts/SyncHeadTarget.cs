using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncHeadTarget : MonoBehaviour
{
    [SerializeField] private Transform headTracker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!headTracker) return;
        transform.position = headTracker.position;
    }
}
