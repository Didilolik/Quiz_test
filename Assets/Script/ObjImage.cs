using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ObjImage : MonoBehaviour
{
    
    public void Wrong()
    {
        Sequence bounce = DOTween.Sequence();
        bounce.Append(transform.DOLocalMoveX(-2f, 0.1f))
              .Append(transform.DOLocalMoveX(2f, 0.1f));       
    }
    public void Correct()
    {
        GetComponent<ParticleSystem>().Play();
        Sequence bounce = DOTween.Sequence();
        bounce.Append(transform.DOScale(0.7f, 0.15f))
              .Append(transform.DOScale(0.5f, 0.15f))
              .Append(transform.DOScale(0.3f, 0.15f))
              .Append(transform.DOScale(0.5f, 0.15f))
              .Append(transform.DOScale(0.7f, 0.15f))
              .Append(transform.DOScale(1f, 0.15f));
    } 
}
