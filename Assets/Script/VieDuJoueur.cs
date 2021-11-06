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
        if (currentHealth <=0)
        GameManager.instance.isDead = true;
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
        yield return new WaitForSeconds(3);
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
