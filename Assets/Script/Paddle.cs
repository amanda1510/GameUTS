using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float dindingKiri;
    public float dindingKanan;
    public float kecepatan;
    public string axis;

    void Start()
    {
        
    }
     void Update()
    {
        float gerak = Input.GetAxis(axis) * kecepatan * Time.deltaTime;
        float nextPost = transform.position.x + gerak;
        if (nextPost < dindingKiri)
        {
            gerak = 0;
        }
        if (nextPost > dindingKanan)
        {
            gerak = 0;
        }
        transform.Translate(gerak, 0, 0);
    }
}
