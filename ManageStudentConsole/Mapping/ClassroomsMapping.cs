using FluentNHibernate.Mapping;
using ManageStudentConsole.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudentConsole.Mapping
{
    public class ClassroomsMapping : ClassMap<Classrooms>
    {
        public ClassroomsMapping() 
        {
            Id(x => x._id).Column("id").GeneratedBy.Identity();
            Map(x => x._idClassroom).Column("classroom_id");
            Map(x => x._nameClassroom).Column("classroom_name");
            Map(x => x._nameSubject).Column("classroom_subject");
            References(x => x._teacher, "teacher_id");
        }
    }
}
