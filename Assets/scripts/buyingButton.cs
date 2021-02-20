using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buyingButton : MonoBehaviour
{
    [SerializeField]GameObject gameManager;
    Button button;
    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(onclick);
    }
    void onclick()
    {
        gameManager.GetComponent<GameManager>().buyingHouse(transform.parent.GetComponent<newHousesID>().id.no, int.Parse(transform.parent.name));
    }
}
