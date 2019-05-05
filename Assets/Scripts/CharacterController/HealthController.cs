using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

    public delegate void OnHealthChanged();
    public OnHealthChanged OnHealthChangedCallback;


    private int CurrentHealth;
    public int MaxHealth;

    private CharController controller;

    private void Start() {
        CurrentHealth = MaxHealth;
        controller = GetComponent<CharController>();
    }


    public void AddHealth(int amount) {
        SetHealth(CurrentHealth + amount);
    }

    public void SetHealth(int health) {
        CurrentHealth = health;
        UpdateHealth();
        if (CurrentHealth <= 0) {
            OnHealthZero();
        }
        if(OnHealthChangedCallback != null) OnHealthChangedCallback.Invoke();
    }

    private void OnHealthZero() {
        controller.OnDeath();
    }

    public void UpdateHealth() {
        CurrentHealth = (int)Mathf.Clamp(CurrentHealth, 0, GetMaxHealth());
    }

    public int GetMaxHealth() {
        return MaxHealth; // + controller get equptment stats max health
    }
    public int GetCurrentHealth() {
        return CurrentHealth;
    }


}
