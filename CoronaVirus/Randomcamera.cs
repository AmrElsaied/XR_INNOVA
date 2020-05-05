using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomcamera : MonoBehaviour
{
    public GameObject[] cameras;
    [SerializeField]
    GameObject[] channels;
    public GameObject playerone;
    

    // Start is called before the first frame update
    void Start()
    {
        cameracount();
    }

    // Update is called once per frame
    void Update()
    {
         
        
        
        
    }

    void cameracount() {
        int cameraindex = Random.Range(0, 3);
        int channelindex = cameraindex;
        GameObject rcamera = Instantiate(cameras[cameraindex]);
        GameObject rchannel = Instantiate(channels[channelindex]);
        rcamera.transform.parent = transform;
        if (cameraindex == 0) {

            Destroy(playerone);
        
        }
    }
}
 
 

     