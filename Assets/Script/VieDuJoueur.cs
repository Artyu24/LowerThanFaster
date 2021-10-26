using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VieDuJoueur : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    private bool immunité=false;
    private bool zombieInRange = false;
    public SpriteRenderer spriteDuJoueur;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieInRange)
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        if (immunité == false)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            immunité = true;
            StartCoroutine(FlashImmunité());
            StartCoroutine(Immunité());
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
            zombieInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
            zombieInRange = false;
    }

    IEnumerator Immunité()
    {
        yield return new WaitForSeconds(3);
        immunité = false;
    }

    IEnumerator FlashImmunité()
    {
        while (immunité)
        {
            spriteDuJoueur.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(1 / 2);
            spriteDuJoueur.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(1 / 2);
        }
    }


}
