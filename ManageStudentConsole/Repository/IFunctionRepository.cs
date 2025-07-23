using ManageStudentConsole.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudentConsole.Repository
{
    internal interface IFunctionRepository
    {
        int GenerateID();
        void Add();
        void Show();
        void Update();
        bool Delete();
        void SortByName();
 
    }
}
