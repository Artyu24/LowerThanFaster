using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Physics2D.IgnoreLayerCollision(gameObject.layer, 6, true);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 6, false);
        immunité = false;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Death");
        }
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
