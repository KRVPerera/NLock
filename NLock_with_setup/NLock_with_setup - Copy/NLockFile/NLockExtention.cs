using Associations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NLock
{
    class NLockExtention
    {

        public void test()
        {

            // Initializes a new AF_FileAssociator to associate the .ABC file extension.
            AF_FileAssociator assoc = new AF_FileAssociator(".nlk");

            // Creates a new file association for the .ABC file extension. Data is overwritten if it already exists.
            //assoc.AF_FileAssociatorCreate("My_App","My application's file association",new ProgramIcon(@"C:\Nlock\Lockicon.ico"),new ExecApplication(@"C:\Nlock\SimpleFacesSampleCS.exe"),new OpenWithList(new string[] { "My_App" }));
            assoc.Create("My_App", "My application's file association", new ProgramIcon(@"C:\Users\omdna\Desktop\Test\NLock_Native_NET\NLock\NLock\Resources\Lockicon.ico"), new ExecApplication(@"C:\Users\omdna\Desktop\Test\Iteration 2\NLockFile\NLockFile\bin\Win32_x86\NLockFile.exe"), new OpenWithList(new string[] { "My_App" }));
            //Console.ReadKey();

        }
    }
}
