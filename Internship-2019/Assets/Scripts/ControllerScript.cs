using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

/*ControllerScript assign action to button in Oculus Quest's controller.
 */
public class ControllerScript : MonoBehaviour
{
    public GameObject m_Canvas;
    public GameObject menuCanvas;
    public GameObject modelCanvas;
    public GameObject utilityCanvas;

    /*Check every frame that Button has clicked or not.
     * If A button has clicked the main menu will activate.
     * If B button has clicked the utility menu (menu to change style, rotate, scale, move models)
     */  
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if (m_Canvas.activeInHierarchy == true)
            {
                m_Canvas.SetActive(false);
            }else { 
                m_Canvas.SetActive(true);
                menuCanvas.SetActive(true);
                modelCanvas.SetActive(false);
                utilityCanvas.SetActive(false);
                
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            if (utilityCanvas.activeInHierarchy == true)
            {
                utilityCanvas.SetActive(false);
            }
            else
            {
                utilityCanvas.SetActive(true);
                m_Canvas.SetActive(false);

            }
        }
    }

 
}
