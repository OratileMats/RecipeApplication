using System;
using System.Data.Common;

namespace IngredientsPrj
{
    class Recipe
    {
        private string[] ingredients;
        private double[] quantities;
        private string[] units;
        private string[] steps;

        public Recipe()
        {
            //Initialize arrays for ingredients, unit, steps and quantities
            ingredients = new string[0];
            quantities = new double[0];
            units = new string[0];
            steps = new string[0];
        }
        public void EnterDetails()
        {
            //Prompt user to enter number of ingredients
            Console.Write("Enter the number of ingredients: ");
            int ingNum = int.Parse(Console.ReadLine());

            // Initialize the arrays with the correct size
            ingredients = new string[ingNum];
            quantities = new double[ingNum];
            units = new string[ingNum];

            //Prompt the user to enter details for each ingredient
            for (int i = 0; i < ingNum; i++)
            {
                Console.WriteLine($"Enter the details for your ingredients #{i + 1};");
                Console.Write("Name: ");
                ingredients[i] = Console.ReadLine();

                Console.Write("Quantity: ");
                quantities[i] = double.Parse(Console.ReadLine());

                Console.Write("Unit of measurement: ");
                units[i] = Console.ReadLine();
            }
            //Promting the user to enter the number of steps
            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            //Intialize steps array with correct size
            steps = new string[numSteps];

            // Prompt user to enter details for each step
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step #{i + 1}; ");
                steps[i] = Console.ReadLine();
            }
        }
        public void DisplayRecipe()
        {
            //Displaying ingredients and their quantities
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"-{quantities[i]}{units[i]} of {ingredients[i]}");
            }
            //Displaying steps
            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"-{steps[i]};");
            }
        }
        public void ScaleRecipe(double factor)
        {
            // Multiply all quanttites by the scaling factor
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] *= factor;
            }
        }
        public void ResetQuantities()
        {
            //Reset all quantities to their original values
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] /= 2;
            }
        }
        public void ClearRecipe()
        {
            //Reset arrays to empty
            ingredients = new string[0];
            quantities = new double[0];
            units = new string[0];
            steps = new string[0];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            while (true)
            {
                Console.WriteLine("Enter 1 to enter recipe details");
                Console.WriteLine("Enter 2 to display recipe");
                Console.WriteLine("Enter 3 to scale recipe");
                Console.WriteLine("Enter 4 to reset quantities");
                Console.WriteLine("Enter 5 to clear recipe");
                Console.WriteLine("Enter 6 to exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        recipe.EnterDetails();
                        break;
                    case "2":
                        recipe.DisplayRecipe();
                        break;
                    case "3":
                        Console.Write("Enter scaling factor (0.5, or 2: ");
                        double factor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        break;
                    case "4":
                        recipe.ResetQuantities();
                        break;
                    case "5":
                        recipe.ClearRecipe();
                        break;
                    case "6":
                        Console.WriteLine("Existing program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid choice.");
                        break;
                }
            }
        }
    }
}

