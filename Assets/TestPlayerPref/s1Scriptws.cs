using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s1Scriptws : MonoBehaviour
{
    public int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("---------------");
        Debug.Log(x);

        if (Input.GetKey(KeyCode.P))
        {
            x++;

            //Ref
            PlayerPrefs.SetInt("kint", x);
        }
        if (Input.GetKey(KeyCode.O))
        {
            SceneManager.LoadScene("s2");
        }

    }
}
