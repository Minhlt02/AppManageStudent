using ManageStudentConsole.DBHelper;
using ManageStudentConsole.Entity;
using ManageStudentConsole.HandleException;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudentConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HandleMenu handle = new HandleMenu();
            handle.ShowMenu();

            int numberChoice = handle.InputNumber();
            handle.handleContinueProgram(numberChoice);
        }
    }
}
