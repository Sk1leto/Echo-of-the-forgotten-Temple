using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShooting : MonoBehaviour
{
    public GameObject fireballPrefab; // Префаб огненного шара
    public Transform firePoint; // Точка, из которой вылетает шар
    public float fireballSpeed = 15f; // Скорость полета шара
    public float fireRate = 1.5f; // Задержка между выстрелами (в секундах)
    public Movement movement;
    private float nextTimeToFire = 0f;
    [SerializeField] private AudioClip fireSound;
    
    private Animator animator;

private AudioSource audioSource;
    // Таймер для отслеживания времени до следующего выстрела
    void Start(){
        movement = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
        animator =GetComponent<Animator>();
    }
    void Update()
    {
        // Если нажата кнопка и время до следующего выстрела прошло
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            animator.SetTrigger("Fire");
            //ShootFireball();
            // Выпустить огненный шар
            nextTimeToFire = Time.time + fireRate;
            
            // Обновляем таймер до следующего выстрела
        }
    }
    public void playFireSound()
    {
        audioSource.PlayOneShot(fireSound, 1f); 
    }

    void ShootFireball()
    {
        // Создаем новый огненный шар в точке выстрела с текущим вращением
        movement.Fire();
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);

        // Получаем компонент Rigidbody, чтобы задать скорость полета шара
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * fireballSpeed;  // Задаем направление полета шара вперед
        Destroy(fireball, 3f);
    
        // Если есть дополнительные эффекты или звуки, можно их также добавить сюда.
        
    }
}
