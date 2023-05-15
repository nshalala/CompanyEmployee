
//using CompanyEmployee.Business.Services;

//CompanyService companyService = new CompanyService();
//DepartmentService departmentService = new DepartmentService();
//EmployeeService employeeService = new EmployeeService();
//string name;
//int id;
//int skip;
//int take;
//int limit;
//var list; 

//Console.WriteLine("This is company - department - employee relations managament system. \nWhat action would you like to take?");

//MainMenu:

//Console.WriteLine("1. Company operations"
//              + "\n2. Department operations"
//              + "\n3. Employee operations"
//              + "\n4. Exit");
//int step1;
//bool check = int.TryParse(Console.ReadLine(), out step1);
//if (!check)
//{
//    throw new FormatException("Please enter a number.");
//}

//while (true)
//{
//    switch (step1)
//    {
//        case 4:
//            System.Environment.Exit(0);
//            break;
//        case 1:
//            #region CompanyMenu
//            Console.WriteLine("1. Create a company"
//                          + "\n2. Delete a company"
//                          + "\n3. Update a company info"
//                          + "\n4. Get a list of all departments of a company"
//                          + "\n5. Get a list of all companies"
//                          + "\n6. Return to main menu");
//            int compMenu;
//            bool compMenuCheck = int.TryParse(Console.ReadLine(), out compMenu);
//            if (!compMenuCheck)
//            {
//                throw new FormatException("Please enter a number.");
//            }
//            switch (compMenu)
//            {
//                case 1:
//                    //Create a company
//                    Console.Write("Enter the name of company that you want to create:  ");
//                    name = Console.ReadLine();
//                    companyService.Create(name);
//                    break;
//                case 2:
//                    //Delete a company
//                    Console.Write("Which company would you like to delete?  ");
//                    name = Console.ReadLine();
//                    companyService.Delete(name);
//                    break;
//                case 3:
//                    //Update a company
//                    Console.Write("Enter the company's id:  ");
//                    id = int.Parse(Console.ReadLine());
//                    Console.Write("Enter new name for the company:  ");
//                    name = Console.ReadLine();
//                    companyService.Update(id, name);
//                    break;
//                case 4:
//                    //Get all departments
//                    Console.Write("Enter the company's id:  ");
//                    id = int.Parse(Console.ReadLine());
//                    companyService.GetAllDepartments(id);
//                    break;
//                case 5:
//                    //Get all companies
//                    Console.Write("Enter corresponding values:\nGet:  ");
//                    skip = int.Parse(Console.ReadLine());
//                    Console.Write("Take:  ");
//                    take = int.Parse(Console.ReadLine());
//                    list = companyService.GetAll(skip, take);
//                    foreach (var item in list)
//                    {
//                        Console.WriteLine(item.Name);
//                    }
//                    break;
//                case 6:
//                    goto MainMenu;
//                default:
//                    Console.WriteLine("Such option doesn't exist. Choose another one:");
//                    break;
//            }
//            #endregion
//            break;
//        case 2:
//            #region DepartmentMenu
//            Console.WriteLine("1. Create a department"
//                          + "\n2. Delete a department"
//                          + "\n3. Update a department"
//                          + "\n4. Get a list of all departments"
//                          + "\n5. Get a list of all departments by name"
//                          + "\n6. Go to main menu");
//            int depMenu;
//            bool depMenuCheck = int.TryParse(Console.ReadLine(), out depMenu);
//            if (!depMenuCheck)
//            {
//                throw new FormatException("Please enter a number.");
//            }
//            switch (depMenu)
//            {
//                case 1:
//                    //Create a company
//                    Console.Write("Enter the name of department that you want to create:  ");
//                    name = Console.ReadLine();
//                    Console.Write("Enter employee limit for the department:  ");
//                    limit = int.Parse(Console.ReadLine());
//                    Console.Write("Enter company id:  ");
//                    id = int.Parse(Console.ReadLine());

