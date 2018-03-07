using UnityEngine;
using System;
using System.Collections;

public class InsertionSort  {
    public void DateInsertionSort(ref DateTime[] dateArray, ref int[] correctArray, ref int[] incorrectArray)
    {
        DateTime dateTemp;
        int correctTemp;    
        int incorrectTemp;
        int j;

        for (int i = 1; i < dateArray.Length; i++)

        {

            dateTemp = dateArray[i];
            correctTemp = correctArray[i];
            incorrectTemp = incorrectArray[i];

            j = i - 1;



            while (j >= 0 && dateArray[j] > dateTemp)

            {

                dateArray[j + 1] = dateArray[j];
                correctArray[j + 1] = correctArray[j];
                incorrectArray[j + 1] = incorrectArray[j];

                j--;

            }

            dateArray[j + 1] = dateTemp;
            correctArray[j + 1] = correctTemp;
            incorrectArray[j + 1] = incorrectTemp;

        }
    }
}
