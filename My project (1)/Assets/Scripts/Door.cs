using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IOpenDoors
{
    public Animator m_Animator;
    public GameObject player;
    public bool isOpen=false;
    public Movement movement;
    [SerializeField] AudioClip openSound;
    private AudioSource audioSource;
    [SerializeField] GameObject CurrentItem;
    [SerializeField] Animator animator;
    [SerializeField] GameObject lever;
    private MeshRenderer mr;

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if (mr != null)
        {
            mr.enabled = false; // Отключить отображение
        }
        // Проверьте, инициализирован ли компонент аниматора
        if (m_Animator == null)
        { movement = player.GetComponent<Movement>();
            m_Animator = GetComponent<Animator>();  // Найдем аниматор, если не установлен вручную
        }
        audioSource = GetComponent<AudioSource>();
    }
    public void ToggleDoor()
    {
        if (isOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }
    
    private void OpenDoor()
    {
        isOpen = true;
        // Здесь логика анимации или механики открытия
        Debug.Log("Дверь открылась: ");
        m_Animator.SetBool("IsOpen", true);
        movement.OpenDoors();
        
        
    }

    private void opendoorsound()
    {
        audioSource.PlayOneShot(openSound,1);
    }
    private void CloseDoor()
    {
        isOpen = false;
        // Здесь логика анимации или механики закрытия
        Debug.Log("Дверь закрылась: " );
        m_Animator.SetBool("IsOpen", false);
    }

    public void OpenPuzzleDoor()
    
    {     
        CurrentItem.transform.parent = transform;
             CurrentItem.transform.localPosition = Vector3.zero;
        m_Animator.SetBool("IsOpen", true);
      
        
    }
    public void OpenChest()
    {Debug.Log("открыт сундук");
        isOpen = true;
        // Здесь логика анимации или механики открытия
        
        m_Animator.SetBool("IsOpen", true);
        
        
        
    }
    public void OpenLever()
    { mr = lever.GetComponent<MeshRenderer>();
        opendoorsound();
        isOpen = true;
        // Здесь логика анимации или механики открытия
       mr.enabled = true;
        m_Animator.SetBool("IsOpen", true);
        animator.SetBool("IsOpen", true);
        
        
        
    }

    public void Open()
    {  if (isOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }
}
