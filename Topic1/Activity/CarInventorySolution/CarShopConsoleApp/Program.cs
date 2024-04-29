using CarClassLibrary;
using System;

namespace CarShopConsoleApp
{
    class Program
    {
        static Store CarStore = new Store();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the car store.\r\nFirst you must create some cars and put them into the store inventory. Then you may add cars to the cart. Finally, you may checkout, which will calculate your total bill.");
            int action = chooseAction();
            while (action != 0)
            {
                switch (action)
                {
                    case 1:
                        addCarToStore();
                        break;

                    case 2:
                        addCarToCart();
                        break;

                    case 3:
                        checkoutCart();
                        break;

                    default:
                        Console.WriteLine("Invalid option, please choose a valid action.");
                        break;
                }
                action = chooseAction();
            }
        }

        static void addCarToStore()
        {
            try
            {
                Console.WriteLine("You chose to add a new car to the store:");
                Console.Write("What is the car make? (e.g., Ford, GM, Toyota): ");
                string carMake = Console.ReadLine();

                Console.Write("What is the car model? (e.g., Corvette, Focus, Ranger): ");
                string carModel = Console.ReadLine();

                Console.Write("What is the car year? ");
                int carYear = int.Parse(Console.ReadLine());

                Console.Write("What color is the car? ");
                string carColor = Console.ReadLine();

                Console.Write("What is the car price? (Only numbers please): ");
                decimal carPrice = decimal.Parse(Console.ReadLine());

                Car newCar = new Car(carMake, carModel, carPrice, carYear, carColor);
                CarStore.CarList.Add(newCar);
                printStoreInventory(CarStore);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter the correct format for numbers.");
            }
        }

        static void addCarToCart()
        {
            try
            {
                printStoreInventory(CarStore);
                Console.Write("Which car would you like to add to the cart? (number): ");
                int choice = int.Parse(Console.ReadLine());
                if (choice >= 0 && choice < CarStore.CarList.Count)
                {
                    CarStore.ShoppingList.Add(CarStore.CarList[choice]);
                    printShoppingCart(CarStore);
                }
                else
                {
                    Console.WriteLine("Invalid car number selected.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }

        static void checkoutCart()
        {
            printShoppingCart(CarStore);
            Console.WriteLine("Your total cost is ${0}", CarStore.checkout());
        }

        static public int chooseAction()
        {
            try
            {
                Console.Write("Choose an action (0) quit, (1) add a car, (2) add item to cart, (3) checkout: ");
                return int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return -1; // Return an invalid option that prompts the user to try again.
            }
        }

        static public void printStoreInventory(Store carStore)
        {
            Console.WriteLine("These are the cars in the store inventory: ");
            for (int i = 0; i < carStore.CarList.Count; i++)
            {
                Console.WriteLine($"Car # = {i} {carStore.CarList[i].Display}");
            }
        }

        static public void printShoppingCart(Store carStore)
        {
            Console.WriteLine("These are the cars in your shopping cart:");
            for (int i = 0; i < carStore.ShoppingList.Count; i++)
            {
                Console.WriteLine($"Car # = {i} {carStore.ShoppingList[i].Display}");
            }
        }
    }
}
