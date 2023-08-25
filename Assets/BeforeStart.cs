using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BeforeStart : MonoBehaviour
{
    public int Health = 0;

    private void Awake()
    {


    }
    void Start()
    {

        GameController.Instance.state = GameState.GameEnding;
        Time.timeScale = 0;
        Movement.instance.jump = false;
        Movement.instance.slide = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.P))
        {
            GameController.Instance.state = GameState.GameEnding;
            Time.timeScale = 0;
        }

        if (Input.GetKey(KeyCode.Space) && Movement.instance.jump == false && Movement.instance.slide == false)
        {
            GameController.Instance.state = GameState.Start;
            Time.timeScale = 1;
            JumpOnStart();
        }

    }

    public void JumpOnStart()
    {
        Movement.instance.jump = true;
        Movement.instance.rb.constraints = RigidbodyConstraints2D.None;
        Movement.instance.rb.AddForce(transform.up * Movement.instance.jumeForce, ForceMode2D.Impulse);
    }
}
