using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudentConsole.Entity
{
    public class Teachers
    {
        public virtual int _idTeacher { get; set; }
        public virtual string _nameTeacher { get; set; }
        public virtual DateTime _birthdayTeacher { get; set; }

        public Teachers() { }

        public Teachers(int idTeacher, string nameTeacher, DateTime birthdayTeacher)
        {
            _idTeacher = idTeacher;
            _nameTeacher = nameTeacher;
            _birthdayTeacher = birthdayTeacher;
        }
    }
}
