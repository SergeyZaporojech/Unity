using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;


    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (i * basketSpacingY);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

    }

    //public void creatBasket()
    //{
    //    for (int i = 0; i < numBaskets; i++)
    //    {
    //        GameObject tBasketGO = Instantiate(basketPrefab);
    //        Vector3 pos = Vector3.zero;
    //        pos.y = basketBottomY + (i * basketSpacingY);
    //        tBasketGO.transform.position = pos;
    //    }
    //}


    //public void ChangeBasketOrDestroyed()
    //{
    //    GameObject[] tBasketArray = GameObject.FindGameObjectsWithTag("Basket");
    //    foreach (GameObject tGo in tBasketArray)
    //    {
    //        Destroy(tGo);
    //        if (numBaskets>1)
    //        {
    //            --numBaskets;
    //            creatBasket();
    //        }
    //        else if (numBaskets==1)
    //        {
                
    //        }
    //    }

    //}

    public void AppleDesctroyed()
    {
        GameObject[] tAppletArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGo in tAppletArray)
        {
            Destroy(tGo);
        }

        int basketindex = basketList.Count - 1;
        // Получить ссылку на этот игровой объект Basket
        GameObject tBasketGO = basketList[basketindex];

        // Исключить корзину из списка и удалить сам игровой объект
        basketList.RemoveAt(basketindex);
        Destroy(tBasketGO);        

        // Если корзин не осталось  перезапустить игру
        if (basketList.Count == 0)
             {
               SceneManager.LoadScene("_Scene_0");
             }

    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
