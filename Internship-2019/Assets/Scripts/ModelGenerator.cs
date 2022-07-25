using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

/*ModelGenerator generate model from data that contain in database.
 */
public class ModelGenerator : MonoBehaviour
{
    /*Empty Box that refer to center of model that generated from this ModelGenerator.
     */  
    private GameObject ParentPosition;

    /*UtilityMenu to change style ,scale ,rotation, position of model.
     */   
    private GameObject UtilityMenu;
    private GameObject Player;
    public GameObject modelName;

    /*Model of each atom and stick
     */  
    public GameObject C;
    public GameObject F;
    public GameObject Fe;
    public GameObject H;
    public GameObject N;
    public GameObject O;
    public GameObject P;
    public GameObject S;
    public GameObject Stick;

    /*XYZ Positon of Model's Parent (ModelSpawn)
     */  
    float parentX;
    float parentY;
    float parentZ;

    /*Radius of model base on atom type.
     */  
    float radius;

    /*Float number that use to increase or decrease scale of model.
     */  
    float multiplier;

    /*Create ReadFileFromWeb to read data from web database.
     */  
    protected readonly ReadFileFromWeb readerURL = new ReadFileFromWeb();

    /*Create RadiusConverter to get radius of each atom.
     */  
    private readonly RadiusConverter converter = new RadiusConverter();

    /*List of ModelInfo object that contain data of each atom (Name, Type, Position, Bond, Radius).
     */  
    protected List<ModelInfo> modelInfo = new List<ModelInfo>();

    /*GenerateHet-atom models base on the name of button.
     */  
    public void Generate()
    {
        GameObject[] target = GameObject.FindGameObjectsWithTag("Model");
        GameObject[] allStick = GameObject.FindGameObjectsWithTag("StickModel");

        //Set Parent to ModelSpawn
        ParentPosition = GameObject.Find("ModelSpawn");

        //Reset scale of ModelSpawn to 1
        ParentPosition.transform.localScale = new Vector3(1f, 1f, 1f);

        //Set UtilityMenu and player
        UtilityMenu = GameObject.Find("SecondMenu");
        Player = GameObject.Find("LocalAvatar");

        //Set positon of ModelSpawn place in front of player
        ParentPosition.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        ParentPosition.transform.rotation = Player.transform.rotation;
        ParentPosition.transform.position += Player.transform.forward * 2f;

        //Reset all slider in UtilityMenu.
        UtilityMenu.GetComponent<Rotation>().Reset();
        UtilityMenu.GetComponent<MoveModel>().Reset();
        UtilityMenu.GetComponent<ScaleMenu>().Reset();
        UtilityMenu.GetComponent<ChangeModel>().SetStyle(1);

        //Destroy the old model and stick in scence.
        foreach (GameObject model in target)
        {
            Destroy(model);
        }
        foreach(GameObject stick in allStick)
        {
            Destroy(stick);
        }

        //Read file by get name of button then get data from database.
        readerURL.readHetatom(modelName.GetComponent<Text>().text);
        modelInfo = readerURL.getProteinInfo();

        converter.ReadFile();
        multiplier = 0.2f;
        parentX = ParentPosition.transform.position.x;
        parentY = ParentPosition.transform.position.y+ GetPlusPosition(modelInfo, ParentPosition.transform.position.y, multiplier);
        parentZ = ParentPosition.transform.position.z;

        ParentPosition.transform.position = CenterPosition(modelInfo, parentX, parentY, parentZ, multiplier);

        //Create model from information in ModelInfo.
        foreach (ModelInfo info in modelInfo)
        {
            GameObject tmpModel;
            if (info.Type.Equals("ATOM"))
            {
                radius = 2f * multiplier * converter.ConvertToRadius(info.Bond, info.Radius) * 0.2f;
            }
            else if (info.Type.Equals("HETATM"))
            {
                radius = 2f * multiplier * converter.ConvertToRadius(info.Type, info.Element) * 0.5f;
            }

            switch (info.Element)
            {

                case "C":
                    tmpModel = Instantiate(C, new Vector3((info.X * multiplier) + parentX, (info.Y * multiplier) + parentY, (info.Z * multiplier) + parentZ), Quaternion.identity);
                    tmpModel.transform.localScale = new Vector3(radius, radius, radius);
                    tmpModel.name = info.Radius;
                    SetToParent(tmpModel);
                    break;
                case "F":
                    tmpModel = Instantiate(F, new Vector3((info.X * multiplier) + parentX, (info.Y * multiplier) + parentY, (info.Z * multiplier) + parentZ), Quaternion.identity);
                    tmpModel.transform.localScale = new Vector3(radius, radius, radius);
                    tmpModel.name = info.Radius;
                    SetToParent(tmpModel);
                    break;
                case "Fe":
                    tmpModel = Instantiate(Fe, new Vector3((info.X * multiplier) + parentX, (info.Y * multiplier) + parentY, (info.Z * multiplier) + parentZ), Quaternion.identity);
                    tmpModel.transform.localScale = new Vector3(radius, radius, radius);
                    tmpModel.name = info.Radius;
                    SetToParent(tmpModel);
                    break;
                case "H":
                    tmpModel = Instantiate(H, new Vector3((info.X * multiplier) + parentX, (info.Y * multiplier) + parentY, (info.Z * multiplier) + parentZ), Quaternion.identity);
                    tmpModel.transform.localScale = new Vector3(radius, radius, radius);
                    tmpModel.name = info.Radius;
                    SetToParent(tmpModel);
                    break;
                case "N":
                    tmpModel = Instantiate(N, new Vector3((info.X * multiplier) + parentX, (info.Y * multiplier) + parentY, (info.Z * multiplier) + parentZ), Quaternion.identity);
                    tmpModel.transform.localScale = new Vector3(radius, radius, radius);
                    tmpModel.name = info.Radius;
                    SetToParent(tmpModel);
                    break;
                case "O":
                    tmpModel = Instantiate(O, new Vector3((info.X * multiplier) + parentX, (info.Y * multiplier) + parentY, (info.Z * multiplier) + parentZ), Quaternion.identity);
                    tmpModel.transform.localScale = new Vector3(radius, radius, radius);
                    tmpModel.name = info.Radius;
                    SetToParent(tmpModel);
                    break;
                case "P":
                    tmpModel = Instantiate(P, new Vector3((info.X * multiplier) + parentX, (info.Y * multiplier) + parentY, (info.Z * multiplier) + parentZ), Quaternion.identity);
                    tmpModel.transform.localScale = new Vector3(radius, radius, radius);
                    tmpModel.name = info.Radius;
                    SetToParent(tmpModel);
                    break;
                case "S":
                    tmpModel = Instantiate(S, new Vector3((info.X * multiplier) + parentX, (info.Y * multiplier) + parentY, (info.Z * multiplier) + parentZ), Quaternion.identity);
                    tmpModel.transform.localScale = new Vector3(radius, radius, radius);
                    tmpModel.name = info.Radius;
                    SetToParent(tmpModel);
                    break;
                default:
                    break;
            }
        }

        //Wait the model create stick before change to ball and stick model.
        StartCoroutine(Wait());

        //Set position of ModelSpawn to bt in front of player(or user).
        ParentPosition.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        ParentPosition.transform.position += Player.transform.forward * 2f;


    }

