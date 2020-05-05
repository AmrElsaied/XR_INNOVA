using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class ChannelEnableVR : MonoBehaviour
{
    [SerializeField]
    GameObject CanvasTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPress()
    {
        SceneManager.LoadScene("Interactive");
        CanvasTransform.transform.position = new Vector3(CanvasTransform.transform.position.x, 100f, CanvasTransform.transform.position.z);
        //XRSettings.LoadDeviceByName("Cardboard");
        //XRSettings.enabled = true;
        //Debug.Log("Entered***************************************************************************");
    }
    public void Exit()
    {
        Debug.Log("Entered");
        Application.Quit();
    }
}
