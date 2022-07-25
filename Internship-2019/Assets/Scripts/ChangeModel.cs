using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ChangeModel use to assign behavoir to the button that use to change style of het-atom's model
 */
public class ChangeModel : MonoBehaviour
{
    /*Parameter to check current style of model
     */  
    private int currentStyle;

    /* Array that contain all of ball model in the program.
     */  
    GameObject[] allBall;

    /*Behavior of button 
     * if currentStyle is 2 (or CPK sphere) it will change model to Ball and Stick style.
     * else nothing happen when the button has clicked.
     */  
    public void onClickBallAndStick()
    {
        allBall = GameObject.FindGameObjectsWithTag("Model");
        if (currentStyle == 2)
        {
            foreach(GameObject ball in allBall)
            {
                ball.transform.localScale = new Vector3(ball.transform.localScale.x * 0.3f, ball.transform.localScale.y * 0.3f, ball.transform.localScale.z * 0.3f);
            }
            currentStyle = 1;
        }   
    }

    /*Behavior of button 
    * if currentStyle is 1 (or Ball and Stick) it will change model to CPK Sphere style.
    * else nothing happen when the button has clicked.
    */
    public void onClickCPKSphere()
    {
        allBall = GameObject.FindGameObjectsWithTag("Model");
        if (currentStyle == 1)
        {
            foreach (GameObject ball in allBall)
            {
                ball.transform.localScale = new Vector3(ball.transform.localScale.x *(10f/3f), ball.transform.localScale.y * (10f / 3f), ball.transform.localScale.z * (10f / 3f));
            }
            currentStyle = 2;
        }
    }

    /*
     * Set style of model.
     * @param styleNumber the number that use for refer the style (1 is Ball and Stick. 2 is CPK Sphere).  
     */  
    public void SetStyle(int styleNumber)
    {
        this.currentStyle = styleNumber;
    }
}
