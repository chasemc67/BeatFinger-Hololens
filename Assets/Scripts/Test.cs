using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateCubesWithTimeInterval();
    }

    void updateCubesWithTimeInterval() {
        float cubeSpeed = 1f;
        float destroyAt = 5f;
        Vector3 updateVector = new Vector3(0f, 0f, -Time.deltaTime * cubeSpeed);
        transform.position += updateVector;
        if (Math.Abs(transform.localPosition.z) > destroyAt) {
            Destroy(gameObject);
        }
    }
}
