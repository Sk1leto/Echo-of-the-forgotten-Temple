using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapShooting : MonoBehaviour

{
    public GameObject ArrowPrefab;  // Префаб огненного шара
    public Transform firePoint1;

    public float fireballSpeed = 15f;  // Скорость полета шара
    public float fireRate = 1.5f;      // Задержка между выстрелами (в секундах)
    public Movement movement;
    private float nextTimeToFire = 0f;
    // Таймер для отслеживания времени до следующего выстрела
    void Start(){
        movement = GetComponent<Movement>();
    }
    void Update()
    {
        // Если нажата кнопка и время до следующего выстрела прошло
        if ( Time.time >= nextTimeToFire)
        {
            ShootFireball();  // Выпустить огненный шар
            nextTimeToFire = Time.time + fireRate;
            
            // Обновляем таймер до следующего выстрела
        }
    }

    void ShootFireball()
    {
        // Создаем новый огненный шар в точке выстрела с текущим вращением
      
        GameObject fireball = Instantiate(ArrowPrefab, firePoint1.position, firePoint1.rotation);
      
        // Получаем компонент Rigidbody, чтобы задать скорость полета шара
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        rb.velocity = firePoint1.forward * fireballSpeed; 
   
        Destroy(fireball, 3f);
        // Если есть дополнительные эффекты или звуки, можно их также добавить сюда.
        
    }
}
