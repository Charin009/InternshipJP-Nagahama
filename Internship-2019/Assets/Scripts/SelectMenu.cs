using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*SelectMenu assign action to button in select menu.
 */
public class SelectMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject modelList;
    public GameObject m_object;
   
    public void openModelsList()
    {
        modelList.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void closeMenu()
    {
        mainMenu.SetActive(false);
    }
}