    /*Increase size of atom model
     * @param size the scale that you want to multiply with old scale  
     */  
    private void IncreaseBallSize(float size)
    {
        GameObject[] allBall = GameObject.FindGameObjectsWithTag("Model");
        foreach (GameObject ball in allBall)
        {
            ball.transform.localScale = new Vector3(ball.transform.localScale.x * size, ball.transform.localScale.y * size, ball.transform.localScale.z * size);
        }
    }

    /*Disable the OnColiisionEnter() function in all atom model.
     */  
    private void DisableAllBallOnEnter()
    {
        GameObject[] allBall = GameObject.FindGameObjectsWithTag("Model");
        foreach (GameObject ball in allBall)
        {
            ball.GetComponent<ModelTrigger>().SetIsTriggered(true);
        }
    }

    /*Get the position that will made the model always place above the floor.
     */  
    private float GetPlusPosition(List<ModelInfo> modelInfo,float positionY,float multiplier)
    {
        float minimum = modelInfo.ToArray()[0].Y;
        float plusPosition = 0;
        foreach(ModelInfo info in modelInfo)
        {
            if(info.Y < minimum)
            {
                minimum = info.Y;
            }
        }
   
        minimum = (minimum * multiplier) + positionY;
        if (minimum - positionY >= 1) return 0;
        while(minimum < 0.5)
        {
            minimum ++;
            plusPosition++;
        }

        return plusPosition;

    }

    /*Set item to be a child of ModelSpawn
     */  
    private void SetToParent(GameObject item)
    {
        item.transform.SetParent(ParentPosition.transform);
    }

    /*Find the center of final mode.
     */  
    private Vector3 CenterPosition(List<ModelInfo> modelIfos,float oldX, float oldY ,float oldZ, float multiplier)
    {
        float maximumY = modelInfo.ToArray()[0].Y;
        float minimumY = modelInfo.ToArray()[0].Y;

        float maximumX = modelInfo.ToArray()[0].X;
        float minimumX = modelInfo.ToArray()[0].X;

        float maximumZ = modelInfo.ToArray()[0].Z;
        float minimumZ = modelInfo.ToArray()[0].Z;
        foreach (ModelInfo info in modelInfo)
        {
            if (info.Y < minimumY)
            {
                minimumY = info.Y;
            }else if (info.Y > maximumY)
            {
                maximumY = info.Y;
            }

            if (info.X < minimumX)
            {
                minimumX = info.X;
            }
            else if (info.X > maximumX)
            {
                maximumX = info.X;
            }

            if (info.Z < minimumZ)
            {
                minimumZ = info.Z;
            }
            else if (info.Z > maximumZ)
            {
                maximumZ = info.Z;
            }
        }
        ParentPosition.GetComponent<BoxCollider>().size = new Vector3((maximumX-minimumX)*multiplier,(maximumY-minimumY)*multiplier,(maximumZ-minimumZ)*multiplier);
        return new Vector3((((maximumX + minimumX)/2) * multiplier) + oldX, (((maximumY + minimumY)/2) * multiplier) + oldY, (((maximumZ + minimumZ)/2) * multiplier) + oldZ);

    }

    /*Wait for 2 second before disable OnCollisionEnter() in atom then increase atom's scale.
     */   
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        DisableAllBallOnEnter();
        IncreaseBallSize(0.6f);

    }



}
