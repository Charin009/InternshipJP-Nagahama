using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*ModelButtonScript add function to HETATM's name button
 */
public class ModelButtonScript : MonoBehaviour
{
    /*Text of GameObject.
     */   
    public GameObject model_Text;

    /*Set Text component in this object.
     */   
    public void SetName(string modelName) {
        model_Text.GetComponent<Text>().text = modelName;
    }
}
