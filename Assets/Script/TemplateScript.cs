using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

[ExecuteInEditMode]
public class TemplateScript : MonoBehaviour
{
    //Inspector Variable
    [SerializeField] TMP_InputField nameField;
    [SerializeField] GameObject image;
    [SerializeField] TMP_InputField discField;
    [SerializeField] Button submitButton;


    //Here serialize and save data 
    public void SaveData()
    {
        TemplateClass templateClass = new TemplateClass();
        templateClass.nameText = nameField.text;
        templateClass.discText = discField.text;
        templateClass.imagePosition = image.transform.position;
        templateClass.imageRotation = image.transform.rotation;
        templateClass.imageScale = image.transform.localScale;

        string filePath = Application.persistentDataPath + "/templatedata.json";
        string dataString = JsonUtility.ToJson(templateClass);
        File.WriteAllText(filePath, dataString);
        Debug.Log("save data");
    }

    //Here deserialize and Load data 
    public void LoadData()
    {
        string filePath = Application.persistentDataPath + "/templatedata.json";
        if (!File.Exists(filePath))
            return;
        string fileContents = File.ReadAllText(filePath);
        TemplateClass templateClass = JsonUtility.FromJson<TemplateClass>(fileContents);

        nameField.text = templateClass.nameText;
        discField.text = templateClass.discText;
        image.transform.position = templateClass.imagePosition;
        image.transform.rotation = templateClass.imageRotation;
        image.transform.localScale = templateClass.imageScale;

        Debug.Log("Load data");
    }

    //Set Image size by slider in inspector
    public void SetImageSize(float _value)
    {
        image.transform.localScale = new Vector3(_value, _value, _value);
    }

    //Set Image rotation by slider in inspector
    public void SetImageRotation(float _value)
    {
        image.transform.rotation = Quaternion.Euler(0, 0, _value);
    }

    //Set Image x position by slider in inspector
    public void SetImageXPosition(float _value)
    {
        image.transform.localPosition = new Vector3(_value, image.transform.localPosition.y, image.transform.localPosition.z);
    }

    //Set Image y position by slider in inspector
    public void SetImageYPosition(float _value)
    {
        image.transform.localPosition = new Vector3(image.transform.localPosition.x, _value, image.transform.localPosition.z);
    }

    //Class for serialize variable
    public class TemplateClass
    {
        public string nameText;
        public string discText;
        public Vector3 imageScale = new Vector3();
        public Quaternion imageRotation = new Quaternion();
        public Vector3 imagePosition = new Vector3();
    }
}
