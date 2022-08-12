using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buyingButton : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    Button button;
    [SerializeField]Image transparent;
    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(onclick);

    }
    void onclick()
    {
        gameManager.buyHouse(
            transform.parent.GetComponent<newHousesID>().id,transparent
            );
    }
}
