using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystallScript : MonoBehaviour
{
    private ColorRay ray;
    private bool isGrowing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ray = gameObject.GetComponentInChildren<ColorRay>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ColorRay>() && other.transform.IsChildOf(transform)==false)
        {Debug.Log("Cтолкнулся");
            
            ray.Grow();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ColorRay>() )
        {
            ray.TransformToDefaultState();
            Debug.Log("В кристале вызвал сброс луча");
        }
    }
    //надо как то на луче изменить изменение коллайдера
    // работает только если у меня к первому лучу поднести и убрать кристалл
    
}