//                    departmentService.Create(name,limit,id);
//                    break;
//                case 2:
//                    //Delete a company
//                    Console.Write("Enter department id:  ");
//                    id = int.Parse(Console.ReadLine());
//                    departmentService.Delete(id);
//                    break;
//                case 3:
//                    //Update a company
//                    Console.Write("Enter the department's id:  ");
//                    id = int.Parse(Console.ReadLine());
//                    Console.Write("Enter a name for the department:  ");
//                    name = Console.ReadLine();
//                    Console.Write("Enter employee limit for the department:  ");
//                    limit = int.Parse(Console.ReadLine());
//                    departmentService.Update(id, name, limit);
//                    break;
//                case 4:
//                    //Get all departments
//                    Console.Write("Enter corresponding values:\nStart from:  ");
//                    skip = int.Parse(Console.ReadLine());
//                    Console.Write("Take:  ");
//                    take = int.Parse(Console.ReadLine());
//                    list = departmentService.GetAll(skip, take);
//                    foreach (var item in list)
//                    {
//                        Console.WriteLine(item.Name);
//                    }
//                    break;
//                case 5:
//                    //Get all companies
//                    Console.Write("Enter department name:  ");
//                    name = Console.ReadLine();
//                    departmentService.GetAllByName(name);
//                    break;
//                case 6:
//                    goto MainMenu;
//                default:
//                    Console.WriteLine("Such option doesn't exist. Choose another one:");
//                    break;
//            }
//            #endregion
//            break;
//    }
//}


using CompanyEmployee.Business.Services;

CompanyService companyService = new CompanyService();
DepartmentService departmentService = new DepartmentService();
EmployeeService employeeService = new EmployeeService();

Console.WriteLine("This is a company-department-employee relations management system.\nWhat action would you like to take?");

while (true)
{
    Console.WriteLine("\n1. Company operations"
                    + "\n2. Department operations"
                    + "\n3. Employee operations"
                    + "\n4. Exit");
    int step1;
    bool check = int.TryParse(Console.ReadLine(), out step1);
    if (!check)
    {
        throw new FormatException("Please enter a number.");
    }
    switch (step1)
    {
        case 4:
            System.Environment.Exit(0);
            break;
        case 1:
            CompanyMenu();
            break;
        case 2:
            DepartmentMenu();
            break;
        case 3:
            EmployeeMenu();
            break;
        default:
            Console.WriteLine("Such option doesn't exist. Choose another one:");
            break;
    }
}

