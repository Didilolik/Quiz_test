using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region служебные поля
    public static string answer;
    public static int cell = 3;
    public static int level = 1;
    #endregion

    #region списки
    [SerializeField] private List<Sprite> numbers, leters;
    private static List<List<Sprite>> lists = new List<List<Sprite>>();
    private static List<GameObject> usedObj = new List<GameObject>();
    #endregion

    #region ссылки
    private static Transform buttons;
    private static GameObject prefab;
    public static GameObject restartButton;
    #endregion

    private void Awake()
    {
        Caching();
        GenerateLevel();
    }
    private void Caching()
    {
        prefab = Resources.Load("Button") as GameObject;
        buttons = GameObject.Find("Canvas/Buttons").transform;
        restartButton = GameObject.Find("Canvas/WinWindow");
        restartButton.SetActive(false);
        lists.Add(numbers);
        lists.Add(leters);
    }
    public static void GenerateLevel()
    {
        usedObj = new List<GameObject>();
        List<int> usedIndexes = new List<int>();
        int index = Random.Range(0, lists.Count);
        int subIndex;
        GameObject curObj;

        for (int i = 0; i < cell; i++)
        {
            do
            {
                subIndex = Random.Range(0, lists[index].Count);
            } 
            while (usedIndexes.Contains(subIndex));

            usedIndexes.Add(subIndex);

            curObj = Instantiate(prefab, buttons);
            usedObj.Add(curObj);
            curObj.transform.GetChild(0).GetComponent<Image>().sprite = lists[index][subIndex]; // потому что GetComponentInChildren работает некорректно
        }

        answer = usedObj[Random.Range(0, usedObj.Count)].transform.GetChild(0).GetComponent<Image>().sprite.name;
        GameObject.Find("Canvas/Question").GetComponent<Text>().text = $"Find {answer}";
    }
    public static void ClearLevel()
    {
        foreach (GameObject item in usedObj)
        {
            Destroy(item);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        level = 1;
        cell = 3;
    }
}
