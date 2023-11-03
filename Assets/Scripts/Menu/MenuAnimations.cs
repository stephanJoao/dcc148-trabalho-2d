using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MenuAnimations : MonoBehaviour
{

    [SerializeField] List<GameObject> menuLetters;

    //Fazer animação dos nomes
    [SerializeField] List<GameObject> nameLetters;

    [SerializeField] float moveDistance;
    [SerializeField] float moveDuration;
    [SerializeField] float lettersGap;

    [SerializeField] Vector3 punchPosition;
    [SerializeField] Ease ease;

    // Start is called before the first frame update
    void Start()
    {
        //menuLetters = new List<GameObject>();
        StartCoroutine(LetterAnimation());

    }

    IEnumerator LetterAnimation()
    {
        foreach (GameObject letter in menuLetters)
        {
            if (letter != null)
            {
                letter.transform.DOMoveX(moveDistance, moveDuration).SetEase(ease);
                moveDistance += lettersGap;
                yield return new WaitForSeconds(moveDuration / 3);
                letter.transform.DOShakeScale(1f, 0.08f).SetLoops(-1);
                letter.transform.DOShakeRotation(2f, 10).SetLoops(-1);
                letter.transform.DOMoveY(letter.transform.position.y + 1, 3f).SetLoops(-1);

            }
        }
    }

}
