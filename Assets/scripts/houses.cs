using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houses : MonoBehaviour
{
    /// <summary>
    /// the unique id of house. this is the most important varabile in this file. u will find all houses with this integer.
    /// </summary>
    public int no;
    /// <summary>
    /// i will add this feature in future
    /// </summary>
    public string Name = "house";
    /// <summary>
    /// house type id of a house. 
    ///     1 = daire katı
    ///     2 = müstakil ev
    ///     3 = çiftlik evi
    ///     4 = köşk
    /// </summary>
    public int houseType;
    /// <summary>
    /// extra proparties of the house.
    /// proparties: 1= bahçe  2= teras  3= havuz
    /// </summary>
    public List<int> ekoz = new List<int>();
    /// <summary>
    /// room number of the house
    /// </summary>
    public int roomNumber;
    /// <summary>
    /// saloon/living room/hall/lounge number of the house
    /// </summary>
    public int saloonNumber;

    /// <summary>
    /// price of the house
    /// </summary>
    public int price=1000000;
    /// <summary>
    /// use this to check that if there is a not assigned varaible. if true, there is a not assigned varaible.
    /// </summary>

    /// <summary>
    /// is this house already boughted?
    /// returns true if it is.
    /// </summary>
    public bool isBoughted=false;
    bool isThereNotAssignedVariable()
    {
        if (price == 1000000 || saloonNumber == 0 || roomNumber == 0 || ekoz[0] == 0 || houseType == 0)
            return true;
        return false;
    }
}
