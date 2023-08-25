using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2 : MonoBehaviour
{
    public int x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("---------------");
        x = PlayerPrefs.GetInt("kint");
        Debug.Log(x);
    }
}
