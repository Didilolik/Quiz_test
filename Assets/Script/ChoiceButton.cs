using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChoiceButton : MonoBehaviour
{
    private string buttonName;

    void Start()
    {
        buttonName = transform.GetChild(0).GetComponent<Image>().sprite.name;
        GetComponent<Button>().onClick.AddListener(() => { CheckAnswer(buttonName); });
        if(GameManager.level == 1)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Sequence bounce = DOTween.Sequence();
            bounce.Append(transform.DOScale(0.3f, 0.15f))
                  .Append(transform.DOScale(0.5f, 0.15f))
                  .Append(transform.DOScale(0.7f, 0.15f))
                  .Append(transform.DOScale(1, 0.15f))
                  .Append(transform.DOScale(0.7f, 0.15f))
                  .Append(transform.DOScale(1, 0.15f));
        }
    }
    private void CheckAnswer(string choice)
    {

        if (choice == GameManager.answer&& GameManager.level!=3)
        {
            GetComponentInChildren<ObjImage>().Correct();
            StartCoroutine(NextLevel());
        }
        else if (choice == GameManager.answer && GameManager.level == 3)
        {
            GetComponentInChildren<ObjImage>().Correct();
            GameManager.restartButton.SetActive(true);
        }
        else
        {
            GetComponentInChildren<ObjImage>().Wrong();
        }
    }
    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1f);
        GameManager.cell += 3;
        GameManager.level++;
        GameManager.ClearLevel();
        GameManager.GenerateLevel();
    }

}
