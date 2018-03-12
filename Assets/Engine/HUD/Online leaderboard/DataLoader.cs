using System.Collections;
using UnityEngine;

public class DataLoader : MonoBehaviour {

    public string[] items;
	// Use this for initialization
	IEnumerator Start () {
        WWW itemsData = new WWW("https://sweetboi.000webhostapp.com/ItemsData.php");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        print(itemsDataString);
        items = itemsDataString.Split(';');
        print(GetDataValue(items[0], "Name:"));
    }

    string GetDataValue(string data, string index) {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains(index)) {
            value = value.Remove(value.IndexOf("|"));
        }
        return value;
    }
}
