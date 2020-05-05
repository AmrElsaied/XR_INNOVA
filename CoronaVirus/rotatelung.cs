using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatelung : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lung = new Vector3(0, 0, 45);
        transform.Rotate(lung * Time.deltaTime);
    }
}
