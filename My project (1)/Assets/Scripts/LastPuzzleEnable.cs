
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPuzzleEnable : MonoBehaviour
{private GameObject currentPuzzle;
    private PickUpItem pickUpItem;
    [SerializeField] private GameObject lastPuzzle;
    [SerializeField] Animator animator;
    [SerializeField] GameObject crystal;
 
    public Puzzle puzzle;

    void Start()

    {
        puzzle = GetComponent<Puzzle>();
     
        if (puzzle.isSolved==true)
        {
            currentPuzzle = crystal;
            currentPuzzle.GetComponent<Rigidbody>().isKinematic = true;
            currentPuzzle.transform.parent = transform;
            currentPuzzle.transform.localPosition = Vector3.zero;
            currentPuzzle.transform.localEulerAngles=new Vector3(0.0f,0.0f,0.0f);
            
            animator.SetBool("IsOpen",true);
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Crystal"))
        {
         
            if (Input.GetKeyDown(KeyCode.E))
                
            {  
                currentPuzzle = other.transform.gameObject;
               
               
               currentPuzzle.GetComponent<Rigidbody>().isKinematic = true;
               currentPuzzle.transform.parent = transform;
               currentPuzzle.transform.localPosition = Vector3.zero;
               currentPuzzle.transform.localEulerAngles=new Vector3(0.0f,0.0f,0.0f);
               pickUpItem =  lastPuzzle.GetComponent<PickUpItem>();
               pickUpItem.OffPart(); 
               animator.SetBool("IsOpen",true);
               puzzle.SolvePuzzle();
                         
            }
        }
    }
    
}
