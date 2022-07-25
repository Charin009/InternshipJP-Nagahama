using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using UnityEngine;

/*Get het-atom data from web database or hetpdbnavi.nagahama-i-bio.ac.jp 
 */
public class ReadFileFromWeb : MonoBehaviour
{
    private string apiUrl = "http://hetpdbnavi.nagahama-i-bio.ac.jp/gethet/";
    private TextAsset read_text;
    public List<ModelInfo> modelInfoList = new List<ModelInfo>();

    /*Send request to server then steam data in to array of string.
     */  
    string[] DownloadInformation(string name)
    {
        string[] lines = new string[] { };

        try
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl + name);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                lines = reader.ReadToEnd().Split('\n');
                reader.Close();
            }
            response.Close();
        }
        catch (WebException e)
        {
            Debug.Log(e.Message);
        }

        return lines;

    }



    public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }

    /*Send request to server then create ModelInfo with data that get from server.
     */  
    public void readHetatom(string name)
    {
        string[] line = DownloadInformation(name);
        foreach (string read_line in line)
        {
            if (read_line.Contains("ATOM") || read_line.Contains("HETATM"))
            {
                string[] data = read_line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (Regex.IsMatch(data[1], @"\d"))
                {
                    modelInfoList.Add(new ModelInfo(data[0], data[2], data[3], data[5], float.Parse(data[10]), float.Parse(data[12]), float.Parse(data[11])));
                }
            }
        }
    }

    /*Return list of ModelInfo
     */  
    public List<ModelInfo> getProteinInfo()
    {
        return modelInfoList;
    }

}
