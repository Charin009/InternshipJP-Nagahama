using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text.RegularExpressions;

/*RadiusConverter recieve type and element or atoms then return radius of atoms.
 */
public class RadiusConverter : MonoBehaviour
{
    private TextAsset read_text;
    public ArrayList raidusInfoList = new ArrayList();

    /*Check type and element in vdw.txt then return Radius of atom.
     */
    public  float ConvertToRadius(string type, string element)
    {
        string typeChecker = type;
        if(element.Contains("\"")) element = element.Replace("\"", "");
        if (type.Substring(0, 1).Equals("D")) typeChecker = type.Substring(1);
        if (type.Equals("HETATM")) typeChecker = "ZZZ";

        foreach (RadiusInfo info in raidusInfoList)
        {
            if (typeChecker.Equals(info.Type) && element.Equals(info.ElementRadius))
            {
                //Debug.Log("");
                return info.Raidus;
            }

        }

        return 0;
    }

    /*Read radius data from vdw.txt
     */  
    public void ReadFile()
    {
        read_text = Resources.Load<TextAsset>("vdw");
        string[] line = read_text.text.Split('\n');
        foreach (string read_line in line)
        {
            if (!read_line.Contains("#"))
            {
                string[] data = read_line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    raidusInfoList.Add(new RadiusInfo(data[0],data[1],float.Parse(data[2])));
            }
        }
    }

    public ArrayList GetRadiusInfo()
    {
        return raidusInfoList;
    }
    
}
