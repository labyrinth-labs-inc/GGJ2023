using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindOne : MonoBehaviour
{
    int[] array = {1,2,2,3,3};

    //Main
    void Start()
    {
        if(ArrayFindOne(array) == 30001)Debug.Log("The List doesnt have the one!");
        else Debug.Log("the one is: " + ArrayFindOne(array).ToString());
    }

    int ArrayFindOne(int[] newArray)
    {
        int theOne;
        foreach (int num in array)
        {
            theOne = num;
            int similars = 0;
            foreach (int item in array)
            {
                if(theOne == item)
                {
                    similars += 1;
                }
            }
            if(similars == 1)return theOne;
        }
        return 30001;
    }

}
