using Azure;
using EfCore01.Contexts;
using EfCore01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace EfCore01
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using CompanyDbContext dbContext = new CompanyDbContext();
            //using CompanyDbContext dbContext01 = new CompanyDbContext();
            #region Session 03

            #region Another Ways
            //await dbContext.Database.MigrateAsync(); // Apply pending migrations In App
            //  //using CompanyDbContext dbContext = new CompanyDbContext()
            //  //{



            //  //};


            //  //try
            //  //{

            //  //}
            //  //catch (Exception ex)
            //  //{

            //  //}

            //  //finally
            //  //{
            //  //    dbContext.Dispose(); //Deallocate object dbcontext from heap
            //  //                         // connection is clodes 
            #endregion

            #region CRUD
            #region Entity states
            //Entity States
            //1)Detached:object is not tracked by dbContext[Change tracker]
            //Detached objects to be tracked by dbContext/Must be added
            //savechanges() method=>will not do anything

            //2)Added:object is tracked by dbContext[Change tracker]
            //object is added locally in RAM [In memory]
            //savechanges() method=>will be inserted in database [insert command]

            //3 Modified: retreive row from db into entitty[object]
            // change some values of object locally in RAM [In memory]
            //savechanges() method=>will be updated in database [update command]

            //4)Deleted: retreive row from db into entitty[object]
            //Remove() => will remove this object from RAM [In memory]
            //mark object state as deleted
            //savechanges() method=>will be deleted in database [delete command]


            //5) UnChanged: retreive row from db into entitty[object]
            //savechanges()=> will not do anything

            //Insert Scenario
            // obj is detached=>Added=>savechanges()=>inserted in db=>UnChanged

            //Update Scenario
            //obj is Unchanged =>Modified=> after save [Update]=>Unchanged

            //Delete scenario
            //obj is Unchanged=>Deleted=>After save=>detached

            //Get
            //obj is unchanged=>unchnaged 
            #endregion

            #region Create
            //var department01 = new Department()
            //{
            //    DeptName = "IT"
            //};

            //Console.WriteLine(dbContext.Entry(department01).State);//detached
            //Console.WriteLine(department01.DeptId); //0
            //                                        //4 ways to Add


            //#region Another ways
            //// dbContext.Set<Department>().Add(department01);

            ////dbContext.Add<Department>(department01);
            //// dbContext.Add(department01);

            ////dbContext.Entry(department01).State = EntityState.Added; 
            //#endregion

            //dbContext.Departments.Add(department01);
            //Console.WriteLine("After Add");
            //Console.WriteLine(dbContext.Entry(department01).State);//Added
            //Console.WriteLine(department01.DeptId);//0


            //await dbContext.SaveChangesAsync();

            //Console.WriteLine("After save");
            //Console.WriteLine(dbContext.Entry(department01).State);//unchanged
            //Console.WriteLine(department01.DeptId);//10
            //var department02 = new Department()
            //{
            //    DeptName = "HR"
            //};

            //Console.WriteLine(dbContext.Entry(department02).State);//detached
            //Console.WriteLine(department02.DeptId); //0
            //4 ways to Add


            #region Another ways
            // dbContext.Set<Department>().Add(department01);

            //dbContext.Add<Department>(department01);
            // dbContext.Add(department01);

            //dbContext.Entry(department01).State = EntityState.Added; 
            #endregion

            //dbContext.Departments.Add(department02);
            //Console.WriteLine("After Add");
            //Console.WriteLine(dbContext.Entry(department02).State);//Added
            //Console.WriteLine(department02.DeptId);//0


            //await dbContext.SaveChangesAsync();

            //Console.WriteLine("After save");
            //Console.WriteLine(dbContext.Entry(department02).State);//unchanged
            //Console.WriteLine(department02.DeptId);//30 
            #endregion

            #region Read

            #region Query Tracking Behavior
            // dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;//[default]


            //dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //EF Core doesn't track any entity in memory [RAM] after retreiving it from DB
            //Ef Core will not detect any changes



            //dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution 

            // dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll; //default
            //  dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; //NoTrcaking
            //  dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            #endregion



            //var department = await dbContext.Departments.AsNoTracking().FirstOrDefaultAsync(D => D.DeptName == "IT");
            //Console.WriteLine(dbContext.Entry(department).State);  //unchanged

            //Console.WriteLine(department?.DeptName);

            //Console.WriteLine(dbContext.Entry(department).State);  //unchanged


            #endregion

            #region Update
            // Object retreived from Db [unchanged] =>Modiifed=>unchanged

            #region Connected Scenario
            //var department =await dbContext.Departments.FirstOrDefaultAsync(D => D.DeptId == 30);

            //if(department is not null)
            //{
            //    Console.WriteLine("After retreiving");
            //    Console.WriteLine($"Department  State:{dbContext.Entry(department).State}"); //entity state =>unchanged

            //    department.DeptName = "Sales";
            //    Console.WriteLine("After modfying");
            //    Console.WriteLine($"Department  State:{dbContext.Entry(department).State}"); //entity state =>modified

            //    Console.WriteLine($"Original Name : {dbContext.Entry(department).OriginalValues["DeptName"]}"); //IT
            //    Console.WriteLine($"Current Name : {dbContext.Entry(department).CurrentValues["DeptName"]}"); // Sales

            //    await dbContext.SaveChangesAsync();

            //    Console.WriteLine("After saving");
            //    Console.WriteLine($"Department  State:{dbContext.Entry(department).State}"); //entity state =>Unchanged

            //    Console.WriteLine($"Original Name : {dbContext.Entry(department).OriginalValues["DeptName"]}"); //Sales
            //    Console.WriteLine($"Current Name : {dbContext.Entry(department).CurrentValues["DeptName"]}"); //Sales
            //} 
            #endregion
            //Retreive entity from Db using Context
            //EF Core automatically will track any changes 
            // Modify any properties of retreived object 
            //Ef Core will know what changes happen
            //After save will do update command on only what changes



            //DisConnected Scenario
            // we have entity [object] not currently tracked from current context
            //from another insstance from same context 
            // another application layer
            // entity is not attached to current context


            //var department = new Department()
            //{
            //    DeptId = 30,
            //    DeptName = "DM",
            //    DateOfCreation = new DateTime(2026, 10, 11)
            //};

            //Console.WriteLine($"Department State:{dbContext.Entry(department).State}"); //entity state =>detached


            //dbContext.Update(department); //Attach object in Change Tracker to current Context [added]
            //                              // to be mark this object state into modified

            //Console.WriteLine("After Updating");
            //Console.WriteLine($"Department State:{dbContext.Entry(department).State}"); //entity state =>detached

            //await dbContext.SaveChangesAsync();
            //Console.WriteLine("After Saving");
            //Console.WriteLine($"Department State:{dbContext.Entry(department).State}"); //entity state =>detached


            #endregion


            #region Delete


            // retreive row from Db into Entity [Unchanged]=>Deleted=>detached after savechanges

            //var department=await dbContext.Departments.FirstOrDefaultAsync(D => D.DeptId == 30);
            //if(department is not null)
            //{
            //    Console.WriteLine($"Department State:{dbContext.Entry(department).State}"); //entity state =>unchanged

            //    //remove from Memory [4 ways]

            //    dbContext.Departments.Remove(department); //entity state =>Deleted

            //    Console.WriteLine("After Remove");
            //    Console.WriteLine($"Department State:{dbContext.Entry(department).State}"); //entity state =>deleted

            //    await dbContext.SaveChangesAsync();

            //    Console.WriteLine("After saving");
            //    Console.WriteLine($"Department State:{dbContext.Entry(department).State}"); //entity state =>deleted


            //dbContext.Set<Department>().Remove(department); //entity state =>Deleted
            //dbContext.Remove(department); //entity state =>Deleted
            //dbContext.Entry(department).State = EntityState.Deleted; //entity state =>Deleted


            //var department = new Department()
            //{
            //    DeptId = 40
            //};

            //Console.WriteLine("before attaching");
            //Console.WriteLine($"Department State:{dbContext.Entry(department).State}"); //entity state =>detached


            //dbContext.Remove(department);  //Added into change tracker & mark it as Deleted

            //Console.WriteLine("After Remove");
            //Console.WriteLine($"Department State:{dbContext.Entry(department).State}"); //entity state =>deleted


            //await dbContext.SaveChangesAsync();

            //Console.WriteLine("After saving");
            //Console.WriteLine($"Department State:{dbContext.Entry(department).State}"); //entity state =>detached







            #endregion




            #endregion
            #endregion


            #region Session 04
            #region Bulk Operations
            //To Update & Delete Multiple Records In DB
            //Normal approach :Traditional approac
            //1-Retreive rows from DB Into Object
            //2-Load into Memory
            //3-Change tracker will track all this entites
            //4-Modify or delete using foreach
            //5-SaveChanges() => at end execute 4 Update statement in sql


            //Bulk Update
            //ExecuteUpdate/ExcuteUpdateAsync
            //1-Update Multiple records directly into DB
            //2-Don't have need to load them In RAM
            //3-Don't be needed to be tracked
            //4-Doesn't require savechanges()

            //Bulk Delete
            //ExecuteDelete/ExcuteDeleteAsync
            //1-Delete Multiple records directly into DB
            //2-Don't have need to load them In RAM
            //3-Don't be needed to be tracked
            //4-Doesn't require savechanges()


            //var department01 = new Department()
            //{
            //    DeptName = "IT"
            //};

            //var department02 = new Department()
            //{
            //    DeptName = "HR"
            //};

            //dbContext.Departments.Add(department01);
            //dbContext.Departments.Add(department02);

            //dbContext.SaveChanges();

            //var employees = new List<Employee>()
            //{
            //    new Employee()
            //    {
            //        EmpName="Khaled",
            //        Salary=10000,
            //        Age=26,
            //        Email="Khaled@gmail.com",
            //        Phone="01080975585",
            //        Password="1234",
            //        DepartmentWorkingId=10,
            //        EmpAddress=new Address()
            //        {
            //            City="Cairo",
            //            Street="Maadi",
            //            Country="Egypt"
            //        }
            //    },
            //    new Employee()
            //    {
            //        EmpName="Ahmed",
            //        Salary=6000,
            //        Age=23,
            //        Email="Ahmed@gmail.com",
            //        Phone="01080975585",
            //        Password="1234",
            //        DepartmentWorkingId=20,
            //        EmpAddress=new Address()
            //        {
            //            City="Giza",
            //            Street="Dokki",
            //            Country="Egypt"
            //        }
            //    },
            //    new Employee()
            //    {
            //        EmpName="Ziad",
            //        Salary=12000,
            //        Age=28,
            //        Email="Ziad@gmail.com",
            //        Phone="01080975585",
            //        Password="1234",
            //        DepartmentWorkingId=10,
            //        EmpAddress=new Address()
            //        {
            //            City="Alex",
            //            Street="Khaled-Ibn-Waleed",
            //            Country="Egypt"
            //        }
            //    },
            //};

            //dbContext.Employees.AddRange(employees);

            //dbContext.SaveChanges();



            //var employees = dbContext.Employees.Where(E => E.Salary > 5000);

            //foreach(var employee in employees)
            //{
            //    employee.Salary += employee.Salary * 0.2m;
            //}


            //dbContext.SaveChanges();


            //Bulk Update

            //int rowAffected=   dbContext.Employees.Where(E => E.Salary > 5000)
            //       .ExecuteUpdate(E => E.SetProperty(emp => emp.Salary, emp => emp.Salary * 1.2m));
            //   Console.WriteLine(rowAffected);

            //chaining

            //int rowAffected=   dbContext.Employees.Where(E => E.Salary > 5000)
            //       .ExecuteUpdate(
            //    E => E.SetProperty(emp => emp.Salary, emp => emp.Salary * 1.2m)
            //          .SetProperty(emp=>emp.EmpName,emp=>"New Default Name")
            //    );


            //   Console.WriteLine(rowAffected);


            //1-Property Expression:What Column you want to update on it
            //2-Value Expression : What value modified for this column




            //int result = dbContext.Employees.Where(E => E.Salary > 5000)
            //    .ExecuteDelete();

            //Console.WriteLine(result);

            #endregion


            #region Manual Data Seeding
            //Manual Data seeding
            //Custom code at startUp

            //List<Project> projects = new List<Project>()
            //{
            //    new Project(){PName="P01"},
            //    new Project(){PName="P02"},
            //    new Project(){PName="P03"},
            //    new Project(){PName="P04"},
            //};


            //if(!dbContext.Set<Project>().Any())
            //{

            //    dbContext.Set<Project>().AddRange(projects);
            //    dbContext.SaveChanges();

            //}

            //else
            //{
            //    Console.WriteLine("Projects Table already seeded");
            //}

            #endregion


            #region Loading Related Data

            #region Problem
            //var emp01 = dbContext.Employees.FirstOrDefault(E => E.EmpId == 40);

            //if (emp01 is not null)
            //{
            //    Console.WriteLine($"Employee Name :{emp01.EmpName}");
            //    Console.WriteLine($"Employee Department Id :{emp01.DepartmentWorkingId}");
            //    var departmentOfEmployee = dbContext.Departments.FirstOrDefault(D => D.DeptId == emp01.DepartmentWorkingId);
            //    Console.WriteLine($"Employee Department Name :{emp01.WorkingDepartment?.DeptName}");
            //}


            #endregion

            #region Solution

            #region Projection
            //var emp01 = dbContext.Employees.Select(E => new
            //{
            //    E.EmpId,
            //    E.EmpName,
            //    E.DepartmentWorkingId,
            //    E.WorkingDepartment.DeptName  //project into nav property not loaded by default ,so force ORM to do inner join
            //}).FirstOrDefault(E => E.EmpId == 40);


            //if (emp01 is not null)
            //{
            //    Console.WriteLine($"Employee Id :{emp01.EmpId}");
            //    Console.WriteLine($"Employee Name :{emp01.EmpName}");
            //    Console.WriteLine($"Employee Department Id :{emp01.DepartmentWorkingId}");
            //    Console.WriteLine($"Employee Department Name:{emp01.DeptName}");

            //    //   SELECT TOP(1) [e].[EmpId], [e].[EmployeeName] AS[EmpName], [e].[DepartmentWorkingId], [d].[DepartmentName] AS[DeptName]
            //    //FROM[EmployeesTable] AS[e]
            //    //INNER JOIN[Sales].[DepartmentsTable] AS[d] ON[e].[DepartmentWorkingId] = [d].[DeptId]
            //    //WHERE[e].[EmpId] = 40
            //}


            #endregion

            #region Eager Loading

            #region Example 01
            //var emp01 = dbContext.Employees.Include(E=>E.WorkingDepartment).FirstOrDefault(E => E.EmpId == 40);

            //if (emp01 is not null)
            //{
            //    Console.WriteLine($"Employee Name :{emp01.EmpName}");
            //    Console.WriteLine($"Employee Department Id :{emp01.DepartmentWorkingId}");
            //    Console.WriteLine($"Employee Department Name :{emp01.WorkingDepartment?.DeptName}");

            //    // SELECT TOP(1) [e].[EmpId], [e].[Age], [e].[CreationDate], [e].[DepartmentWorkingId], [e].[Email], [e].[EmployeeName], [e].[Password], [e].[Phone], [e].[Salary], [e].[SupervisorId], [e].[EmployeeCity], [e].[EmployeeCountry], [e].[EmployeeStreet], [d].[DeptId], [d].[CreationDate], [d].[DeptManagerId], [d].[DepartmentName]
            //    //FROM[EmployeesTable] AS[e]
            //    //INNER JOIN[Sales].[DepartmentsTable] AS[d] ON[e].[DepartmentWorkingId] = [d].[DeptId]
            //    //WHERE[e].[EmpId] = 40
            //} 
            #endregion

            #region Example 02
            //var emp01 = dbContext.Employees.Include(E => E.WorkingDepartment).Include(E=>E.ManagedDepartment).FirstOrDefault(E => E.EmpId == 40);

            //if (emp01 is not null)
            //{
            //    Console.WriteLine($"Employee Name :{emp01.EmpName}");
            //    Console.WriteLine($"Employee Department Id :{emp01.DepartmentWorkingId}");
            //    Console.WriteLine($"Employee Department Name :{emp01.WorkingDepartment?.DeptName}");
            //    Console.WriteLine($"Employee Department Name :{emp01.ManagedDepartment?.DeptName}");

            //    // SELECT TOP(1) [e].[EmpId], [e].[Age], [e].[CreationDate], [e].[DepartmentWorkingId], [e].[Email], [e].[EmployeeName], [e].[Password], [e].[Phone], [e].[Salary], [e].[SupervisorId], [e].[EmployeeCity], [e].[EmployeeCountry], [e].[EmployeeStreet], [d].[DeptId], [d].[CreationDate], [d].[DeptManagerId], [d].[DepartmentName], [d0].[DeptId], [d0].[CreationDate], [d0].[DeptManagerId], [d0].[DepartmentName]
            //    //FROM[EmployeesTable] AS[e]
            //    //INNER JOIN[Sales].[DepartmentsTable] AS[d] ON[e].[DepartmentWorkingId] = [d].[DeptId]
            //    //LEFT JOIN[Sales].[DepartmentsTable] AS[d0] ON[e].[EmpId] = [d0].[DeptManagerId]
            //    //WHERE[e].[EmpId] = 40

            //} 
            #endregion

            #region Example 03
            //var student = dbContext.Students.Include(S=>S.StudentCourses).ThenInclude(SC=>SC.Course).FirstOrDefault(S => S.Id == 1);

            //if(student is not null)
            //{
            //    Console.WriteLine($"Id:{student.Id}");
            //    Console.WriteLine($"Name:{student.SName}");
            //    Console.WriteLine("=================================");
            //    foreach(var studentCourse in student.StudentCourses)
            //    {
            //        Console.WriteLine($"Course Id:{studentCourse.CrsId}");
            //        Console.WriteLine($"Course Grade:{studentCourse.Grade}");
            //        Console.WriteLine($"Course Name:{studentCourse.Course?.CName}");
            //    }


            //    // SELECT[s1].[Id], [s1].[SName], [s2].[CrsId], [s2].[StdId], [s2].[Grade], [s2].[Id], [s2].[CName]
            //    //FROM(
            //    //    SELECT TOP(1)[s].[Id], [s].[SName]
            //    //    FROM[Students] AS[s]
            //    //    WHERE[s].[Id] = 1
            //    //) AS[s1]
            //    //LEFT JOIN(
            //    //    SELECT[s0].[CrsId], [s0].[StdId], [s0].[Grade], [c].[Id], [c].[CName]
            //    //    FROM [StudentCourse] AS [s0]
            //    //    INNER JOIN [Courses] AS[c] ON [s0].[CrsId] = [c].[Id]
            //    //) AS[s2] ON[s1].[Id] = [s2].[StdId]
            //    //ORDER BY[s1].[Id], [s2].[CrsId], [s2].[StdId]



            //} 
            #endregion

            #region Example 04

            // var student = dbContext.Students.Include(S => S.StudentCourses.Where(sc=>sc.Grade>90)).
            //    FirstOrDefault(S => S.Id == 1);

            //if (student is not null)
            //{
            //    Console.WriteLine($"Id:{student.Id}");
            //    Console.WriteLine($"Name:{student.SName}");
            //    Console.WriteLine("=================================");
            //    foreach (var studentCourse in student.StudentCourses)
            //    {
            //        Console.WriteLine($"Course Id:{studentCourse.CrsId}");
            //        Console.WriteLine($"Course Grade:{studentCourse.Grade}");
            //    } 
            #endregion

            #endregion

            #region Explicit Loading

            //var emp01 = dbContext.Employees.FirstOrDefault(E => E.EmpId == 40);

            //if(emp01 is not null)
            //{

            //    Console.WriteLine($"Employee Name :{emp01.EmpName}");
            //      Console.WriteLine($"Employee Department Id :{emp01.DepartmentWorkingId}");

            //    dbContext.Entry(emp01).Reference(E => E.WorkingDepartment).Load();
            //    Console.WriteLine($"Employee Department Name :{emp01.WorkingDepartment?.DeptName}");
            //}

            //var department = dbContext.Departments.FirstOrDefault(D => D.DeptId == 10);

            //if(department is not null)
            //{
            //    Console.WriteLine(department.DeptId);
            //    Console.WriteLine(department.DeptName);
            //    Console.WriteLine("=====================");

            //    dbContext.Entry(department).Collection(D => D.Employees).Load();
            //    foreach(var employee in department.Employees)
            //    {
            //        Console.WriteLine(employee.EmpName);
            //    }
            //}
            //var department = dbContext.Departments.FirstOrDefault(D => D.DeptId == 10);

            //if(department is not null)
            //{
            //    Console.WriteLine(department.DeptId);
            //    Console.WriteLine(department.DeptName);
            //    Console.WriteLine("=====================");

            //    dbContext.Entry(department).Collection(D => D.Employees)
            //                         .Query()
            //                         .Where(E=>E.Age>26)
            //                         .Load();
            //    foreach(var employee in department.Employees)
            //    {
            //        Console.WriteLine(employee.EmpName);
            //    }
            //}
            #endregion
            #region Lazy Loading

            //var emp01 = dbContext.Employees.FirstOrDefault(E => E.EmpId == 40);

            //if(emp01 is not null)
            //{
            //    Console.WriteLine($"Employee Name :{emp01.EmpName}");
            //    Console.WriteLine($"Employee Department Id :{emp01.DepartmentWorkingId}");
            //    Console.WriteLine($"Employee Department Name :{emp01.WorkingDepartment?.DeptName}");  //second Select sent here
            //}


            //var department = dbContext.Departments.FirstOrDefault(D => D.DeptId == 10);  //first request


            //foreach(var employee in department.Employees)
            //{
            //    Console.WriteLine(employee.EmpName);
            //} 
            #endregion

            #endregion

            #endregion

            #region LINQ Joins

            #region Join()-Inner Join
            //var departmentsWithEmployees = dbContext.Departments.Join(dbContext.Employees
            //                                                         , D => D.DeptId
            //                                                         , E => E.DepartmentWorkingId
            //                                                         , (d, e) => new
            //                                                         {
            //                                                             d.DeptId,
            //                                                             d.DeptName,
            //                                                             e.EmpId,
            //                                                             e.EmpName
            //                                                         });

            //var departmentsWithEmployees = from D in dbContext.Departments
            //                               join E in dbContext.Employees
            //                               on D.DeptId equals E.DepartmentWorkingId
            //                               select new
            //                               {
            //                                   D.DeptId,
            //                                   D.DeptName,
            //                                   E.EmpId,
            //                                   E.EmpName
            //                               };


            //foreach (var item in departmentsWithEmployees)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion



            #region GroupJoin()

            //left join +order by departmentId
            //            SELECT[d].[DeptId], [d].[CreationDate], [d].[DeptManagerId], [d].[DepartmentName], [e].[EmpId], [e].[Age], [e].[CreationDate], [e].[DepartmentWorkingId], [e].[Email], [e].[EmployeeName], [e].[Password], [e].[Phone], [e].[Salary], [e].[SupervisorId], [e].[EmployeeCity], [e].[EmployeeCountry], [e].[EmployeeStreet]
            //FROM[Sales].[DepartmentsTable] AS[d]
            //LEFT JOIN[EmployeesTable] AS[e] ON[d].[DeptId] = [e].[DepartmentWorkingId]
            //ORDER BY[d].[DeptId]

            //var result = from D in dbContext.Departments
            //             join E in dbContext.Employees
            //             on D.DeptId equals E.DepartmentWorkingId
            //             into Employees
            //             select new
            //             {
            //                 Department = D,
            //                 Employees
            //             };


            //var result = dbContext.Departments.GroupJoin(dbContext.Employees
            //                                                , D => D.DeptId
            //                                                , E => E.DepartmentWorkingId
            //                                                , (D, Employees) => new
            //                                                {
            //                                                    Department = D,
            //                                                    CountOfEmployees=Employees.Count(),
            //                                                    SumOfSalaries=Employees.Sum(E=>E.Salary),
            //                                                    Employees
            //                                                });


            //foreach (var group in result)
            //{
            //    Console.WriteLine($"{group.Department.DeptId}--{group.Department.DeptName}--{group.CountOfEmployees}--{group.SumOfSalaries}");

            //    Console.WriteLine("============================");
            //    foreach(var employee in group.Employees)
            //    {
            //        Console.WriteLine($"Employee Name :{employee.EmpName}");
            //    }

            //    Console.WriteLine();
            //} 
            #endregion


            #region Left Join()


            //var result = dbContext.Departments.LeftJoin(dbContext.Employees, D => D.DeptId, E => E.DepartmentWorkingId, (D, E) => new
            //{
            //    DepartmentName = D.DeptName,
            //    EmployeeName = E.EmpName == null ? "No Employee" : E.EmpName
            //});

            //foreach(var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //            SELECT[d].[DepartmentName], CASE
            //    WHEN[e].[EmployeeName] IS NULL THEN 'No Employee'
            //    ELSE[e].[EmployeeName]
            //END AS[EmployeeName]
            //FROM[Sales].[DepartmentsTable] AS[d]
            //LEFT JOIN[EmployeesTable] AS[e] ON[d].[DeptId] = [e].[DepartmentWorkingId] 
            #endregion

            #endregion

            #region Local , Load(), Find()

            //var employees = dbContext.Employees;

            //foreach(var employee in employees)
            //{
            //    Console.WriteLine(employee.EmpName);
            //}

            ////    SELECT[e].[EmpId], [e].[Age], [e].[CreationDate], [e].[DepartmentWorkingId], [e].[Email], [e].[EmployeeName], [e].[Password], [e].[Phone], [e].[Salary], [e].[SupervisorId], [e].[EmployeeCity], [e].[EmployeeCountry], [e].[EmployeeStreet]
            ////FROM[EmployeesTable] AS[e]


            //Console.WriteLine("==============");


            //var filteredEmployees = dbContext.Employees.Local.Where(E => E.Age > 25);

            //foreach(var employee in filteredEmployees)
            //{
            //    Console.WriteLine(employee.EmpName);
            //}




            //var employees = dbContext.Employees.ToList();

            //foreach(var employee in employees)
            //{
            //    Console.WriteLine(employee.EmpName);
            //}

            ////    SELECT[e].[EmpId], [e].[Age], [e].[CreationDate], [e].[DepartmentWorkingId], [e].[Email], [e].[EmployeeName], [e].[Password], [e].[Phone], [e].[Salary], [e].[SupervisorId], [e].[EmployeeCity], [e].[EmployeeCountry], [e].[EmployeeStreet]
            ////FROM[EmployeesTable] AS[e]


            //Console.WriteLine("==============");


            //var filteredEmployees = employees.Where(E => E.Age > 25);

            //foreach(var employee in filteredEmployees)
            //{
            //    Console.WriteLine(employee.EmpName);
            //}

            // SELECT[e].[EmpId], [e].[Age], [e].[CreationDate], [e].[DepartmentWorkingId], [e].[Email], [e].[EmployeeName], [e].[Password], [e].[Phone], [e].[Salary], [e].[SupervisorId], [e].[EmployeeCity], [e].[EmployeeCountry], [e].[EmployeeStreet]
            //FROM[EmployeesTable] AS[e]
            //WHERE[e].[Age] > 25




            // local : property inside any DBSet => will make you hold local collection [RAM]


            //var employees = dbContext.Employees;

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee.EmpName);
            //}

            //    SELECT[e].[EmpId], [e].[Age], [e].[CreationDate], [e].[DepartmentWorkingId], [e].[Email], [e].[EmployeeName], [e].[Password], [e].[Phone], [e].[Salary], [e].[SupervisorId], [e].[EmployeeCity], [e].[EmployeeCountry], [e].[EmployeeStreet]
            //FROM[EmployeesTable] AS[e]


            //dbContext.Employees.Load();


            //Console.WriteLine("==============");


            //var filteredEmployees = dbContext.Employees.Local.Where(E => E.Age > 25);

            //foreach (var employee in filteredEmployees)
            //{
            //    Console.WriteLine(employee.EmpName);
            //}



            //dbContext.Employees.Where(E => E.DepartmentWorkingId == 10).Load();



            //var filteredEmployees = dbContext.Employees.Local.Where(E => E.Salary > 5000);

            //foreach(var employee in filteredEmployees)
            //{
            //    Console.WriteLine(employee.EmpName);
            //}




            //dbContext.Employees.Load();


            ////var emp01 = dbContext.Employees.Local.FirstOrDefault(E => E.EmpId == 40);

            ////Console.WriteLine(emp01.EmpName);

            //var emp01 = dbContext.Employees.Find(40);
            ////first it will search for emp its Id ==40  IN RAM
            //// Send request to DB to find Employee with Id =40
            //// retreive in app [Loaded in RAM]

            //Console.WriteLine(emp01.EmpName); 
            #endregion 
            #endregion



        }
    }

}



