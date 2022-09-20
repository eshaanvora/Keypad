using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination
{
    private List<int> combination;
    private List<int> defaultCombination = new List<int> { 1, 2, 3, 4 };

    public Combination()
    {
        combination = CombinationLoader.Load(defaultCombination);
    }

    public int GetCombinationDigit(int digitNumber)
    {
        if (digitNumber < 0)
            return 0;
        if (digitNumber >= combination.Count)
            return 0;

        return combination[digitNumber];
    }

    public int GetCombinationLength()
    {
        return combination.Count;
    }
}
