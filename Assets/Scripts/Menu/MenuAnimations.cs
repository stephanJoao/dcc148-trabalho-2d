using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MenuAnimations : MonoBehaviour
{

    [SerializeField] List<GameObject> menuLetters;
    [SerializeField] float moveDistance;
    [SerializeField] float moveDuration;
    [SerializeField] float lettersGap;

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
                letter.transform.DOShakeRotation(2f, 30f).SetLoops(-1);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
