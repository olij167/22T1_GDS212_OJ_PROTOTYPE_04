using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Name Generator")]
public class NameGenerator : ScriptableObject
{
    public List<string> firstNameList, lastNameList;

    public string GetRandomFirstName()
    {
       return firstNameList[Random.Range(0, firstNameList.Count)];
    }
    public string GetRandomFLastName()
    {
       return lastNameList[Random.Range(0, lastNameList.Count)];
    }


}


