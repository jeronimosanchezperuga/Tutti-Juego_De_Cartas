using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class GameManager_Tutti : MonoBehaviour
{
    public TextMeshPro txtLetter;
    public TextMeshPro txtCategory;
    public string[] categories;
    public Stack<string> categoriesStack;

    // Start is called before the first frame update
    void Start()
    {
        categoriesStack = new Stack<string>(RandomizeWithOrderByAndGuid(categories));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (categoriesStack.Count > 0)
            {
                txtCategory.text = categoriesStack.Pop();
                txtLetter.text = GetRandomCharA2Z().ToString();
            }
        }
    }

    public static string[] RandomizeWithOrderByAndGuid(string[] array) =>
    array.OrderBy(x => Guid.NewGuid()).ToArray();

    public char GetRandomCharA2Z()
    {
        return (char)UnityEngine.Random.Range('a', 'z');
    }
}
