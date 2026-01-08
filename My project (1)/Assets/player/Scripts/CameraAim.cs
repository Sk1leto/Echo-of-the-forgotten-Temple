using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraAim : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;  // Ссылка на Cinemachine виртуальную камеру
    public Transform newTarget;                     // Новый объект, за которым будет следовать камера
    public Transform DefaultTarget;
    public GameObject crosshair;
    
    

    void Start()
    {
        virtualCamera = gameObject.GetComponent<CinemachineVirtualCamera>();
        crosshair.SetActive(false);
    }
    void Update()
    {
        // Проверяем нажатие кнопки, например "F" для смены цели
        if (Input.GetMouseButtonDown(1))
        {
            SetNewFollowTarget(newTarget);
            crosshair.SetActive(true);
            
        }

        if (Input.GetMouseButtonUp(1))
        {
            SetNewFollowTarget(DefaultTarget);
            crosshair.SetActive(false);
        }
        
        
    }

  public  void SetNewFollowTarget(Transform target)
    {
        // Устанавливаем новую цель для следования
        virtualCamera.Follow = target;
    }

 
    public void SetToDefaultTarget()
    {
        virtualCamera.Follow = DefaultTarget;
    }

   
}