using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform[] pages;
    [SerializeField] private int CurrentPage = 0;
    [SerializeField] private Vector2 WhereShouldGoLeft;
    [SerializeField] private Vector2 WhereShouldGoRight;
    [SerializeField] private float Duration;
    [SerializeField] private float Delay;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GoLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GoRight();
        }
    }
    void GoLeft()
    {
        if (CurrentPage < pages.Length-1)
        {
            //current page goes left
            pages[CurrentPage].DOAnchorPos(WhereShouldGoLeft, Duration).SetEase(Ease.InBack);
            //next page goes to middle of screen
            pages[CurrentPage+1].DOAnchorPos(Vector2.zero, Duration).SetDelay(Delay).SetEase(Ease.OutBack);
            CurrentPage++;
        }
    }
    void GoRight()
    {
        if (CurrentPage > 0)
        {
            //current page goes right
            pages[CurrentPage].DOAnchorPos(WhereShouldGoRight, Duration).SetEase(Ease.InBack);
            //previous page goes to middle of screen
            pages[CurrentPage - 1].DOAnchorPos(Vector2.zero, Duration).SetDelay(Delay).SetEase(Ease.OutBack);
            CurrentPage--;
        }
    }
}
