using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CounterDown : MonoBehaviour
{
    [SerializeField]
    Text Timer;
    // Start is called before the first frame update
    float counter = 15;
    float now = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            counter -= Time.deltaTime;
            Timer.text = Mathf.Floor(counter).ToString();
            if (counter < 1)
            {
                SceneManager.LoadScene("SceneAR");
            }
    }
}
