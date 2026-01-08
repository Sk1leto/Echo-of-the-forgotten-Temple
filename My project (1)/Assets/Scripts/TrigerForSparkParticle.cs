using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerForSparkParticle : MonoBehaviour
{
    public ParticleSystem shieldParticleSystem; // Основная система частиц для щита
    public ParticleSystem impactParticleSystem; // Система частиц для искр при попадании
    public BoxCollider boxCollider;
    
    private void Start()
    {
        // Подключаемся к событиям столкновения основной системы
        var collisionModule = shieldParticleSystem.collision;
        collisionModule.sendCollisionMessages = true; 
        impactParticleSystem.Stop();
        shieldParticleSystem.Stop();
        shieldParticleSystem.GetComponent<BoxCollider>().enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            shieldParticleSystem.Play();
            shieldParticleSystem.GetComponent<BoxCollider>().enabled = true;
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
            shieldParticleSystem.Stop();
            shieldParticleSystem.GetComponent<BoxCollider>().enabled = false; 
        }
    
    }

    private void OnParticleCollision(GameObject other)
    {
        // При столкновении активируем эффект искр
        Vector3 collisionPoint = other.transform.position; // Получаем точку столкновения (пример)
        
        // Перемещаем систему частиц для искр к точке столкновения и запускаем её
        impactParticleSystem.transform.position = collisionPoint;
        impactParticleSystem.Play();
        StartCoroutine(StopParticles());
    }
    private IEnumerator StopParticles()
    {
        yield return new WaitForSeconds(impactParticleSystem.main.duration); // Ожидаем завершения эффекта
        impactParticleSystem.Stop();
    }
}