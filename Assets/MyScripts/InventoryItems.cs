using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItems : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject closeBook;
    public GameObject openBook;


    // Start is called before the first frame update
    void Start()
    {
        closeMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openMenu()
    {
        inventoryMenu.SetActive(true);
        openBook.SetActive(true);
        closeBook.SetActive(false);
        Time.timeScale = 0;  //ゲームの時間を止める
    }

    public void closeMenu()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closeBook.SetActive(true);
        Time.timeScale = 1;  //ゲームの時間を現実時間に合わせる
    }
}
