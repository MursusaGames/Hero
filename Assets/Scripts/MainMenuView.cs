using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Image shopBtn;
    [SerializeField] private Image swordBtn;
    [SerializeField] private Image worldBtn;
    [SerializeField] private Image talantBtn;
    [SerializeField] private Image shopImage;
    [SerializeField] private Image swordImage;
    [SerializeField] private Image worldImage;
    [SerializeField] private Image talantImage;
    [SerializeField] private TextMeshProUGUI shopText;
    [SerializeField] private TextMeshProUGUI equipmentText;
    [SerializeField] private TextMeshProUGUI worldText;
    [SerializeField] private TextMeshProUGUI talantText;
    [SerializeField] private GameObject equipmentMenu;
    [SerializeField] private GameObject worldMenu;
    [SerializeField] private GameObject talantMenu;
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private RectTransform worldRectTransform;
    [SerializeField] private GameObject buyEnergyView;
    [SerializeField] private GameObject dailySetView;
    private Vector3 previousPos;

    private void Start()
    {
        ShowWorld();
    }
    public void ShowEquipment()
    {
        ChoiceMenu(equipmentMenu);
    }
    public void ShowShop()
    {
        ChoiceMenu(shopMenu);
    }
    public void ShowWorld()
    {
        ChoiceMenu(worldMenu);
    }
    public void ShowTalant()
    {
        ChoiceMenu(talantMenu);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ShowBuyEnergyView()
    {
        buyEnergyView.SetActive(true);
    }
    public void HideBuyEnergyView()
    {
        buyEnergyView.SetActive(false);
    }
    public void ShowDaylySetView()
    {
        dailySetView.SetActive(true);
    }
    public void HideDaylySetView()
    {
        dailySetView.SetActive(false);
    }

    public void SetActivBtn(int id)
    {

        Image[] btns = { shopBtn, swordBtn, worldBtn, talantBtn };
        TextMeshProUGUI[] texts = { shopText, equipmentText, worldText, talantText };
        Image[] images = { shopImage, swordImage, worldImage, talantImage };        
        for (int i = 0; i <btns.Length; i++)
        {
            if(id == i)
            {
                btns[i].gameObject.GetComponent<Button>().interactable = false;
                btns[i].gameObject.GetComponent<LayoutElement>().minWidth = 300;
                var alfa = btns[i].color;
                alfa.a = 0;
                btns[i].color = alfa;
                texts[i].gameObject.Show();
                images[i].gameObject.transform.localScale *= 1.5f;
                images[i].gameObject.GetComponent<RectTransform>().localPosition = worldRectTransform.localPosition;
            }
            else
            {
                btns[i].gameObject.GetComponent<Button>().interactable = true;
                previousPos = btns[i].gameObject.transform.position;
                btns[i].gameObject.GetComponent<LayoutElement>().minWidth = 0;
                var alfa = btns[i].color;
                alfa.a = 1;
                btns[i].color = alfa;
                texts[i].gameObject.Hide();
                images[i].gameObject.transform.localScale = Vector3.one;
                var pos = images[i].gameObject.transform.position;
                pos = previousPos;
                images[i].gameObject.transform.position = pos;
            }
        
        }
    }

    private void ChoiceMenu(GameObject menu)
    {
        GameObject[] menus =  { equipmentMenu, worldMenu, talantMenu, shopMenu };
        foreach(var go in menus)
        {
            if (go == menu) go.Show();
            else go.Hide();
        }
    }
    
}
