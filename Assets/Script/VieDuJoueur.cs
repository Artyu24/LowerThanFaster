using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VieDuJoueur : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    private bool immunit�=false;
    public SpriteRenderer spriteDuJoueur;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (immunit� == false)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            immunit� = true;
            StartCoroutine(FlashImmunit�());
            StartCoroutine(Immunit�());
        }
    }

        IEnumerator Immunit�()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 6, true);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 6, false);
        immunit� = false;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }

    IEnumerator FlashImmunit�()
    {
        while (immunit�)
        {
            spriteDuJoueur.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(1 / 2);
            spriteDuJoueur.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(1 / 2);
        }
    }


}
