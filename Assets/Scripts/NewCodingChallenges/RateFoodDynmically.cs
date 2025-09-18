using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateFoodDynmically : MonoBehaviour
{
    [SerializeField] string[] listOfFoods;
    [SerializeField] string[] listOfCuisineMap;
    [SerializeField] int[] listOfRatings;

    // Map food -> (cuisine, rating)
    private Dictionary<string, (string cuisine, int rating)> foodMap;

    // Map cuisine -> SortedSet of (rating, food)
    private Dictionary<string, SortedSet<(int rating, string food)>> cuisineMap;

    [Button("Check The Ratings")]
    public void CheckFoodRating()
    {
        FoodRatings(listOfFoods, listOfCuisineMap, listOfRatings);
    }

    private class FoodComparer : IComparer<(int rating, string food)>
    {
        public int Compare((int rating, string food) a, (int rating, string food) b)
        {
            // Higher rating comes first
            if (a.rating != b.rating)
                return b.rating.CompareTo(a.rating);

            // If ratings equal -> lexicographically smaller food first
            return a.food.CompareTo(b.food);
        }
    }

    public void FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
        foodMap = new Dictionary<string, (string, int)>();
        cuisineMap = new Dictionary<string, SortedSet<(int rating, string food)>>();

        for (int i = 0; i < foods.Length; i++)
        {
            string food = foods[i];
            string cus = cuisines[i];
            int rat = ratings[i];

            foodMap[food] = (cus, rat);

            if (!cuisineMap.ContainsKey(cus))
            {
                cuisineMap[cus] = new SortedSet<(int rating, string food)>(new FoodComparer());
            }
            else
            {
                cuisineMap[cus].Add((rat, food));
            }

        }
    }

    [SerializeField] private string changeFoodRating = string.Empty;
    [SerializeField] private int rating = 0;

    [Button("Change The Rating Of The Food")]
    public void ChangeTheRatingOfTheFood()
    {
        ChangeRating(changeFoodRating, rating);
    }

    public void ChangeRating(string food, int newRating)
    {
        var (cuisine, oldRating) = foodMap[food];

        // Remove old entry
        cuisineMap[cuisine].Remove((oldRating, food));

        // Update food rating
        foodMap[food] = (cuisine, newRating);

        // Add new entry
        cuisineMap[cuisine].Add((newRating, food));
    }

    [SerializeField] string findHightedRatedCuisine = string.Empty;

    [Button("Get HighestRated Cuisine")]
    public void GetHighestRatedCuisine()
    {
        Debug.Log(HighestRated(findHightedRatedCuisine));
    }
    public string HighestRated(string cuisine)
    {
        // First element in SortedSet is the highest-rated
        return cuisineMap[cuisine].Min.food;
    }
}
