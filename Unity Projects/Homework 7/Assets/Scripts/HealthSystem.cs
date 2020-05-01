using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour{
    public int health;
    public int maxHealth;
    public event EventHandler OnHealthChanged;

    public HealthSystem(int maxHealth) {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    public float GetHealthPercent() {
        return (float) health / maxHealth; 
    }

    public void TakeDamage(int damage) {
        health -= damage;

        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }
}
