using Business_DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PresentationDVLD_ConsoleApp
{
    internal class Program
    {

        static void AddNewPerson()
        {
            clsPerson Person1 = new clsPerson();
            Person1.NationalNo = "n20";
            Person1.FirstName = "Eassen";
            Person1.SecondName = "Ramy";
            Person1.ThirdName = "";
            Person1.LastName = "Alalmane";
            Person1.Address = "Madrid";
            Person1.Email = "easen.@Gmail.com";
            Person1.BirthDay = new DateTime(1990, 2, 1);
            Person1.Gendor = true;
            Person1.Phone = "2228";
            Person1.NationalCountryID = 2;

            if (Person1.Save())
            {
                Console.WriteLine("Added is Secssfuly ");
            }
            else
            {
                Console.WriteLine("Added is Failed");
            }



        }
        static void Find(int ID)
        {
            clsPerson Person1 = clsPerson.Find(ID);

            if (Person1 != null)
            {
                Console.WriteLine("ID                : {0}", Person1.PersonID);
                Console.WriteLine("FirstName         : {0}", Person1.FirstName);
                Console.WriteLine("SecondName        : {0}", Person1.SecondName);
                Console.WriteLine("ThirdName         : {0}", Person1.ThirdName);
                Console.WriteLine("LastName          : {0}", Person1.LastName);
                Console.WriteLine("BirthDay          : {0}", Person1.BirthDay);
                Console.WriteLine("Gendor            : {0}", Person1.Gendor);
                Console.WriteLine("Address           : {0}", Person1.Address);
                Console.WriteLine("Phone             : {0}", Person1.Phone);
                Console.WriteLine("Email             : {0}", Person1.Email);
                Console.WriteLine("NationalCountryID : {0}", Person1.NationalCountryID);
                Console.WriteLine("ImagePath         : {0}", Person1.ImagePath);
            }
            else
            {
                Console.WriteLine("ID is not found ");
            }


        }
        static void UpdatePerson()
        {
            clsPerson Person1 = clsPerson.Find(1033);

            if (Person1 != null)
            {
                Person1.FirstName = "Mohsen";
                Person1.SecondName = "Easen";
                Person1.ThirdName = "";
                Person1.LastName = "jon";
                Person1.BirthDay = new DateTime(1980, 5, 2, 4, 20, 0);
                Person1.Gendor = false;
                Person1.Address = "Madrid";
                Person1.Phone = "20202020";
                Person1.Email = "Mohsen@gmail.com";
                Person1.NationalCountryID = 15;
                Person1.ImagePath = "";

                if (Person1.Save())
                {
                    Console.WriteLine("Updated Successfully");
                }
                else
                {
                    Console.WriteLine("Update failed");
                }


            }
            else
            {
                Console.WriteLine("ID not found ,Update failed");
            }

        }

        static void GetAllPeople()
        {
            DataTable dt = clsPerson.GetAllPeople();

            Console.WriteLine("list people");

            foreach (DataRow row in dt.Rows)
            {

                Console.WriteLine($"{row["PersonID"]}, {row["FirstName"]}, {row["SecondName"]}, {row["ThirdName"]},{row["LastName"]} {row["DateOfBirth"]}, {row["Gendor"]}," +
                    $"{row["Address"]}, {row["Phone"]}, {row["Email"]}, {row["NationalityCountryID"]}, {row["ImagePath"]}");
            }


        }

        static void DeletePerson()
        {
            if (clsPerson.Delete(1048))
            {
                Console.WriteLine("Delete Is Successfully ");
            }
            else
            {
                Console.WriteLine("Delete Is Failed ");
            }
        }

        //----------------Countries---------------------------

        static void GetAllCountries()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                Console.WriteLine($"{row["CountryID"]}, {row["CountryName"]}");
            }


        }


        //----------------Users---------------------------

        static void AddNewUsers()
        {
            clsUser User1 = new clsUser();
            User1.PersonID = 1;
            User1.UserName = "Abdulrhman";
            User1.Password = "1234";

            if (User1.Save())
            {
                Console.WriteLine("Saved Is Successfully");
            }
            else
            {
                Console.WriteLine("Saved Is Failed");
            }


        }

        static void FindUser()
        {
            clsUser User1 = clsUser.Find(21);
            if (User1 != null)
            {
                Console.WriteLine($"{User1.UserID}");
                Console.WriteLine($"{User1.PersonID}");
                Console.WriteLine($"{User1.UserName}");
                Console.WriteLine($"{User1.Password}");
                Console.WriteLine($"{User1.IsActive}");
            }
            else
            {
                Console.WriteLine("User Is Not Found");
            }

        }

        static void UpdateUser()
        {
            clsUser User1 = clsUser.Find(15);
            if (User1 != null)
            {
                User1.PersonID = 1026;
                User1.UserName = "Easer";
                User1.Password = "1111";
                User1.IsActive = false;

                if (User1.Save())
                {
                    Console.WriteLine("Update Is Successfully");
                }
                else
                {
                    Console.WriteLine("Update Is Failed");
                }


            }
            else
            {
                Console.WriteLine("User Is Not Found");
            }


        }


        static void GetAllUsers()
        {
            DataTable dtUsers =clsUser.GetAllUsers();

            foreach (DataRow dr in dtUsers.Rows)
            {
                Console.WriteLine($"{dr["UserID"]}, {dr["PersonID"]}, {dr["UserName"]}, {dr["Password"]},{dr["IsActive"]}");
            }


        }

        static void GetPassword()
        {
            string Password = clsUser.GetPassword(1);

            Console.WriteLine("Password Is : " + Password);

        }

        static void CheckUserInfoAndIsActive()
        {
            string UserName = "Aspi";
            string Password = "9999";
         //   string Password = "999";

            if (clsUser.CheckUserInfo(UserName,Password))
            {
                Console.WriteLine(UserName + " : Found And Active ");
            }
            else
            {
                Console.WriteLine(UserName + " : Username or password is incorrect ");
            }
        }


        static void FindUserByUserNameAndPassword()
        {
            clsUser User = clsUser.Find("Aspi","9999");
            //  clsUser User = clsUser.Find("Aspi", "999");
            if (User != null)
            {
                Console.WriteLine("User Name : " + User.UserName);
                Console.WriteLine("Password  : " + User.Password);
                Console.WriteLine("Person ID : " + User.PersonID);
                Console.WriteLine("Is Active : " + User.IsActive);
            }
            else
            {
                Console.WriteLine("User is NOT Found ");
            }

        }



        //----------------ApplicationsType---------------------------

        static void GetAllApplicatins()
        {
            DataTable dtApplications = clsApplicationTypes.GetAllApplications();

            foreach (DataRow dr in dtApplications.Rows)
            {
                Console.WriteLine($"{dr["ApplicationTypeID"]}, {dr["ApplicationTypeTitle"]}, {dr["ApplicationFees"]}");
            }


        }

        static void FindApp()
        {
            clsApplicationTypes App = clsApplicationTypes.Find(1);
            if (App != null)
            {
                Console.WriteLine("App ID : "+App.ApplicationID);
                Console.WriteLine("App Title : " + App.ApplicationTitle);
                Console.WriteLine("App Fees : " + App.Fees);
            }


        }

        static void UpdateApplication()
        {
            clsApplicationTypes App = clsApplicationTypes.Find(2);
            if (App != null)
            {

                //    App.ApplicationTitle = "Renew Driving License Service 22 ";
                //  App.Fees = 10;

                App.ApplicationTitle = "Renew Driving License Service";
                App.Fees = 5;

                if (App.Update())
                {
                    Console.WriteLine("Update is Sucssffly");
                }
                else
                {
                    Console.WriteLine("Update is Faild");
                }


            }

        }

        static void GetFeesAppTypeByID()
        {
            decimal fees = clsApplicationTypes.GetApplicationTypeFeesByID(3);
          //  decimal fees = clsApplicationTypes.GetApplicationTypeFeesByID(26);
            if( fees != -1)
            {
                Console.WriteLine("Fees is : " + fees);
            }
            else
            {
                Console.WriteLine("Application Type is not found " + fees);
            }
           


        }



        //----------------TestType---------------------------

        static void GetAllTestTypes()
        {
            DataTable dtTests = clsTest.GetAllTests();

            foreach (DataRow dr in dtTests.Rows)
            {
                Console.WriteLine($"{dr["TestTypeID"]}, {dr["TestTypeTitle"]}, {dr["TestTypeDescription"]},{dr["TestTypeFees"]}");
                Console.WriteLine();
                Console.WriteLine();
            }
            
        }

        static void FindTest()
        {
            clsTest Test = clsTest.Find(1);
            if (Test != null)
            {
                Console.WriteLine("Test ID : " + Test.TestTypeID);
                Console.WriteLine("Test Title : " + Test.TestTypeTitle);
                Console.WriteLine("Test Desctription : " + Test.TestTypeDescription);
                Console.WriteLine();
                Console.WriteLine("Test Fees : " + Test.TestTypeFees);
            }

          

        }

        static void UpdateTest()
        {
            clsTest Test = clsTest.Find(1);
            if (Test != null)
            {
                //Test.TestTypeTitle = "Vision Test 2 ";
                //Test.TestTypeDescription = "This assesses the applicant's visual acuity to ensure they have sufficient vision to drive safely. 2";
                //Test.TestTypeFees = 20;

                Test.TestTypeTitle = "Vision Test";
                Test.TestTypeDescription = "This assesses the applicant's visual acuity to ensure they have sufficient vision to drive safely.";
                Test.TestTypeFees = 10;

                if (Test.Update())
                {
                    Console.WriteLine("Update is Sucssffly");
                }
                else
                {
                    Console.WriteLine("Update is Faild");
                }


            }

        }

        //----------------License Classes---------------------------

        static void GetAllLicenseClasses()
        {
            DataTable dtLicenseClasses = clsLicenseClasses.GetAllLicenseClass();

            foreach (DataRow dr in dtLicenseClasses.Rows)
            {
                Console.WriteLine($"{dr["LicenseClassID"]}, {dr["ClassName"]}, {dr["ClassDescription"]},{dr["MinimumAllowedAge"]}, {dr["DefaultValidityLength"]}, {dr["ClassFees"]}");
                Console.WriteLine();
                Console.WriteLine();
            }

        }



        //----------------Applications---------------------------

        static void AddApplication()
        {
            clsApplication NewApplication = new clsApplication();
            NewApplication.ApplicationPersonID = 2038;
            NewApplication.ApplicationTypeID = 1;
            NewApplication.ApplicationStatus = 1;
            NewApplication.ApplicationFees = 15;
            NewApplication.CreatedByUserID = 31;

          int  ApplicationID = NewApplication.AddNewApplication();

            if (ApplicationID != -1)
            {
                Console.WriteLine("Add Application is successfly");
            }
            else
            {
                Console.WriteLine("Add Application is Faild");
            }


        }

        static void UpdateStatus()
        {
            if (clsApplication.UpdateStatus(135,3))
            {
                Console.WriteLine("Update Status is Succssfly");
            }
            else
            {
                Console.WriteLine("UPdate Status is failed");
            }
        }


        static void GetAppInformationByID()
        {

            clsApplication AppInfo = clsApplication.GetApplicationInformaionByAppicationID(135);

            if(AppInfo != null)
            {
                
                Console.WriteLine(AppInfo.ApplicationID);
                Console.WriteLine(AppInfo.ApplicationDate.ToString());
                Console.WriteLine(AppInfo.ApplicationStatus);
                Console.WriteLine(AppInfo.LastStatusDate);
                Console.WriteLine(AppInfo.ApplicationFees);
                Console.WriteLine(AppInfo.FullNamePerson);
                Console.WriteLine(AppInfo.ApplicationTypeName);
                Console.WriteLine(AppInfo.CreatedByUserName);

            }
            else
            {
                Console.WriteLine("No Found");
            }

        }


        //----------------Local Driving License Applications---------------------------
        static void GetApplicationID_ByPersonID_And_LicenseClassID()
        {
            int AppID = clsLocalDrivingLicenseApplication.GetApplicationID_ByPersonID_And_LicenseClassID(1025, 2);
            if (AppID != -1)
            {
                Console.WriteLine("AppID : " + AppID);
            }
            else
            {
                Console.WriteLine("App is not found ");
            }


        }

        //static void AddLocalDrivingLicenseApplications()
        //{
        //    clsLocalDrivingLicenseApplication LDLApp = new clsLocalDrivingLicenseApplication();

        //    int LDLAppID = LDLApp.AddLocalDrivingLicenseApplications(123,2);
        //    if(LDLAppID != -1 )
        //    {
        //        Console.WriteLine("Add Local Driving License Applications is successfly");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Add Local Driving License Applications is Faild");
        //    }

        //}


        static void GetPersonIDByLLDAppID()
        {
            int PersonID = clsLocalDrivingLicenseApplication.GetPersonIDByLDLAppID(44);
            Console.WriteLine("Person ID : " + PersonID);


        }





        //----------------TestAppointment---------------------------




        static void GetTestAppointmentInfoByPersonID()
        {
            clsTestAppointment TestAppo = clsTestAppointment.GetTestAppointmentsByPersonID(1);

            if(TestAppo != null )
            {
                Console.WriteLine(TestAppo.AppointmentID);
                Console.WriteLine(TestAppo.AppointmentDate);
                Console.WriteLine(TestAppo.PaidFees);
                Console.WriteLine(TestAppo.IsLocked);


            }
            else
            {
                Console.WriteLine("The Person is has any Test Appointment ");
            }

        }

        static void GetAllTestAppointmentByPersonID()
        {
            DataTable dtTestApp = clsTestAppointment.GetAllTestAppointmentsByPersonID(1);

            foreach (DataRow dr in dtTestApp.Rows)
            {
                Console.WriteLine($"{dr["TestAppointmentID"]}, {dr["AppointmentDate"]}, {dr["PaidFees"]}, {dr["IsLocked"]}");
            }
          
        }






        static void Main(string[] args)
        {

            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            CultureInfo.CurrentUICulture = new CultureInfo("en-US");
            // Find(1);

            // Find(1030);
            // AddNewPerson();


            // UpdatePerson();

            // GetAllPeople();
            // GetAllCountries();

            // DeletePerson();

            // AddNewUsers();
            // FindUser();

            // UpdateUser();

            //    GetAllUsers();

            //  GetPassword();

            // CheckUserInfoAndIsActive();

            //  FindUserByUserNameAndPassword();


            //  GetAllApplicatins();
            //  FindApp();

            //   UpdateApplication();


            //   GetAllTestTypes();
            // FindTest();

            // UpdateTest();


            //    GetAllLicenseClasses();

            //   GetFeesAppTypeByID();

            //AddApplication();
            // AddLocalDrivingLicenseApplications();

            //  GetApplicationID_ByPersonID_And_LicenseClassID();

            //  UpdateStatus();
            //    GetAppInformationByID();

            //   GetTestAppointmentInfoByPersonID();

            //  GetAllTestAppointmentByPersonID();

            GetPersonIDByLLDAppID();



        }
    }
}

