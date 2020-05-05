using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class changescene : MonoBehaviour
{
    public float changescenesec = 3f;
    public float zoom = 20f;
    private Vector3 targetposition;
    public GameObject Camera;
    public float speed = 4f;
    [SerializeField]
    GameObject[] DestroyObj;
    // Start is called before the first frame update
    void Start()
    {

        targetposition = new Vector3(zoom, Camera.transform.localPosition.y, Camera.transform.localPosition.z);

    }

    // Update is called once per frame
    void Update()
    {
        changescenesec -= Time.deltaTime;
        if (changescenesec <= 2f) {
            Camera.transform.localPosition = Vector3.Lerp(Camera.transform.localPosition, targetposition, Time.deltaTime*speed);
            Destroy(DestroyObj[0]); Destroy(DestroyObj[1]); Destroy(DestroyObj[2]); Destroy(DestroyObj[3]);
            // SceneManager.LoadScene("AREnterance");
        }
    }
}
