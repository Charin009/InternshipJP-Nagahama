using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Assign behavior to all ball models.
 * All ball models create stick model when it intersect with other ball.
 */
public class ModelTrigger : MonoBehaviour
{
    private bool isTriggered;
    private GameObject StickParentPosition;
    public GameObject Stick;


    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;
    }

    /*Create stick model when other collision intersect with this collision
     */  
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Model"&& isTriggered == false)
        {
            StickParentPosition = GameObject.Find("StickSpawn");
            Vector3 thisPosition = this.transform.position;
            Vector3 otherPosition = other.gameObject.transform.position;
            float distance = Vector3.Distance(thisPosition,otherPosition);
            GameObject tmpStick = Instantiate(Stick, new Vector3((thisPosition.x + otherPosition.x) / 2, (thisPosition.y + otherPosition.y) / 2, (thisPosition.z + otherPosition.z) / 2), Quaternion.identity);
            tmpStick.transform.GetChild(0).localScale = new Vector3(0.05f, distance / 2, 0.05f);
            tmpStick.transform.LookAt(thisPosition, Vector3.up);
            tmpStick.transform.SetParent(StickParentPosition.transform);
        }
    }

    /* Set isTriggered.
     * isTriggered is param to activate or disable OnCollisionEnter()
     */
    public void SetIsTriggered(bool isTriggered)
    {
        this.isTriggered = isTriggered;
    }
     
}
