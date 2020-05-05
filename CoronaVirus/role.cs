using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class role : MonoBehaviour
{

    //time interval of images of scene#1
    float upRightTimeInterval  = 4;
    float upLeftTimeInterval  = 7;
    float downRightTimeInterval  = 8;
    float el23radTimeInterval = 1;
    float elw2tTimeInterval = 10;
    float percentageTimeInterval = 24;
    float now = 0;


    //Time intervals of scene2
    float Scene2Begin = 67;
    float imag0Interval = 68;
    float imag1Interval = 74;
    float imag2Interval = 81;
    float imag3Interval =88;
    float imag4Interval = 94;
    float imag5Interval = 98;
    

    //Time interval of Scene3
    float Scene3Begin = 25;
    float Sce3imag0Interval = 25;
    float Sce3imag1Interval = 26;
    float Sce3imag2Interval = 28;
    float Sce3imag3Interval = 31;
    float Sce3imag4Interval = 35;
    float Sce3imag5Interval = 39;
    float Sce3imag6Interval = 41;
    float Sce3imag7Interval = 43;
    float Sce3imag8Interval = 47;


    //Time interval of Scene4
    float Scene4Begin = 51;
    float Sce4imag0Interval = 52;
    float Sce4imag1Interval = 54;
    float Sce4imag2Interval = 60;
    float Sce4imag3Interval = 62;
    float Sce4imag4Interval = 64;
    float Sce4imag5Interval = 65;


    //Time interval for ARscene
    float ArSceneEnd = 104;
    // input Corona Objett
    [SerializeField]
    GameObject corona;
    // input Scene #1 objects
    [SerializeField]
    GameObject [] Scene1Objects;

    //input Scene#2
    [SerializeField]
    GameObject[] Scene2Objects;

    //input Scene#3
    [SerializeField]
    GameObject[] Scene3Objects;

    //input Scene#4
    [SerializeField]
    GameObject[] Scene4Objects;

    //Scene1Flags
    //#1 for crona
    //#2 for up_Right image
    //#3 for up_left image
    //#4 for down_Right image
    bool Scene1FlagsCorona = false;
    bool Scene1Flags_upRight = false;
    bool Scene1Flags_upLeft = false;
    bool Scene1Flags_downRight = false;
    bool Scene1Flags_23rad = false;
    bool Scene1Flags_wa2t = false;
    bool Scene1Flags_percentage = false;

    //Scene2 flags
    bool Scene2Flagsimag0 = false;
    bool Scene2Flagsimag1 = false;
    bool Scene2Flagsimag2 = false;
    bool Scene2Flagsimag3 = false;
    bool Scene2Flagsimag4 = false;
    bool Scene2Flagsimag5 = false;

    //Scene3 flags
    bool Scene3Flagsimag0 = false;
    bool Scene3Flagsimag1 = false;
    bool Scene3Flagsimag2 = false;
    bool Scene3Flagsimag3 = false;
    bool Scene3Flagsimag4 = false;
    bool Scene3Flagsimag5 = false;
    bool Scene3Flagsimag6 = false;
    bool Scene3Flagsimag7 = false;
    bool Scene3Flagsimag8 = false;


    //Scene4 flags
    bool Scene4Flagsimag0 = false;
    bool Scene4Flagsimag1 = false;
    bool Scene4Flagsimag2 = false;
    bool Scene4Flagsimag3 = false;
    bool Scene4Flagsimag4 = false;
    bool Scene4Flagsimag5 = false;
    //to occuby the gameObjects
    //#1 for crona
    //#2 for up_Right image
    //#3 for up_left image
    //#4 for down_Right image
    GameObject Corona;
    GameObject upRightImage;
    GameObject upLefttImage;
    GameObject downRightImage;
    GameObject el23radImage;
    GameObject wa2tImage;
    GameObject percentageImage;

    // Scene2 GameObjects
    GameObject objimag0;
    GameObject objimag1;
    GameObject objimag2;
    GameObject objimag3;
    GameObject objimag4;
    GameObject objimag5;

    // Scene3 GameObjects
    GameObject Sc3imag0;
    GameObject Sc3imag1;
    GameObject Sc3imag2;
    GameObject Sc3imag3;
    GameObject Sc3imag4;
    GameObject Sc3imag5;
    GameObject Sc3imag6;
    GameObject Sc3imag7;
    GameObject Sc3imag8;

    // Scene4 GameObjects
    GameObject Sc4imag0;
    GameObject Sc4imag1;
    GameObject Sc4imag2;
    GameObject Sc4imag3;
    GameObject Sc4imag4;
    GameObject Sc4imag5;
    //flag to delete scene #1
    bool Scene1Delete = false;
    bool Scene3Delete = false;
    bool Scene4Delete = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Instantiate Crona 3dModel
        if (Scene1FlagsCorona == false)
        {
             Corona = Instantiate(corona);
             Scene1FlagsCorona = true;
             Corona.transform.parent = transform;
        }
        now += Time.deltaTime;
        #region
        if (now <= Scene2Begin)
        {
            if (now >= el23radTimeInterval && Scene1Flags_23rad == false)
            {
                el23radImage = Instantiate(Scene1Objects[0]);
                el23radImage.transform.parent = transform;
                Scene1Flags_23rad = true;
            }
            else if (now >= elw2tTimeInterval && Scene1Flags_wa2t == false)
            {
                wa2tImage = Instantiate(Scene1Objects[4]);
                wa2tImage.transform.parent = transform;
                Scene1Flags_wa2t = true;
            }
           
            else if (now >= percentageTimeInterval && Scene1Flags_percentage == false)
            {
                percentageImage = Instantiate(Scene1Objects[5]);
                percentageImage.transform.parent = transform;
                Scene1Flags_percentage = true;
            }
            // Instantiate Upper Right image
            else if (now >= upRightTimeInterval && Scene1Flags_upRight == false)
            {
                upRightImage = Instantiate(Scene1Objects[1]);
                upRightImage.transform.parent = transform;
                Scene1Flags_upRight = true;
            }
            // Instantiate Upper left image
            else if (now >= upLeftTimeInterval && Scene1Flags_upLeft == false)
            {
                upLefttImage = Instantiate(Scene1Objects[2]);
                upLefttImage.transform.parent = transform;
                Scene1Flags_upLeft = true;

            }
            // Instantiate lower Right image
            else if (now >= downRightTimeInterval && Scene1Flags_downRight == false)
            {
                downRightImage = Instantiate(Scene1Objects[3]);
                downRightImage.transform.parent = transform;
                Scene1Flags_downRight = true;

            }
            #endregion
            #region
            //*******************************************************         Scene4      **********************************************************************************

            if (now >= Scene4Begin)
            {
                if (Scene3Delete == false)
                {
                    Destroy(Sc3imag0); Destroy(Sc3imag1); Destroy(Sc3imag2); Destroy(Sc3imag3); Destroy(Sc3imag4); Destroy(Sc3imag5); Destroy(Sc3imag6);
                    Destroy(Sc3imag7); Destroy(Sc3imag8);
                    Scene3Delete = true;
                }

                if (now >= Sce4imag0Interval && Scene4Flagsimag0 == false)
                {
                    Sc4imag0 = Instantiate(Scene4Objects[0]);
                    Sc4imag0.transform.parent = transform;
                    Scene4Flagsimag0 = true;
                }

                else if (now >= Sce4imag1Interval && Scene4Flagsimag1 == false)
                {
                    Sc4imag1 = Instantiate(Scene4Objects[1]);
                    Sc4imag1.transform.parent = transform;
                    Scene4Flagsimag1 = true;
                }

                else if (now >= Sce4imag2Interval && Scene4Flagsimag2 == false)
                {
                    Sc4imag2 = Instantiate(Scene4Objects[2]);
                    Sc4imag2.transform.parent = transform;
                    Scene4Flagsimag2 = true;
                }
                else if (now >= Sce4imag3Interval && Scene4Flagsimag3 == false)
                {
                    Sc4imag3 = Instantiate(Scene4Objects[3]);
                    Sc4imag3.transform.parent = transform;
                    Scene4Flagsimag3 = true;
                }

                else if (now >= Sce4imag4Interval && Scene4Flagsimag4 == false)
                {
                    Sc4imag4 = Instantiate(Scene4Objects[4]);
                    Sc4imag4.transform.parent = transform;
                    Scene4Flagsimag4 = true;
                }

                else if (now >= Sce4imag5Interval && Scene4Flagsimag5 == false)
                {
                    Sc4imag5 = Instantiate(Scene4Objects[5]);
                    Sc4imag5.transform.parent = transform;
                    Scene4Flagsimag5 = true;
                }
            }

            //*******************************************************        Scene3        **********************************************************************************
            else if (now >= Scene3Begin)
            {

                if (Scene1Delete == false)
                {
                    Destroy(upRightImage);
                    Destroy(upLefttImage);
                    Destroy(downRightImage);
                    Destroy(el23radImage);
                    Destroy(wa2tImage);
                    Destroy(percentageImage);
                    Scene1Delete = true;
                }

                if (now >= Sce3imag0Interval && Scene3Flagsimag0 == false)
                {
                    Sc3imag0 = Instantiate(Scene3Objects[0]);
                    Sc3imag0.transform.parent = transform;
                    Scene3Flagsimag0 = true;

                }

                else if (now >= Sce3imag1Interval && Scene3Flagsimag1 == false)
                {
                    Sc3imag1 = Instantiate(Scene3Objects[1]);
                    Sc3imag1.transform.parent = transform;
                    Scene3Flagsimag1 = true;
                }

                else if (now >= Sce3imag2Interval && Scene3Flagsimag2 == false)
                {
                    Sc3imag2 = Instantiate(Scene3Objects[2]);
                    Sc3imag2.transform.parent = transform;
                    Scene3Flagsimag2 = true;
                }
                else if (now >= Sce3imag3Interval && Scene3Flagsimag3 == false)
                {
                    Sc3imag3 = Instantiate(Scene3Objects[3]);
                    Sc3imag3.transform.parent = transform;
                    Scene3Flagsimag3 = true;
                }

                else if (now >= Sce3imag4Interval && Scene3Flagsimag4 == false)
                {
                    Sc3imag4 = Instantiate(Scene3Objects[4]);
                    Sc3imag4.transform.parent = transform;
                    Scene3Flagsimag4 = true;
                }

                else if (now >= Sce3imag5Interval && Scene3Flagsimag5 == false)
                {
                    Sc3imag5 = Instantiate(Scene3Objects[5]);
                    Sc3imag5.transform.parent = transform;
                    Scene3Flagsimag5 = true;
                }
                else if (now >= Sce3imag6Interval && Scene3Flagsimag6 == false)
                {
                    Sc3imag6 = Instantiate(Scene3Objects[6]);
                    Sc3imag6.transform.parent = transform;
                    Scene3Flagsimag6 = true;
                }

                else if (now >= Sce3imag7Interval && Scene3Flagsimag7 == false)
                {
                    Sc3imag7 = Instantiate(Scene3Objects[7]);
                    Sc3imag7.transform.parent = transform;
                    Scene3Flagsimag7 = true;
                }

                else if (now >= Sce3imag8Interval && Scene3Flagsimag8 == false)
                {
                    Sc3imag8 = Instantiate(Scene3Objects[8]);
                    Sc3imag8.transform.parent = transform;
                    Scene3Flagsimag8 = true;
                }
            }
            #endregion

        }
        else
        {
            if (Scene4Delete == false)
            {
                Destroy(Sc4imag0);Destroy(Sc4imag1);Destroy(Sc4imag2);Destroy(Sc4imag3);Destroy(Sc4imag4);Destroy(Sc4imag5);              
                Scene4Delete = true;
            }
            if (now >= imag0Interval && Scene2Flagsimag0 == false)
            {
                objimag0 = Instantiate(Scene2Objects[0]);
                objimag0.transform.parent = transform;
                Scene2Flagsimag0 = true;
            }
            else if (now >= imag1Interval && Scene2Flagsimag1 == false)
            {
                objimag1 = Instantiate(Scene2Objects[1]);
                objimag1.transform.parent = transform;
                Scene2Flagsimag1 = true;
            }
            else if (now >= imag2Interval && Scene2Flagsimag2 == false)
            {
                objimag2 = Instantiate(Scene2Objects[2]);
                objimag2.transform.parent = transform;
                Scene2Flagsimag2 = true;
            }

            else if (now >= imag3Interval && Scene2Flagsimag3 == false)
            {
                objimag3 = Instantiate(Scene2Objects[3]);
                objimag3.transform.parent = transform;
                Scene2Flagsimag3 = true;
            }
            // Instantiate Upper Right image
            else if (now >= imag4Interval && Scene2Flagsimag4 == false)
            {
                objimag4 = Instantiate(Scene2Objects[4]);
                objimag4.transform.parent = transform;
                Scene2Flagsimag4 = true;
            }
            // Instantiate Upper left image
            else if (now >= imag5Interval && Scene2Flagsimag5 == false)
            {
                objimag5 = Instantiate(Scene2Objects[5]);
                objimag5.transform.parent = transform;
                Scene2Flagsimag5 = true;    
            }

            else if (now > ArSceneEnd)
            {
                SceneManager.LoadScene("Quiz");
            }
            // Instantiate lower Right image

        }
       
       


    }
        // Destroy all objects after disappearing the marker
        public void DeleteObj ()
        {
        Destroy(Corona);
        if (Scene1Delete == false)
        {
            Destroy(upRightImage);
            Destroy(upLefttImage);
            Destroy(downRightImage);
            Destroy(el23radImage);
            Destroy(wa2tImage);
            Destroy(percentageImage);
        }
        Destroy(objimag0);
        Destroy(objimag1);
        Destroy(objimag2);
        Destroy(objimag3);
        Destroy(objimag4);
        Destroy(objimag5);
        Scene1FlagsCorona = false;
        Scene1Flags_upRight = false;
        Scene1Flags_upLeft = false;
        Scene1Flags_downRight = false;
        Scene1Flags_23rad = false;
        Scene1Flags_wa2t = false;
        Scene1Flags_percentage = false;
        Scene2Flagsimag0 = false;
        Scene2Flagsimag1 = false;
        Scene2Flagsimag2 = false;
        Scene2Flagsimag3 = false;
        Scene2Flagsimag4 = false;
        Scene2Flagsimag5 = false;

        Scene4Flagsimag0 = false;
        Scene4Flagsimag1 = false;
        Scene4Flagsimag2 = false;
        Scene4Flagsimag3 = false;
        Scene4Flagsimag4 = false;
        Scene4Flagsimag5 = false;

        Scene3Flagsimag0 = false;
        Scene3Flagsimag1 = false;
        Scene3Flagsimag2 = false;
        Scene3Flagsimag3 = false;
        Scene3Flagsimag4 = false;
        Scene3Flagsimag5 = false;
        Scene3Flagsimag6 = false;
        Scene3Flagsimag7 = false;
        Scene3Flagsimag8 = false;

        Scene1Delete = false;
        Scene3Delete = false;
        Scene4Delete = false;
    }
}
