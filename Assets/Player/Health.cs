using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour,IDamageable
{
    public int Hp = 0;
    [SerializeField] private TextMeshProUGUI txtHp;
    //[SerializeField]private bool

    // Start is called before the first frame update
    void Start()
    {
        Hp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp > 0)
        {

        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void TakeDamage(float dmg)
    {
        Debug.Log("TakeDamage");
        transform.GetComponentInChildren<Collider2D>().enabled = false;
        Hp -= 1;
        txtHp.text = Hp + "";
        StartCoroutine(DelayedAction());

    }

    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(.5f);
        Debug.Log("3 seconds have passed!");
        transform.GetComponentInChildren<Collider2D>().enabled = true;
    }


}
