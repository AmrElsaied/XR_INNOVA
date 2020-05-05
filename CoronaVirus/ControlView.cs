using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlView : MonoBehaviour
{

    float interval = 2f;
    float now = 0;
    float Present_Angle_y = 0;
    float Present_Angle_x = 0;
    float Last_Angle_y = 0;
    float Last_Angle_x = 0;
    double Error_y = 0;
    double Error_x = 0;
    [SerializeField]
    Text Alarm;

    float Text_time = 0;
    float Text_interval = 2;
    bool Text_flag = false;
    // Start is called before the first frame update
    void Start()
    {
        Present_Angle_y = transform.rotation.y;
        Present_Angle_x = transform.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        Present_Angle_y = Mathf.Floor(Mathf.Rad2Deg * (Camera.main.transform.localEulerAngles.y));
        if (Present_Angle_y == -1)
        {
            Present_Angle_y = 0;
        }
        Present_Angle_x = Mathf.Floor(Mathf.Rad2Deg * Camera.main.transform.eulerAngles.x);
        if (Present_Angle_x == -1)
        {
            Present_Angle_x = 0;
        }


        now += Time.deltaTime;

        if (now >= 1)
        {
            Debug.Log("Time_Enter*****************************");
            // measure error
            Error_y = Mathf.Abs(Present_Angle_y - Last_Angle_y);
            Error_x = Mathf.Abs(Present_Angle_x - Last_Angle_x);
            if ((Error_y >= 1000 && Error_y<=19000) || (Error_x >= 700 && Error_x <= 19000))
            {
                Debug.Log("Time_Error*" + Error_y + "*********************");
                // assign to last values
                
                // reset the timer
                now = 0;
                Alarm.text = "Calm and Consentrate";
                Text_flag = true;
                Debug.Log("Text_ON***************************");
            }
            
            Last_Angle_y = Present_Angle_y;
            Last_Angle_x = Present_Angle_x;
        }
        if (Text_flag)
        {
            Text_time += Time.deltaTime;
            if (Text_time>= Text_interval)
            {
                Debug.Log("Text_OFF******************************");
                Alarm.text = "";
                Text_flag = false;
                Text_time = 0;
            }
        }
        //else if (Present_Angle_y>14000 && Present_Angle_y < 21000)
        //{

        //}
        Debug.Log("X: "+Present_Angle_x);
        //Debug.Log("y: " + Present_Angle_y);
    }
}
