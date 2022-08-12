using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    int b = 1;
    [SerializeField] Player player;
    /// <summary>
    /// the UI of homes for sale that will appear in this new year
    /// </summary>
    [SerializeField] GameObject[] newHousesUI;
    /// <summary>
    /// the proparties of every house for sale that appeared in this new year
    /// </summary>
    [SerializeField] List<houses> newHouses = new List<houses>();
    /// <summary>
    /// the proparties of every house that bought
    /// </summary>
    [SerializeField] List<houses> boughtHouses = new List<houses>();
    /// <summary>
    /// the number of homes for sale that will appear in this new year
    /// </summary>
    int ces;
    int no;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ces = decideCes();
            assignNewHouses(ces);
            showNewHouses(ces);
            player.money += 40000;
        }
    }
   public void buyHouse (houses boughtHouse,Image transparent)
    {
        print(boughtHouse.price);
        print(player.money);
        if (!boughtHouse.isBoughted)
        {
            if (player.money >= boughtHouse.price)
            {
                player.money -= boughtHouse.price;
                boughtHouses.Add(boughtHouse);
                boughtHouse.isBoughted = true;
                Vector3 _p = transparent.transform.position;
                _p = new Vector3(_p.x, _p.y, 5);
                ChangeTransparent(transparent,0.3f,1f);

                //------------------------------------------------
                //increaseColor(newHouses[uiNo].transform.Find("transparent").gameObject, 0f, 110);
                print("boughted");
            }
            else
            {
                print("u have no enough money dude");
            }
        }
        else
        {
            print("u already bought this house");
        }
    }
    void increaseColor(GameObject theObject,float from, float untill, float speed=3f)
    {
        Image i = theObject.gameObject.GetComponent<Image>();
        Color32 i2 = i.color;
        i2[3] =(byte) from;
        float i3 = 0;
        while (i3 < untill)
        {
            i3 += speed * Time.deltaTime;
            print(i3);
            i2[3] = (byte) i3 ;
            i.color = i2;
        }

    }
    /// <summary>
    /// finds house according to no(id).
    /// </summary>
    /// <param name="no">id of house</param>
    /// <param name="type">is house bought or new or old?
    /// 1= new
    /// 2= bought
    /// 3= old (will be added)
    /// enter this value to faster find
    /// </param>
    /// <returns></returns>
    houses searchHouse(int no, int type = 0)
    {
        if(type == 0)//unknown
        {
            foreach (houses template in newHouses)
            {
                if (no == template.no)
                    return template;
            }
            foreach (houses template in boughtHouses)
            {
                if (no == template.no)
                    return template;
            }
        }
        if (type == 1)//new
        {
            foreach (houses template in newHouses)
            {
                if (no == template.no)
                {
                    return template;
                }
            }
        }
        if (type == 2)//bought
        {
            foreach (houses template in boughtHouses)
            {
                if (no == template.no)
                    return template;
            }
        }
        houses garbageHouse = new houses();
        garbageHouse.Name = "garbage";
        return garbageHouse;
    }
    int decideToPrice(houses house)
    {
        int price = 0;
        if (house.houseType == 1)
        {
            /*1= bahçe  2= teras  3= havuz
            */
            foreach (int i in house.ekoz)
            {
                if (i == 1)
                    price += 10000;
                if (i == 3)
                    price += 30000;
                if (i == 2)
                    price += 100000;
            }
            if (house.roomNumber != 3)
            {
                price += Random.Range(80000, 450001);
                if (house.roomNumber == 7)
                    price += 100000;
                else if (house.roomNumber == 6)
                    price += 70000;
                else if (house.roomNumber == 5)
                    price += 50000;
                else if (house.roomNumber == 4)
                    price += 10000;
            }
            else
            {
                price += Random.Range(50000, 250001);

            }
        }
        else if (house.houseType == 2)
        {
            /*1= bahçe  2= teras  3= havuz
            */
            foreach (int i in house.ekoz)
            {
                if (i == 1)
                    price += 100000;
                if (i == 3)
                    price += 50000;
                if (i == 2)
                    price += 100000;
            }
            if (house.roomNumber == 2)
                price += 50000;
            else if (house.roomNumber == 3)
                price += Random.Range(50000, 200001);
            else if (house.roomNumber == 4)
                price += Random.Range(50000, 750001);
            else if (house.roomNumber == 5)
            {
                price += Random.Range(50000, 750001);
                price += 300000;
            }
            else if (house.roomNumber == 6)
            {
                price += Random.Range(50000, 750001);
                price += 600000;
            }
        }
        else if (house.houseType == 4)
        {
            /*1= bahçe  2= teras  3= havuz
            */
            foreach (int i in house.ekoz)
            {
                if (i == 1)
                    price += 300000;
                if (i == 3)
                    price += 500000;
                if (i == 2)
                    price += 400000;
            }
            if (house.roomNumber == 3)
                price += Random.Range(500000, 1500001);
            else if (house.roomNumber == 4)
                price += Random.Range(500000, 4500001);
            else if (house.roomNumber == 5)
            {
                price += Random.Range(500000, 4500001);
                price += 300000;
            }
            else if (house.roomNumber == 6)
            {
                price += Random.Range(500000, 4500001);
                price += 500000;
            }
            else if (house.roomNumber == 7)
            {
                price += Random.Range(50000, 750001);
                price += 800000;
            }
        }
        else if (house.houseType == 3)
        {
            /*1= bahçe  2= teras  3= havuz
            */
            foreach (int i in house.ekoz)
            {
                if (i == 1)
                    price += 100000;
                if (i == 3)
                    price += 400000;
                if (i == 2)
                    price += 300000;
            }
            if (house.roomNumber == 2)
                price += Random.Range(200000, 300001);
            else if (house.roomNumber == 3)
                price += Random.Range(200000, 600001);
            else if (house.roomNumber == 4)
                price += Random.Range(200000, 1300001);
            else if (house.roomNumber == 5)
            {
                price += Random.Range(200000, 1300001);
                price += 100000;
            }
            else if (house.roomNumber == 6)
            {
                price += Random.Range(200000, 1300001);
                price += 400000;
            }
        }
        if(price<100000)
            price -= price % 1000;
        else
            price -= price % 10000;
        return price;
    }
    string putDot(int price)
    {
        string i = "";
        int i2 = ("" + price).Length % 3;
        if (i2 != 0)
        {
            for (int i3 = 0; i3 < i2; i3++)
            {
                i += ("" + price)[i3];
            }
            i += ".";
        }
        int i4 = 1;
        for (; i2 < ("" + price).Length; i2++, i4++)
        {
            i += ("" +price)[i2];
            if (i4 == 3 && i2 != ("" + price).Length-1)
            {
                i += ".";
                i4 = 0;
            }
        }
        return i;
    }
    void showNewHouses(int ces)
    {
        for (int i = 0; i < ces; i++)
        {
            newHousesUI[i].SetActive(true);
            newHousesUI[i].GetComponent<newHousesID>().id = newHouses[i];
            newHousesUI[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "no: " + newHouses[i].no;
            newHousesUI[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = translateHouseType(newHouses[i].houseType);
            newHousesUI[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "fiyat:\n₺" + putDot(newHouses[i].price);
            if (newHouses[i].ekoz.Count != 0)
            {
                newHousesUI[i].transform.GetChild(4).gameObject.SetActive(true);
                newHousesUI[i].transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "ek özellikler:";
                foreach (int i2 in newHouses[i].ekoz)
                {
                    TextMeshProUGUI i5 = newHousesUI[i].transform.GetChild(4).GetComponent<TextMeshProUGUI>();
                    i5.text = i5.text + "\n" + translateEos(i2) + " var.";
                }
            }
            else
            {
                newHousesUI[i].transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "ek özellikler:\nyok";
            }
            newHousesUI[i].transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = "" + newHouses[i].roomNumber + " oda " + newHouses[i].saloonNumber + " salon";
        }
        if (ces != 10)
        {
            for (int i = 9; i > ces - 1; i--)
            {
                newHousesUI[i].SetActive(false);
            }
        }
    }
    void assignNewHouses(int ces)
    {
        newHouses.Clear();
        for (int i = 0; i < ces; i++)
        {
            houses template = new houses();
            template.no = ++no;
            template.houseType = decideToHouseType();
            template.ekoz = decideEos();
            (template.roomNumber, template.saloonNumber) = decideRoomNumber(template.houseType);
           template.price= decideToPrice(template);
            newHouses.Add(template);
        }
    }
    /// <summary>
    /// decides to house number which will appear in this new year
    /// </summary>
    int decideCes()
    {
        return Random.Range(1,11);
    }
    string translateHouseType(int houseType)
    {
        if (houseType == 1)
            return "daire katı";
        else if (houseType == 2)
            return "müstakil ev";
        else if (houseType == 3)
            return "çiftlik evi";
        else if (houseType == 4)
            return "köşk";
        return "error";
    }
    /// <summary>
    /// ev tipleri ve numaraları:
    ///     1 = daire katı
    ///     2 = müstakil ev
    ///     3 = çiftlik evi
    ///    4 = köşk
    /// </summary>
    /// <returns>1 or 2 or 3 or 4 (if return 0 prints "error")</returns>
    int decideToHouseType()
    {
        int Range = Random.Range(1,101);
        if (50 < Range && Range <= 100)
        {
            return 1;//daire katı
        }
        else if (25 < Range && Range <= 50)
        {
            return 2;//müstakil ev
        }
        else if (5 < Range && Range <= 25)
        {
            return 3;//çiftlik evi(konak)
        }
        else if (Range <= 5)
        {
            return 4;//köşk
        }
        print("error");
        return 0;
    }
    string translateEos(int eos)
    {
        if (eos == 1)
            return "bahçe";
        else if (eos == 2)
            return "teras";
        else if (eos == 3)
            return "havuz";
        return "error";
    }
    /// <summary>
    /// decides extra proparties number a house and return proparties id's between 0 and 3.
    /// </summary>
    /// <returns>
    /// proparties: 1= bahçe  2= teras  3= havuz
    /// </returns>
    List<int> decideEos()
    {
        List<int> decidedEos = new List<int>();
        int Range = Random.Range(0, 101);
        int eos=0; //extra proparties number of a house
        if (100 >= Range && Range > 60)
            eos = 0;
        else if (60 >= Range && Range > 30)
            eos = 1;
        else if (30 >= Range && Range > 10)
            eos = 2;
        else if (Range <= 10)
            eos = 3;
        if (eos != 0)
        {
            List<int> eo = new List<int>();
            int first = 1;
            int second = 2;
            int third = 3;
            eo.Add(first);
            eo.Add(second);
            eo.Add(third);
            for (int i = 0; i < eos; i++)
            {
                int i2 = Random.Range(0, eo.Count);
                decidedEos.Add(eo[i2]);
                eo.RemoveAt(i2);
            }
        }
            return decidedEos;
    }

    (int, int) decideRoomNumber(int houseType)
    {
        int roomNumber = 0;
        int saloonNumber =1;//living room/hall/lounge number
        int Range = Random.Range(0,100);

        if (houseType == 1)
        {
            if (Range < 5)
                roomNumber = 7;
            else if (5 <= Range && Range < 15)
                roomNumber = 6;
            else if (15 <= Range && Range < 40)
                roomNumber = 5;
            else if (40 <= Range && Range < 65)
                roomNumber = 3;
            else if (65 <= Range && Range < 100)
                roomNumber = 4;
        }
        else if (houseType == 2)
        {
            if (Range < 5)
                roomNumber = 6;
            else if (5 <= Range && Range < 15)
                roomNumber = 2;
            else if (15 <= Range && Range < 40)
                roomNumber = 3;
            else if (40 <= Range && Range < 65)
                roomNumber = 5;
            else if (65 <= Range && Range < 100)
                roomNumber = 4;
        }
        else if (houseType == 3)
        {
            if (Range < 5)
                roomNumber = 2;
            else if (5 <= Range && Range < 15)
                roomNumber = 3;
            else if (15 <= Range && Range < 40)
                roomNumber = 4;
            else if (40 <= Range && Range < 65)
                roomNumber = 5;
            else if (65 <= Range && Range < 100)
                roomNumber = 6;
            int Range2 = Random.Range(0, 4);
            if (Range2 == 3)
                saloonNumber = 2;
        }
        else if (houseType == 4)
        {
            if (Range < 5)
                roomNumber = 3;
            else if (5 <= Range && Range < 15)
                roomNumber = 4;
            else if (15 <= Range && Range < 40)
                roomNumber = 5;
            else if (40 <= Range && Range < 65)
                roomNumber = 7;
            else if (65 <= Range && Range < 100)
                roomNumber = 6;
            saloonNumber = 2;
        }
        return (roomNumber, saloonNumber);
    }
    void ChangeTransparent(Image image, float fadelimit=0.3f,float fadetime=0.5f, int fadetype=2)
    {
        if (fadetype == 2)
            StartCoroutine(FadeIn(image, fadetime, fadelimit));
        else
            StartCoroutine(FadeOut(image, fadetime, fadelimit));
    }
    private YieldInstruction fadeInstruction = new YieldInstruction();
    IEnumerator FadeOut(Image image, float fadeTime, float fadelimit)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < fadeTime)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = fadelimit - Mathf.Clamp01(elapsedTime / fadeTime);
            image.color = c;
        }
    }
    IEnumerator FadeIn(Image image, float fadeTime, float fadelimit)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < fadeTime)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp(elapsedTime / fadeTime,0, fadelimit);
            image.color = c;
        }
    }
}
