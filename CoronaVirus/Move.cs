using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float gameTimer = 0f;
    public float speed = 2.5f;
    private bool invert = false;
    private bool flag = false;
    private bool flag2 = false;
    private float timer = 0;
    private bool cure = false;
    private Animation rend;
    private Animator anim;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
            var pos = transform.position;
            if (invert == false) { transform.position += transform.forward * speed * Time.deltaTime; flag = false; }
            if (invert == true) { transform.position -= transform.forward * speed * Time.deltaTime; flag = true; }
            if (transform.tag == "infected")
            {
                gameTimer += Time.deltaTime;

            }
            if (gameTimer > 10f) { transform.tag = "cured"; AnimateGreet(); cure = true; }
            if (transform.position.x < -16.2f)
            {
                if (invert) { invert = false; } else { invert = true; }
                //pos.x += 0.5f;
                //transform.position = pos;
            }
            if (transform.position.x > 14.2f)
            {
                if (invert) { invert = false; } else { invert = true; }
                //pos.x -= 0.5f;
                //transform.position = pos;
            }
            if (transform.position.z > 15.5f)
            {
                if (invert) { invert = false; } else { invert = true; }
                //pos.z -= 0.5f;
                //transform.position = pos;
            }
            if (transform.position.z < -15.4f)
            {
                if (invert) { invert = false; } else { invert = true; }
                //pos.z += 0.5f;
                //transform.position = pos;
            }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "infected" && invert == false && flag == false && cure == false)
        {
            Debug.Log("Hit the Floor");
            transform.tag = "infected";
            AnimateWelcome();
            invert = true;
            Debug.Log("1");
        }
        else if (collision.transform.tag == "infected" && invert == true && flag == true && cure == false)
        {
            Debug.Log("Hit the Floor");
            transform.tag = "infected";
            AnimateWelcome();
            invert = false;
            Debug.Log("2");
        }
        else if (collision.transform.tag == "wall" && invert == false && flag == false || collision.transform.tag == "Normal" && invert == false && flag == false || collision.transform.tag == "cured" && invert == false && flag == false )
        {
            invert = true;
            Debug.Log("Wall");
        }
       else if ( collision.transform.tag == "wall" && invert == true && flag == true || collision.transform.tag == "Normal" && invert == true && flag == true || collision.transform.tag == "cured" && invert == true && flag == true )
        {
            invert = false;
            Debug.Log("Wall");
            
        }
        // Makes the reflected object appear opposite of the original object,
        // mirrored along the z-axis of the world

    }
    #region Attribute
    private Animator animator;
    private const string NORMAL_ANIMATION_BOOL = "normal";
    private const string INFECTED_ANIMATION_BOOL = "infected";
    private const string CURED_ANIMATION_BOOL = "cured";
    #endregion
    private void DisableOtherAnimations(Animator animator, string animation)
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.name != animation)
            {
                animator.SetBool(parameter.name, false);
            }
        }
    }
    #region Animate Functions
    public void AnimateIdle()
    {
        Animate(NORMAL_ANIMATION_BOOL);
    }
    public void AnimateWelcome()
    {
        Animate(INFECTED_ANIMATION_BOOL);
    }
    public void AnimateGreet()
    {
        Animate(CURED_ANIMATION_BOOL);
    }
    #endregion
    private void Animate(string boolName)
    {
        DisableOtherAnimations(animator, boolName);
        animator.SetBool(boolName, true);
    }

}
