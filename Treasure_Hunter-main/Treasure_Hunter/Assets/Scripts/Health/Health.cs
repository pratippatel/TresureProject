using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    [SerializeField] private float startHealth;
    public float currHealth { get; private set; }
    private Animator anim;
    private bool dead;
    
    // Start is called before the first frame update
    void Start()
    {
        currHealth = startHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currHealth = Mathf.Clamp(currHealth - damage, 0, startHealth);
        
        if (currHealth > 0) //player gets hurt
        {
            anim.SetTrigger("hurt");
        }
        else //player dies
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                SceneManager.LoadScene(1);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            TakeDamage(1);
        }
    }
}
