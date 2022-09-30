using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject closeBook;
    public GameObject openBook;
    public Image[] emptySlots;
    public Sprite[] icons;
    public Sprite emptyIcon;

    public static int newIcon = 0;
    public static bool iconUpdate = false;
    private int max;

    public static int redMushrooms = 0;
    public static int purpleMushrooms = 0;


    // Start is called before the first frame update
    void Start()
    {
        closeMenu();
        max = emptySlots.Length;

        //一時的
        redMushrooms = 0;
        purpleMushrooms = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(iconUpdate == true)
        {
            for(int i = 0; i < max; i++)
            {
                if (emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = icons[newIcon];
                    emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = newIcon;  //スロットにアイテムNo.を渡す
                }
            }
            StartCoroutine(Reset());
        }
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

    public void SetItemImage(int number)
    {
        emptySlots[0].sprite = icons[number];
    }

    private IEnumerator Reset()
    {
        //画像アップデートし終わったら
        //1秒待って
        //フラグをfalseにして
        //maxを元の数に戻す
        yield return new WaitForSeconds(0.1f);
        iconUpdate = false;
        max = emptySlots.Length;
    }
}
