using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudentConsole.Entity
{
    public class Classrooms
    {
        public virtual int _idClassroom { get; set; }
        public virtual string _nameClasroom { get; set; }
        public virtual string _nameSubject { get; set; }
        public virtual Teachers _teacher { get; set; }

        public Classrooms() { }

        public Classrooms(int id, string nameClasroom, string nameSubject, Teachers teachers)
        {
            this._idClassroom = id;
            this._nameClasroom = nameClasroom;
            this._nameSubject = nameSubject;
            this._teacher = teachers;
        }

        public override string ToString()
        {
            return $"{_nameClasroom}\t| {_nameSubject}\t| {_teacher._nameTeacher}";
        }
    }
}
