using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    
    [SerializeField] private int frame;
    [SerializeField] private float checkNextFrame;
    [SerializeField] private float captureTimeBetweenFrames;

    private void Awake()
    {
        checkNextFrame = 1f;
    }

    private void Start()
    {
        
    }


    void Update()
    {

    }

    private void iBuffer()
    {

    }

    /*private IEnumerator CountFrames()
    {
       
    }*/
}
