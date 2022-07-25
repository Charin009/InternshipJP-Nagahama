using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ModelMenuManager create the button with name of het-atm that store in model_list.txt.
 */
public class ModelMenuManager : MonoBehaviour
{

    private TextAsset read_text;
    public GameObject modelBtnPrefab;
    public GameObject parent;
    private string[] modelArray;

    // Start is called before the first frame update
    void Start()
    {
        read_text = Resources.Load<TextAsset>("model_list");
        modelArray = read_text.text.Split('\n');

        foreach (string value in modelArray)
        {
            CreateModelButton(value);
        }
    }

    /*
     * Create button with given name.
     */
    private void CreateModelButton(string modelName)
    {
        GameObject tmpButton = Instantiate(modelBtnPrefab);
        tmpButton.transform.SetParent(parent.transform, false);
        tmpButton.GetComponent<ModelButtonScript>().SetName(modelName);
    }
}
