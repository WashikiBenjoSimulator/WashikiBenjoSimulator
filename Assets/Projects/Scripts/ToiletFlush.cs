using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletFlush : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip waterSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WaterSound()
    {
        Debug.Log("WaterSound");
        audioSource.PlayOneShot(waterSound);
    }
}
