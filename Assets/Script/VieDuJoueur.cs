using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.layer);
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
