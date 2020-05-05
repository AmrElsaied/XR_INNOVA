using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class GVRTimer : MonoBehaviour
{
    public Button btn;
    public Image img;
    float totaltime = 4;
    bool gvrstatus;
    float gvrtimer;
    public UnityEvent gvrclick;
    public GameObject black;
    public Animator anim;
    public int flag = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gvrstatus == true)
        {
            gvrtimer = gvrtimer + Time.deltaTime;
            img.fillAmount = gvrtimer / totaltime;
            if(gvrtimer > totaltime)
            {
                Fading();
                
            }
        }
    }
    public void GvrOnButton()
    {
        gvrstatus = true;
    }
    public void GvrOffButton()
    {
        gvrstatus = false;
        img.fillAmount = 0;
        gvrtimer = 0;
    }
    public void Fading()
    {
        anim.SetBool("Fade",true);
        
        gvrclick.Invoke();
        flag = 1;
    }
}
