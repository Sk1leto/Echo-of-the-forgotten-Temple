using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentForCutScene : MonoBehaviour
{
    [SerializeField] public GameObject Parent;
    
    


    public void SetParent(GameObject newParent)
    {
        gameObject.transform.parent = newParent.transform;
        gameObject.transform.localPosition = new Vector3( (float)-0.45 , (float)-0.45, (float)-0.1);
        
    }
}
