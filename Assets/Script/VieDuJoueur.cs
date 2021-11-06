using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VieDuJoueur : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    private bool immunité=false;
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
        if (currentHealth <=0)
        GameManager.instance.isDead = true;
    }

    public void TakeDamage(int damage)
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
