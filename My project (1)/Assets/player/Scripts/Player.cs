using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
 public int health;
 private Health healthComponent;

  void Start()
 {
  healthComponent= GetComponent<Health>();
  healthComponent.OnHealthChanged += UpdateHealth;
 }


 private void OnDestroy()
 {
  if (healthComponent != null)
  {
   healthComponent.OnHealthChanged -= UpdateHealth; // Отписываемся от события
  }
 }

 public void UpdateHealth(int currentHealth, int maxHealth)
 {
  health = currentHealth;
  Debug.Log(health+" Текущее хп");
 }
}
