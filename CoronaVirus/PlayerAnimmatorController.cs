using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerAnimmatorController : MonoBehaviour {
    public GameObject Recording;
    public GameObject loc;
    private ResonanceAudioSource rec;
    //public Wheel wheel;
    //public Buttons button;
    public Animator anim;
    public Animator anim2;
    public Image black;
    public int starts = 0;
    private int flag2 = 0;
    public GameObject gear;
    public GameObject But;
    public GameObject text;
    public GameObject shapes;
    public GameObject QA;
    public GameObject videos;
    public ReflectionProbe reflect;
    bool quizs;
    private float timer = 0;
    Vector3 turn;
    Vector3 turn2;
    bool buttone = false;
    bool speak = false;
    bool open = false;
    float now = 0;
    bool ended_Scene = false;
    void Start()
    {
        rec = GetComponent<ResonanceAudioSource>();
        animator = GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
        turn = new Vector3(0, -25, 0);
        turn2 = new Vector3(0, 25, 0);
    }
    void Update()
    {
        //Debug.Log(Recording.transform.GetChild(0).gameObject.transform.rotation.eulerAngles.x);
        //if (Recording.transform.GetChild(0).gameObject.transform.rotation.eulerAngles.x > 22 && Recording.transform.GetChild(0).gameObject.transform.rotation.eulerAngles.x < 50 && speak == false) { But.SetActive(true);
        //  Recording.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        // }
        //else { if (open) { But.SetActive(true); } else { But.SetActive(false); } if (buttone) { Recording.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false); } }
        //Debug.Log(audioData.time);
        if (starts == 1)
        {
            audioData.Play(0);
            audioData.time = 0.8f;
            loc.GetComponent<Innova>().enabled = true;
            buttone = true;
            starts = 0;


        }
        if (starts == 2)
        {
            loc.GetComponent<Innova>().enabled = false;
        }
        print(flag);
        if (audioData.time > 17.5 && flag == 0 && audioData.time < 18)
        {
            AnimateRaiseuphands();
        }
        if (audioData.time > 6 && flag == 0 && audioData.time < 10)
        {
            AnimateIdle();
        }
        if (audioData.time > 13 && flag == 0 && audioData.time < 16)
        {
            Pause();
            if (loc.transform.localPosition.x < 12.8)
            {
                if (transform.localPosition.z < -22)
                {
                    transform.localPosition += 8f * Vector3.forward * Time.deltaTime;
                }
                loc.transform.localPosition -= 5f * transform.forward * Time.deltaTime;
                if (transform.eulerAngles.y > 225.5)
                { transform.Rotate(turn * Time.deltaTime * 1.2f); }
                if (Recording.transform.position.x < 15.42) { Recording.transform.position += 5f * Recording.transform.forward * Time.deltaTime; }
            }
            else
            {
                flag = 1;
                AnimateExplainRight();
            }
        }
        if (audioData.time > 13 && flag == 1 && audioData.time < 16)
        {
            print("Here");
            AnimateExplainRight();
            Unpause();
            reflect.transform.localPosition = new Vector3(2.02f, 5.84f, -3.01f);
            QA.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (audioData.time > 16.4f && flag == 1 && audioData.time < 16.6)
        {
            Debug.Log("Pause: " + audioData.time);
            Pause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = false;
            rec.enabled = false;
            Recording.GetComponent<RecordingCanvas>().start = 4;
            speak = true;
            flag = 3;
        }
        if (audioData.time > 16.4f && flag == 2 && audioData.time < 16.8)
        {
            timer += Time.deltaTime;
            if (Recording.GetComponent<RecordingCanvas>().answer == 1)
            {
                QA.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                QA.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Animation>().enabled = true;
            }
            else if (Recording.GetComponent<RecordingCanvas>().answer == 2)
            { QA.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                QA.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Animation>().enabled = true;
                QA.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Animation>().enabled = true;

            }

            if (timer > 3)
            {
                flag = 4;
                Recording.GetComponent<RecordingCanvas>().start = 3;
                QA.transform.GetChild(0).gameObject.SetActive(false);
                QA.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                QA.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                Unpause();
            }
        }
        if (audioData.time > 18 && audioData.time < 20)
        { QA.transform.GetChild(1).gameObject.SetActive(true); timer = 0; }
            if (audioData.time > 22.2 && flag == 4 && audioData.time < 22.5)
        {
            Debug.Log("Pause: " + audioData.time);
            Pause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = false;
            rec.enabled = false;
            Recording.GetComponent<RecordingCanvas>().start = 5;
            speak = true;
            flag = 3;
            //QA.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (audioData.time > 22.2 && flag == 2 && audioData.time < 23)
        {
            timer += Time.deltaTime;
           
            if(Recording.GetComponent<RecordingCanvas>().answer == 1) {
                QA.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                QA.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Animation>().enabled = true;

            }
            else if(Recording.GetComponent<RecordingCanvas>().answer == 2) { QA.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.SetActive(true); QA.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Animation>().enabled = true;
                QA.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Animation>().enabled = true;
            }
            if (timer > 3)
            {
                flag = 6;
                Recording.GetComponent<RecordingCanvas>().start = 3;
                QA.transform.GetChild(1).gameObject.SetActive(false);
                QA.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                QA.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                Unpause();
            }
        }
        if (audioData.time > 23 && audioData.time < 24)
        { QA.transform.GetChild(2).gameObject.SetActive(true); timer = 0; }
        if (audioData.time > 27 && flag == 6 && audioData.time < 27.5)
        {
            Debug.Log("Pause: " + audioData.time);
            Pause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = false;
            rec.enabled = false;
            Recording.GetComponent<RecordingCanvas>().start = 6;
            speak = true;
            flag = 3;
        }
        if (audioData.time > 27 && flag == 2 && audioData.time < 27.9)
        {
            timer += Time.deltaTime;
            if (Recording.GetComponent<RecordingCanvas>().answer == 1)
            {
                QA.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                QA.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Animation>().enabled = true;
            }
            else if (Recording.GetComponent<RecordingCanvas>().answer == 2) { QA.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.SetActive(true); QA.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Animation>().enabled = true;
                QA.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Animation>().enabled = true;

            }

            if (timer > 3)
            {
                flag = 5;
                Recording.GetComponent<RecordingCanvas>().start = 3;
                QA.transform.GetChild(2).gameObject.SetActive(false);
                QA.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                QA.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                Unpause();
            }
        }
        if (audioData.time > 27.9 && flag == 5)
        {
            if (loc.transform.position.z > 7.83)
            {
                loc.transform.position -= 10f * Vector3.forward * Time.deltaTime;
            }

            if (transform.eulerAngles.y < 270)
            { transform.Rotate(turn2 * Time.deltaTime * 2f); }
            else
            {
            
                if (audioData.time > 33)
                { AnimateBye();
                    ended_Scene = true;

                }
                else { AnimateWelcome(); }
            }

        }

        if (ended_Scene )
        {
            now += Time.deltaTime;
            if (now > 5f)
            {

                // hnhot scene tanya hnaaa
                SceneManager.LoadScene("Channeltry");
            }
        }
        //if (audioData.time > 18.8 && flag == 0 && audioData.time < 19)
        //{
          //  Debug.Log("Paused to Speak: " + audioData.time);
         //   Pause();
          //  Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = false;
         ///   rec.enabled = false;
         //   Recording.GetComponent<RecordingCanvas>().start = 1;
         //   speak = true;
         //   flag = 1;
        //}

        if (Recording.GetComponent<RecordingCanvas>().start == 2 && flag == 1 && quizs == false)
        {
            Unpause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = true;
            rec.enabled = true;
            speak = false;
            flag = 2;
            print("UnPaused Norm");

        }
        if (Recording.GetComponent<RecordingCanvas>().start == 8 && flag == 3 )
        {
            audioData.time = 16.3f;
            Unpause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = true;
            rec.enabled = true;
            print("UnPaused Error");
            flag = 1;
        }
        if (Recording.GetComponent<RecordingCanvas>().start == 9 && flag == 3)
        {
            audioData.time = 21.9f;
            Unpause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = true;
            rec.enabled = true;
            print("UnPaused Error");
            flag = 4;
        }
        if (Recording.GetComponent<RecordingCanvas>().start == 10 && flag == 3)
        {
            audioData.time = 26.8f;
            Unpause();
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = true;
            rec.enabled = true;
            print("UnPaused Error");
            flag = 6;
        }
        if (Recording.GetComponent<RecordingCanvas>().start == 2 && flag == 3 )
        {
            Recording.GetComponentInChildren<ResonanceAudioListener>().enabled = true;
            rec.enabled = true;
            speak = false;
            flag = 2;

        }
        
        
        if (audioData.time > 29.2 && audioData.time < 29.3 && flag == 0)
        {
            AnimateIdle();
            text.transform.GetChild(6).gameObject.SetActive(false);
            text.transform.GetChild(7).gameObject.SetActive(false);
            Pause();
            if (loc.transform.position.z < 14.58)
            {
                loc.transform.position += 7f * Vector3.forward * Time.deltaTime;
                anim.enabled = true;

            }
            else
            {
                if (transform.eulerAngles.y > 245.5)
                { transform.Rotate(turn * Time.deltaTime * 1.2f); }
                else
                {
                    //flag = 2;
                    //wheel.rend.enabled = true;

                }

            }
            //loc.transform.position = new Vector3(-1.46f,loc.transform.position.y,14.58f);
            //transform.Rotate(0, -25f, 0, Space.Self);

        }




           
            

           



            if (Input.GetKey("left"))
            {
                //Pause();
                //Debug.Log("Pause: " + audioData.time);
                Recording.GetComponent<RecordingCanvas>().answer = 1;
        }
            if (Input.GetKey("right"))
            {
            //Unpause();
            //Debug.Log("Pause: " + audioData.time);
            Recording.GetComponent<RecordingCanvas>().answer = 2;
            }
            if (Input.GetKey("up"))
            {
                Recording.GetComponent<RecordingCanvas>().start = 2;
            }
            if (Input.GetKey("down"))
            {
                Recording.GetComponent<RecordingCanvas>().start = 10;
                //Recording.GetComponent<RecordingCanvas>().flag = 0;
            }

        
        IEnumerator Example()
        {
            Pause();
            yield return new WaitForSeconds(5);
            Unpause();
        }
    }
    
    #region Attribute
    private Animator animator;
    private const string IDLE_ANIMATION_BOOL = "Idle";
    private const string BYE_ANIMATION_BOOL = "bye";
    private const string WELCOME_ANIMATION_BOOL = "greet";
    private const string GREET_ANIMATION_BOOL = "greet 2";
    private const string EXPLAIN_RIGHT_ANIMATION_BOOL = "Exp right";
    private const string EXPLAIN_LEFT_ANIMATION_BOOL = "Exp left";
    private const string RAISE_UP_HANDS_ANIMATION_BOOL = "Raise Both";
    #endregion
    // Use this for initialization
    AudioSource audioData;
    private int flag = 0;
    
    private void DisableOtherAnimations(Animator animator, string animation)
    {
        foreach(AnimatorControllerParameter parameter in animator.parameters)
        {
            if(parameter.name != animation)
            {
                animator.SetBool(parameter.name, false);
            }
        }
    }
    #region Animate Functions
    public void AnimateIdle()
    {
        Animate(IDLE_ANIMATION_BOOL);
    }
    public void AnimateWelcome()
    {
        Animate(WELCOME_ANIMATION_BOOL);
    }
    public void AnimateGreet()
    {
        Animate(GREET_ANIMATION_BOOL);
    }
    public void AnimateExplainRight()
    {
        Animate(EXPLAIN_RIGHT_ANIMATION_BOOL);
    }
    public void AnimateExplainLeft()
    {
        Animate(EXPLAIN_LEFT_ANIMATION_BOOL);
    }
    public void AnimateRaiseuphands()
    {
        Animate(RAISE_UP_HANDS_ANIMATION_BOOL);
    }
    public void AnimateBye()
    {
        Animate(BYE_ANIMATION_BOOL);
    }
    #endregion
    private void Animate(string boolName)
    {
        DisableOtherAnimations(animator,boolName);
        animator.SetBool(boolName, true);
    }
    // Update is called once per frame
    public void Unpause()
    {
        
        audioData.UnPause();
    }
    public void Pause()
    {
        audioData.Pause();
    }
    
    
}
