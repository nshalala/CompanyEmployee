using CompanyEmployee.Business.Services;
using CompanyEmployee.Core.Entities;

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
                    + "\n6. Add a new employee"
                    + "\n7. Return to the main menu");
    int choice;
    bool check = int.TryParse(Console.ReadLine(), out choice);
    if (!check)
    {
        throw new FormatException("Please enter a number.");
    }
    string name;
    int depId;
    int empId;
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
            Console.Write("Enter department id: ");
            depId = int.Parse(Console.ReadLine());
            Console.Write("Enter employee id: ");
            empId = int.Parse(Console.ReadLine());
            var dep = departmentService.GetById(depId);
            var emp = employeeService.GetById(empId);
            departmentService.AddEmployee(dep, emp);
            break;
        case 7:
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
                    + "\n7. Transfer employee"
                    + "\n8. Return to the main menu");
    int choice;
    bool check = int.TryParse(Console.ReadLine(), out choice);
    if (!check)
    {
        throw new FormatException("Please enter a number.");
    }
    string name;
    string surname;
    int empId;
    int depId;
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
            Console.Write("Enter the corresponding values:\nMin: ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Max: ");
            int max = int.Parse(Console.ReadLine());
            var list = employeeService.GetBySalaryRange(min, max);
            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
            break;
        case 6:
            //get all emp
            Console.Write("Enter the corresponding values:\nStart from: ");
            int skip = int.Parse(Console.ReadLine());
            Console.Write("Take: ");
            int take = int.Parse(Console.ReadLine());
            var list1 = employeeService.GetAll(skip, take);
            foreach (var item in list1)
            {
                Console.WriteLine(item.Name);
            }
            break;
        case 7:
            //Transfer employee
            Console.WriteLine("Enter employee id:  ");
            empId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter department id:  ");
            depId = int.Parse(Console.ReadLine());
            employeeService.Transfer(empId, depId);
            break;
        case 8:
            return;
        default:
            Console.WriteLine("Such option doesn't exist. Choose another one:");
            break;
    }
}