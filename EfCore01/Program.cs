using EfCore01.Contexts;
using EfCore01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace EfCore01
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using CompanyDbContext dbContext = new CompanyDbContext();
            //using CompanyDbContext dbContext01 = new CompanyDbContext();

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





        }

            #endregion




            #endregion


    }




}
    
        