void CompanyMenu()
{
    Console.WriteLine("\n1. Create a company"
                    + "\n2. Delete a company"
                    + "\n3. Update a company info"
                    + "\n4. Get a list of all departments of a company"
                    + "\n5. Get a list of all companies"
                    + "\n6. Return to the main menu");
    int choice;
    bool check = int.TryParse(Console.ReadLine(), out choice);
    if (!check)
    {
        throw new FormatException("Please enter a number.");
    }
    string name;
    int id;
    switch(choice)
    {
        case 1:
            // Create a company
            Console.Write("Enter the name of the company you want to create: ");
            name = Console.ReadLine();
            companyService.Create(name);
            break;
        case 2:
            // Delete a company
            Console.Write("Enter the name of the company you want to delete: ");
            name = Console.ReadLine();
            companyService.Delete(name);
            break;
        case 3:
            // Update a company
            Console.Write("Enter the company's id: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Enter the new name for the company: ");
            name = Console.ReadLine();
            companyService.Update(id, name);
            break;
        case 4:
            // Get all departments
            Console.Write("Enter the company's id: ");
            id = int.Parse(Console.ReadLine());
            
            foreach (var item in companyService.GetAllDepartments(id))
            {
                Console.WriteLine(item.Name);
            }
            break;
        case 5:
            // Get all companies
            Console.Write("Enter the corresponding values:\nStart from: ");
            int skip = int.Parse(Console.ReadLine());
            Console.Write("Take: ");
            int take = int.Parse(Console.ReadLine());
            var list = companyService.GetAll(skip, take);
            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
            break;
        case 6:
            return;
        default:
            Console.WriteLine("Such option doesn't exist. Choose another one:");
            break;
    }
}
void DepartmentMenu()
{
    Console.WriteLine("\n1. Create a department"
                    + "\n2. Delete a department"
                    + "\n3. Update department info"
                    + "\n4. Get a list of departments by name"
                    + "\n5. Get a list of departments"
                    + "\n6. Return to the main menu");
    int choice;
    bool check = int.TryParse(Console.ReadLine(), out choice);
    if (!check)
    {
        throw new FormatException("Please enter a number.");
    }
    string name;
    int depId;
    int compId;
    int limit;
    switch (choice)
    {
        case 1:
            // Create a department
            Console.Write("Enter the name for the department you want to create: ");
            name = Console.ReadLine();
            Console.Write("Enter employee limit:  ");
            limit = int.Parse(Console.ReadLine());
            Console.Write("Enter company id which your department belongs:  ");
            compId = int.Parse(Console.ReadLine());
            departmentService.Create(name,limit,compId);
            break;
        case 2:
            // Delete a department
            Console.Write("Enter department id: ");
            depId = int.Parse(Console.ReadLine());
            departmentService.Delete(depId);
            break;
        case 3:
            // Update a department
            Console.Write("Enter department id: ");
            depId = int.Parse(Console.ReadLine());
            Console.Write("Enter department name: ");
            name = Console.ReadLine();
            Console.Write("Enter employee limit: ");
            limit = int.Parse(Console.ReadLine());
            departmentService.Update(depId, name, limit);
            break;
        case 4:
            // Get all departments by name
            Console.Write("Enter name to search: ");
            name = Console.ReadLine();
            foreach (var item in departmentService.GetAllByName(name))
            {
                Console.WriteLine(item.Name);
            }
            break;
        case 5:
            // Get all departments
            Console.Write("Enter the corresponding values:\nStart from: ");
            int skip = int.Parse(Console.ReadLine());
            Console.Write("Take: ");
            int take = int.Parse(Console.ReadLine());
            var list = departmentService.GetAll(skip, take);
            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
            break;
        case 6:
            return;
        default:
            Console.WriteLine("Such option doesn't exist. Choose another one:");
            break;
    }
}
void EmployeeMenu()
{
    Console.WriteLine("\n1. Create an employee"
                    + "\n2. Delete an employee"
                    + "\n3. Update employee info"
                    + "\n4. Get a list of employees by name"
                    + "\n5. Get a list of employees by salary range"
                    + "\n6. Get a list of employees"
                    + "\n7. Return to the main menu");
    int choice;
    bool check = int.TryParse(Console.ReadLine(), out choice);
    if (!check)
    {
        throw new FormatException("Please enter a number.");
    }
    string name;
    string surname;
    int empId;
    double salary;
    switch (choice)
    {
        case 1:
            // Create an employee
            Console.Write("Enter the name of the employee:  ");
            name = Console.ReadLine();
            Console.Write("Enter surname of the employee:  ");
            surname = Console.ReadLine();
            Console.Write("Enter surname of the employee:  ");
            salary = double.Parse(Console.ReadLine());
            employeeService.Create(name, surname, salary);
            break;
        case 2:
            // Delete an employee
            Console.Write("Enter employee id: ");
            empId = int.Parse(Console.ReadLine());
            employeeService.Delete(empId);
            break;
        case 3:
            // Update an employee
            Console.Write("Enter employee id: ");
            empId = int.Parse(Console.ReadLine());
            Console.Write("Enter employee name: ");
            name = Console.ReadLine();
            Console.Write("Enter employee surname: ");
            surname = Console.ReadLine();
            Console.Write("Enter employee salary: ");
            salary = double.Parse(Console.ReadLine());
            employeeService.Update(empId, name, surname, salary);
            break;
        case 4:
            // Get employees by name
            Console.Write("Enter name to search: ");
            name = Console.ReadLine();
            foreach (var item in employeeService.GetAllByName(name))
            {
                Console.WriteLine(item.Name);
            }
            break;
        case 5:
            // Get employees by salary range
            Console.Write("Enter the corresponding values:\nStart from: ");
            int skip = int.Parse(Console.ReadLine());
            Console.Write("Take: ");
            int take = int.Parse(Console.ReadLine());
            var list = employeeService.GetAll(skip, take);
            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
            break;
        case 6:
            return;
        default:
            Console.WriteLine("Such option doesn't exist. Choose another one:");
            break;
    }
}