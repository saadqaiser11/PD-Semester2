using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Data;
enum Role
{
    Admin,
    User,
    Undefined
}
class User
{
    public string Name;
    public string Password;
    public Role UserRole;

    public User(string name, string password, Role role)
    {
        Name = name;
        Password = password;
        UserRole = role;
    }
}

namespace Application
{

    internal class Program
    {
        static User[] users = new User[100];
        static int usersCount = 0;
        static int userArrSize = 100;
        static void Main(string[] args)
        {

            clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            const int userArrSize = 10;
            string[] users = new string[userArrSize];
            string[] passwords = new string[userArrSize];
            string[] roles = new string[userArrSize];
            string[] products = new string[userArrSize];
            string[] review = new string[userArrSize];
            string[] boughtproducts = new string[userArrSize];
            string[] originaldata = new string[userArrSize];
            string[] newdata = new string[userArrSize];
            string[] cartproducts = new string[userArrSize];

            int[] buyprice = new int[userArrSize];
            int[] quantities = new int[userArrSize];
            int[] cartquantities = new int[userArrSize];
            int[] cartprice = new int[userArrSize];
            int[] price = new int[userArrSize];
            int[] boughtquantity = new int[userArrSize];
            int[] credit = new int[userArrSize];
            int totalbought = 0;
            int countreview = 0;
            int usersCount = 0;
            int loginOption = 0;
            int usernumber = 0;
            int addedproducts = 0;
            int totalusers = 0;
            int discount = 0;
            int addedcartproducts = 0;
            int countcredits = 0;
            LoadRecords(ref usernumber, products, quantities, ref addedproducts, totalusers, users, roles, ref usersCount, price, discount, review, ref countreview, buyprice, loginOption, passwords, userArrSize, cartproducts, cartquantities, cartprice, ref addedcartproducts, ref totalbought, boughtquantity, boughtproducts);



            while (true)
            {
                topHeader();
                loginOption = loginMenu();
                if (loginOption == 1)
                {
                    clear();
                    string name;
                    string password;
                    Role role;

                    printsigninonly();
                    Console.WriteLine("\t\t\t\t\tPlease Sign in");
                    Console.Write("\t\t\t\t\tEnter your Name: ");
                    name = Console.ReadLine();
                    Console.Write("\t\t\t\t\tEnter your Password: ");
                    password = Console.ReadLine();
                    role = signIn(name, password);

                    if (role == Role.Admin)
                    {
                        clearScreen();
                        int adminOption = 0;
                        while (true)
                        {
                            printadmin();
                            adminOption = adminMenu(ref usernumber, products, quantities, ref addedproducts, totalusers, users, roles, ref usersCount, price, discount, review, ref countreview, buyprice, loginOption, passwords, userArrSize, cartproducts, cartquantities, cartprice, ref addedcartproducts, ref totalbought, boughtquantity, boughtproducts);
                            if (adminOption == 1)
                            {
                                clear();
                                printadmin();
                                line("Option 1");
                                addproducts(ref usernumber, products, quantities, ref addedproducts, price, review, ref countreview);
                            }
                            if (adminOption == 2)
                            {
                                clear();
                                printadmin();
                                line("Option 2");
                                removeproducts(ref usernumber, products, quantities, ref addedproducts, price, review, ref countreview);
                            }
                            if (adminOption == 3)
                            {
                                clear();
                                printadmin();
                                line("Option 3");
                                alluser(totalusers, users, roles, ref usersCount, review, ref countreview);
                            }
                            if (adminOption == 10)
                            {
                                clear();
                                break;
                            }
                            Console.WriteLine("Press any key to return");
                            Console.ReadKey();
                            clear();
                        }
                    }
                    if (role == Role.User)
                    {
                        clearScreen();
                        int userOption = 0;
                        while (true)
                        {
                            printuser();
                            userOption = userMenu(ref usernumber, products, quantities, ref addedproducts, totalusers, users, roles, ref usersCount, price, discount, review, ref countreview, buyprice, loginOption, passwords, userArrSize, cartproducts, cartquantities, cartprice, ref addedcartproducts, ref totalbought, boughtquantity, boughtproducts);
                            if (userOption == 1)
                            {

                                printuser();
                                line("Option 1");
                                veiwproducts(price, ref usernumber, products, quantities, ref addedproducts, review, ref countreview);
                            }
                            if (userOption == 2)
                            {

                                printuser();
                                line("Option 2");
                                buyproducts(credit, ref usernumber, products, quantities, ref addedproducts, totalusers, users, roles, ref usersCount, price, discount, review, ref countreview, buyprice, ref totalbought, boughtquantity, boughtproducts);
                            }
                            if (userOption == 3)
                            {

                                printuser();
                                line("Option 3");
                                veiwreview(price, ref usernumber, products, quantities, ref addedproducts, review, ref countreview);
                            }
                            if (userOption == 10)
                            {
                                clear();
                                break;
                            }
                            Console.WriteLine("Press any key to return");
                            Console.ReadKey();
                            clear();
                        }

                    }
                    else if (role == Role.Undefined)
                    {
                        Console.WriteLine("\t\t\t\t\tYou Entered wrong Credentials");
                    }
                }
                else if (loginOption == 2)
                {
                    Console.Clear();
                    string name;
                    string password;
                    string rolestr;
                    Role role;
                    printsignuponly();
                    Console.WriteLine("\t\t\t\t\tPlease Sign up");
                    Console.Write("\t\t\t\t\tEnter your Name: ");
                    name = Console.ReadLine();
                    Console.Write("\t\t\t\t\tEnter your Password: ");
                    password = Console.ReadLine();
                    Console.Write("\t\t\t\t\tEnter your Role (Admin or User): ");
                    rolestr = Console.ReadLine();

                    while (true)
                    {
                        if (rolestr != "admin" && rolestr != "Admin" && rolestr != "user" && rolestr != "User")
                        {

                            Console.WriteLine("\t\t\t\t\tInvalid Role");
                            Thread.Sleep(1000);
                            Console.Write("\t\t\t\t\tEnter your Role (Admin or User): ");
                            rolestr = Console.ReadLine();
                        }
                        else
                        {
                            break;
                        }
                    }
                    bool isValid = signUp(name, password, (Role)Enum.Parse(typeof(Role), rolestr, true));


                    if (isValid)
                    {
                        totalusers++;
                        Console.WriteLine("\t\t\t\t\tSignedUp Successfully");
                    }
                    if (!isValid)
                    {
                        Console.WriteLine("\t\t\t\t\tSignedUp not Successfully");
                    }
                }
                else if (loginOption == 3)
                {
                    Console.Clear();

                    SaveRecordsToFile(ref usernumber, products, quantities, ref addedproducts, totalusers, users, roles, ref usersCount, price, discount, review, ref countreview, buyprice, loginOption, passwords, userArrSize, cartproducts, cartquantities, cartprice, ref addedcartproducts, ref totalbought, boughtquantity, boughtproducts);


                    break;

                }
                Console.Clear();

            }

        }
        static void clear()
        {
            Console.Clear();
        }
        static void topHeader()
        {
            Console.Write(@"    
                                    ___________________________________________________
                                    |       _______  _______  _______                 |
                                    |      (  ____ \(  ____ )(  ___  )|\     /|       |
                                    |      | (    \/| (    )|| (   ) || )   ( |       |
                                    |      | |      | (____)|| |   | || | _ | |       |
                                    |      | | ____ |     __)| |   | || |( )| |       |
                                    |      | | \_  )| (\ (   | |   | || || || |       |
                                    |      | (___) || ) \ \__| (___) || () () |       |
                                    |      (_______)|/   \__/(_______)(_______)       |
                                    |_________________________________________________|
                                   ");
            Console.WriteLine();
        }
        static void clearScreen()
        {
            Console.WriteLine("\t\t\t\t\tPress Any Key to Continue..");
            Console.ReadKey();
            Console.Clear();

        }
        static void printsigninonly()
        {
            Console.Write(@"
                                                 _               _       
                                             ___(_) __ _ _ __   (_)_ __  
                                            / __| |/ _` | '_ \  | | '_ \ 
                                            \__ \ | (_| | | | | | | | | |
                                            |___/_|\__, |_| |_| |_|_| |_|
                                                   |___/ 
    ");
        }
        static int loginMenu()
        {
            string option = "";
            int option2;
            printsignin();
            printsignup();
            printexit();
            Console.WriteLine();
            Console.Write("\t\t\t\t\tEnter the Option Number > ");
            option = Console.ReadLine();
            if (validateint(option))
            {
                option2 = int.Parse(option);
                return option2;
            }
            else
            {
                Console.Write("\t\t\t\t\tPlease enter valid input!");
                Console.WriteLine("\t\t\t\t\tpress any key to return");
                Console.ReadKey();
                Console.Clear();
                return 0;
            }
            return option2;
        }
        static Role signIn(string name, string password)
        {
            for (int i = 0; i < usersCount; i++)
            {
                if (users[i] != null && users[i].Name == name && users[i].Password == password)
                {
                    return users[i].UserRole;
                }
            }
            return Role.Undefined;
        }

        static void printadmin()
        {
            Console.Write(@"
                            _       _           _         _                      _             _ 
                           / \   __| |_ __ ___ (_)_ __   | |_ ___ _ __ _ __ ___ (_)_ __   __ _| |
                          / _ \ / _` | '_ ` _ \| | '_ \  | __/ _ \ '__| '_ ` _ \| | '_ \ / _` | |
                         / ___ \ (_| | | | | | | | | | | | ||  __/ |  | | | | | | | | | | (_| | |
                        /_/   \_\__,_|_| |_| |_|_|_| |_|  \__\___|_|  |_| |_| |_|_|_| |_|\__,_|_|
    ");
        }
        static int adminMenu(ref int usernumber, string[] products, int[] quantities, ref int addedproducts, int totalusers, string[] users, string[] roles, ref int usersCount, int[] price, int discount, string[] review, ref int countreview, int[] buyprice, int loginOption, string[] passwords, int userArrSize, string[] cartproducts, int[] cartquantities, int[] cartprice, ref int addedcartproducts, ref int totalbought, int[] boughtquantity, string[] boughtproducts)
        {
            string option = "";
            int adminOption = 0;
            Console.WriteLine("You have successfully signed in as a Admin. following are the functions available for");
            Console.WriteLine("you:");
            Console.WriteLine("\t\t\t\t\t1-Add products");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t2-remove products");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t3-View users who have signed up");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t10-Log-out");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tEnter the option number:");
            option = Console.ReadLine();
            if (validateint(option))
            {
                adminOption = int.Parse(option);
                return adminOption;
            }
            else
            {
                Console.WriteLine("\t\t\t\t\tPlease enter valid input!");
                Console.WriteLine("\t\t\t\t\tpress any key to return");
                clear();
                topHeader();
                adminMenu(ref usernumber, products, quantities, ref addedproducts, totalusers, users, roles, ref usersCount, price, discount, review, ref countreview, buyprice, loginOption, passwords, userArrSize, cartproducts, cartquantities, cartprice, ref addedcartproducts, ref totalbought, boughtquantity, boughtproducts);
            }
            return adminOption;
        }
        static bool validateint(string name)
        {
            bool check = false;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] >= '0' && name[i] <= '9')
                {
                    check = true;
                }
                else
                {
                    return false;
                }
            }
            return check;
        }
        static void line(string text)
        {
            Console.WriteLine("\t\t\t\t\tYou have successfully selected the option number: {0}", text);
        }
        static void addproducts(ref int usernumber, string[] products, int[] quantities, ref int addedproducts, int[] price, string[] review, ref int countreview)
        {
            string productn, sizen;
            string pricen = "";
            int Pricen;
            string quantityn = "";
            int Quantityn;
            Console.Write("\t\t\t\t\tEnter the product you want to add: ");
            productn = Console.ReadLine();
            products[addedproducts] = productn;
            Console.Write("\t\t\t\t\tEnter the quantity of the product: ");
            quantityn = Console.ReadLine();
            while (true)
            {
                if (!validateint(quantityn))
                {
                    Console.WriteLine("\t\t\t\t\tInvalid input!!");
                    Thread.Sleep(1000);
                    Console.Write("\t\t\t\t\tEnter the quantity of the product: ");
                    quantityn = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            Quantityn = int.Parse(quantityn);

            quantities[addedproducts] = Quantityn;
            Console.Write("\t\t\t\t\tEnter the price of single item: ");
            pricen = Console.ReadLine();
            while (true)
            {
                if (!validateint(pricen))
                {
                    Console.WriteLine("\t\t\t\t\tInvalid input!!");
                    Thread.Sleep(1000);
                    Console.Write("\t\t\t\t\tEnter the price of the product: ");
                    pricen = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            Pricen = int.Parse(pricen);
            price[addedproducts] = Pricen;
            Console.WriteLine("\t\t\t\t\tYou have successfully added the products ");
            addedproducts++;
        }
        static void removeproducts(ref int usernumber, string[] products, int[] quantities, ref int addedproducts, int[] price, string[] review, ref int countreview)
        {
            string num2 = "";
            int num;
            string product;
            Console.WriteLine("Products are: ");
            for (int i = 0; i < addedproducts; i++)
            {
                Console.WriteLine($"{i + 1}: {products[i],-10}");

            }
            Console.WriteLine("Enter the number to delete or press 0 to go back: ");
            num2 = Console.ReadLine();
            while (true)
            {
                if (!validateint(num2))
                {

                    Console.WriteLine("Invalid input!!");
                    Thread.Sleep(1000);
                    Console.WriteLine("Enter the number to delete or press 0 to go back: ");
                    num2 = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            num = int.Parse(num2);
            if (num != 0)
            {
                product = products[num - 1];
                for (int i = num - 1; i < addedproducts - 1; i++)
                {
                    products[i] = products[i + 1];
                    price[i] = price[i + 1];
                    quantities[i] = quantities[i + 1];
                }
                products[addedproducts - 1] = "";
                price[addedproducts - 1] = 0;
                quantities[addedproducts - 1] = 0;

                addedproducts--;
                Console.WriteLine("{0} removed", product);
            }
        }
        static void alluser(int totalusers, string[] users, string[] roles, ref int usersCount, string[] review, ref int countreview)
        {
            Console.WriteLine("Total number of users in your store: {0}", totalusers);
            Console.Write("{0,-20}{1,-20}\n", "Name", "Role");
            for (int i = 0; i < usersCount; i++)
            {
                Console.Write("{0,-20}{1,-20}\n", users[i], roles[i]);
            }
        }
        static void printsignin()
        {
            Console.Write(@"
                                             _           _               _       
                                            / |  _   ___(_) __ _ _ __   (_)_ __  
                                            | | (_) / __| |/ _` | '_ \  | | '_ \ 
                                            | |  _  \__ \ | (_| | | | | | | | | |
                                            |_| (_) |___/_|\__, |_| |_| |_|_| |_|
                                                           |___/ 
    ");
        }
        static void printsignup()
        {
            Console.Write(@"
                                             ____            _                           
                                            |___ \   _   ___(_) __ _ _ __    _   _ _ __  
                                              __) | (_) / __| |/ _` | '_ \  | | | | '_ \ 
                                             / __/   _  \__ \ | (_| | | | | | |_| | |_) |
                                            |_____| (_) |___/_|\__, |_| |_|  \__,_| .__/ 
                                                               |___/              |_|
        ");
        }
        static void printexit()
        {
            Console.Write(@"
                                             _____       _____      _ _   
                                            |___ /   _  | ____|_  _(_) |_ 
                                              |_ \  (_) |  _| \ \/ / | __|
                                             ___) |  _  | |___ >  <| | |_ 
                                            |____/  (_) |_____/_/\_\_|\__|
    ");
        }
        static void printuser()
        {
            Console.Write(@"
                           _   _                 _                      _             _ 
                          | | | |___  ___ _ __  | |_ ___ _ __ _ __ ___ (_)_ __   __ _| |
                          | | | / __|/ _ \ '__| | __/ _ \ '__| '_ ` _ \| | '_ \ / _` | |
                          | |_| \__ \  __/ |    | ||  __/ |  | | | | | | | | | | (_| | |
                           \___/|___/\___|_|     \__\___|_|  |_| |_| |_|_|_| |_|\__,_|_|
    ");
        }
        static int userMenu(ref int usernumber, string[] products, int[] quantities, ref int addedproducts, int totalusers, string[] users, string[] roles, ref int usersCount, int[] price, int discount, string[] review, ref int countreview, int[] buyprice, int loginOption, string[] passwords, int userArrSize, string[] cartproducts, int[] cartquantities, int[] cartprice, ref int addedcartproducts, ref int totalbought, int[] boughtquantity, string[] boughtproduct)
        {
            string option = "";
            int option2 = 0;
            Console.WriteLine("You have successfully signed in as a buyer.\n following are the functions available for you in our store");
            Console.WriteLine("\t\t\t\t\t1-View products");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t2-Buy products");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t3-Veiw store reviews");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t10-Log out");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tEnter the option number:");
            option = Console.ReadLine();
            if (validateint(option))
            {
                option2 = int.Parse(option);
                return option2;
            }
            else
            {
                Console.WriteLine("\t\t\t\t\tPlease enter valid input!");
                Console.WriteLine("\t\t\t\t\tpress any key to return");
                Console.ReadKey();
                clear();
                userMenu(ref usernumber, products, quantities, ref addedproducts, totalusers, users, roles, ref usersCount, price, discount, review, ref countreview, buyprice, loginOption, passwords, userArrSize, cartproducts, cartquantities, cartprice, ref addedcartproducts, ref totalbought, boughtquantity, boughtproduct);
            }
            return option2;
        }
        static void veiwproducts(int[] price, ref int usernumber, string[] products, int[] quantities, ref int addedproducts, string[] review, ref int countreview)
        {
            if (addedproducts != 0)
            {
                Console.Write("Total number of items entered: {0}", addedproducts);
                Console.Write("{0,-20}{1,-20}{2,-20}\n", "Item", "Price", "Quantity");

                for (int i = 0; i < addedproducts; i++)
                {
                    Console.Write("{0,-20}{1,-20}{2,-20}\n", products[i], price[i], quantities[i]);

                }
            }
            else
            {
                Console.WriteLine("NO products to show!! Admin has not added any product yet");
            }
        }
        static void buyproducts(int[] credit, ref int usernumber, string[] products, int[] quantities, ref int addedproducts, int totalusers, string[] users, string[] roles, ref int usersCount, int[] price, int discount, string[] review, ref int countreview, int[] buyprice, ref int totalbought, int[] boughtquantity, string[] boughtproducts)
        {
            string buy;
            string quan2 = "";
            int quan = 0;
            int dis;
            int leftcredit = 0;
            if (addedproducts != 0)
            {
                if (credit[usernumber] != 0)
                {

                    Console.WriteLine("Following is the list of the added items:");
                    Console.WriteLine("{0,-20}{1,-20}{2,-20}", "Item", "Quantity", "Price");
                    for (int i = 0; i < addedproducts; i++)
                    {
                        Console.WriteLine("{0,-20}{1,-20}{2,-20:C}", products[i], quantities[i], price[i]);
                    }

                    Console.Write("Enter the name of the product you want to buy: ");
                    buy = Console.ReadLine();
                    for (int i = 0; i < addedproducts; i++)
                    {
                        if (products[i] != buy || quantities[i] == 0)
                        {
                            continue;
                        }
                        else if (products[i] == buy && quantities[i] != 0)
                        {
                            Console.Write("Enter the quantity: ");
                            quan2 = Console.ReadLine();
                            while (true)
                            {
                                if (!validateint(quan2))
                                {

                                    Console.WriteLine("Invalid input!!");
                                    Thread.Sleep(1000);
                                    Console.Write("Enter the quantity: ");
                                    quan2 = Console.ReadLine();
                                }
                                else
                                {
                                    break;
                                }
                            }
                            quan = int.Parse(quan2);
                            dis = discount / 100;
                            buyprice[i] = price[i] * quan - dis;

                            if (buyprice[i] <= credit[usernumber])
                            {
                                leftcredit = credit[usernumber] - buyprice[i];
                                Console.WriteLine("You have successfully bought the product for price: {0}", buyprice[i]);
                                Console.WriteLine("Total credit left: {0}", leftcredit);
                                quantities[i] = quantities[i] - quan;
                                boughtquantity[i] = quan;
                                boughtproducts[i] = buy;
                                credit[usernumber] = leftcredit;
                                totalbought++;
                                break;
                            }
                            else if (buyprice[i] > credit[usernumber])
                            {
                                Console.WriteLine("Sorry, your credit limit exceeded. Please recharge.");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You havent added the credit yet!! Please add your credit first");
                }
            }
            else
            {
                Console.WriteLine("The admin has not added any product yet!! SORRY");
            }
        }
        static void veiwreview(int[] price, ref int usernumber, string[] products, int[] quantities, ref int addedproducts, string[] review, ref int countreview)
        {

            if (countreview != 0)
            {
                Console.WriteLine("Reviews given to the store: {0}", countreview);
                for (int i = 0; i < countreview; i++)
                {
                    Console.WriteLine("Reviews given to the store: {0}", countreview);
                    if (review[i] != "")
                    {
                        Console.WriteLine($"{i + 1}: {review[i]}");
                    }
                    else
                    {
                        Console.WriteLine("There is no review given yet");
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no review given yet");
            }
        }
        static void printsignuponly()
        {
            Console.Write(@"
                                                  _                           
                                              ___(_) __ _ _ __    _   _ _ __  
                                             / __| |/ _` | '_ \  | | | | '_ \ 
                                             \__ \ | (_| | | | | | |_| | |_) |
                                             |___/_|\__, |_| |_|  \__,_| .__/ 
                                                    |___/              |_|

");

        }
        static bool signUp(string name, string password, Role role)
        {
            for (int i = 0; i < usersCount; i++)
            {
                if (users[i] != null && users[i].Name == name)
                {
                    Console.WriteLine("\t\t\t\t\tUser already exists. Please choose a different username.\n");
                    return false;
                }
            }

            if (usersCount < userArrSize)
            {
                users[usersCount] = new User(name, password, role);
                usersCount++;

                return true;
            }
            else
            {
                Console.WriteLine("\t\t\t\t\tUser limit reached. Cannot sign up.\n");
                return false;
            }
        }
        static void SaveRecordsToFile(ref int usernumber, string[] products, int[] quantities, ref int addedproducts, int totalusers, string[] users, string[] roles, ref int usersCount, int[] price, int discount, string[] review, ref int countreview, int[] buyprice, int loginOption, string[] passwords, int userArrSize, string[] cartproducts, int[] cartquantities, int[] cartprice, ref int addedcartproducts, ref int totalbought, int[] boughtquantity, string[] boughtproducts)
        {
            using (StreamWriter file = new StreamWriter("signup.txt"))
            {
                for (int i = 0; i < usersCount; i++)
                {
                    if (!string.IsNullOrWhiteSpace(users[i]))
                    {
                        file.Write(users[i]);
                        file.Write('~');
                        file.Write(passwords[i]);
                        file.Write('~');
                        file.Write(roles[i]);
                        if (i != usersCount - 1)
                        {
                            file.Write('\n');
                        }
                    }
                }
            }
        }
        static void LoadRecords(ref int usernumber, string[] products, int[] quantities, ref int addedproducts, int totalusers, string[] users, string[] roles, ref int usersCount, int[] price, int discount, string[] review, ref int countreview, int[] buyprice, int loginOption, string[] passwords, int userArrSize, string[] cartproducts, int[] cartquantities, int[] cartprice, ref int addedcartproducts, ref int totalbought, int[] boughtquantity, string[] boughtproducts)
        {
            usersCount = 0;
            string record = "";

            try
            {
                using (StreamReader file = new StreamReader("signup.txt"))
                {
                    while ((record = file.ReadLine()) != null)
                    {
                        users[usersCount] = GetField(record, 1);
                        passwords[usersCount] = GetField(record, 2);
                        roles[usersCount] = GetField(record, 3);
                        usersCount++;
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"\t\t\t\t\tUnable to open signup.txt file. {ex.Message}");
            }
        }

        static string GetField(string record, int fieldNumber)
        {
            string[] fields = record.Split('~');
            if (fieldNumber > 0 && fieldNumber <= fields.Length)
            {
                return fields[fieldNumber - 1];
            }
            return string.Empty;
        }
    }
}