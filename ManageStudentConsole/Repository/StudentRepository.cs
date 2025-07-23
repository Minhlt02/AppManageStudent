using ManageStudentConsole.DBHelper;
using ManageStudentConsole.Entity;
using ManageStudentConsole.HandleException;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudentConsole.Repository
{
    internal class StudentRepository : IFunctionRepository
    {
        public List<Students> listStudents;
        HandleFormatDate handleFormat = new HandleFormatDate();

        public StudentRepository()
        {

            listStudents = new List<Students>();
        }
        public void Add()
        {
            Students students = new Students();
            students._idStudent = GenerateID();
            Console.WriteLine("Nhập tên của sinh viên: ");
            students._name = Console.ReadLine();

            Console.WriteLine("Nhập ngày sinh của sinh viên (dd/mm/yyyy): ");
            students._birthday = handleFormat.HandleFormatBirthday();

            Console.WriteLine("Nhập địa chỉ của sinh viên: ");
            students._address = Console.ReadLine();

            Console.Write("Nhập ID lớp học: ");
            int classId = int.Parse(Console.ReadLine());
            Console.WriteLine("New student added successfully!");

            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    var classroom = session.Get<Classrooms>(classId);
                    if (classroom == null)
                    {
                        Console.WriteLine("Không tìm thấy lớp học với ID đã nhập.");
                        return;
                    }

                    // Gán classroom cho student
                    students._classrooms = classroom;
                    session.Save(students);
                    tx.Commit();
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                NHibernateHelper.CloseSession(session);
            }
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public Students FindById(int id)
        {
            Students students = null;

            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    var student = session.Get<Students>(id);
                    if (student == null)
                    {
                        Console.WriteLine("Không tìm thấy sinh viên với ID đã nhập.");
                    }
                    students = student;
                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                NHibernateHelper.CloseSession(session);
            }
            return students;
        }

        public int GenerateID()
        {
            int currentID = 1;

            if (listStudents.Count > 0 && listStudents != null)
            {
                currentID = listStudents[0]._idStudent;
                foreach (var student in listStudents)
                {
                    if (student._idStudent > currentID)
                    {
                        currentID = student._idStudent;
                    }
                }
                currentID++;
            }

            return currentID;
        }

        public void Show()
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                var studentList = session.Query<Students>().ToList();

                if (!studentList.Any())
                {
                    Console.WriteLine("No students found.");
                    return;
                }

                foreach (var student in studentList)
                {
                    Console.WriteLine("{0} {1} {2}", student._idStudent, student._name, student._address);
                }
            } catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving students: " + ex.Message);
            }
            finally
            {
                NHibernateHelper.CloseSession(session);

            }
        }

        public void SortByName()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            int studentID = int.Parse(Console.ReadLine());
            Students students = FindById(studentID);
            if (students != null)
            {
                Console.WriteLine("Nếu không muốn thay đổi hãy bỏ trống!");
                Console.WriteLine("Thay đổi tên của sinh viên: ");
                string name = Console.ReadLine();
                if (name != null && name.Length > 0)
                {
                    students._name = name;
                }

                Console.WriteLine("Thay đổi ngày sinh của sinh viên (Nhập 1 để bỏ qua hoặc bấm bất kỳ để thay đổi) : ");
                string skip = Console.ReadLine();
                if (skip.Equals("1"))
                {
                    students._birthday = students._birthday;
                }
                else
                {
                    Console.WriteLine("Nhập ngày sinh của sinh viên (dd/mm/yyyy): ");
                    DateTime date = handleFormat.HandleFormatBirthday();
                    if (date != null)
                    {
                        students._birthday = date;
                    }
                }


                Console.WriteLine("Thay đổi địa chỉ của sinh viên: ");
                string address = Console.ReadLine();
                if (address != null && address.Length > 0)
                {
                    students._address = address;
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy sinh viên!");
            }
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    //var classroom = session.Get<Classrooms>(classId);
                    //if (classroom == null)
                    //{
                    //    Console.WriteLine("Không tìm thấy lớp học với ID đã nhập.");
                    //    return;
                    //}

                    //// Gán classroom cho student
                    //students._classrooms = classroom;
                    session.Save(students);
                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                NHibernateHelper.CloseSession(session);
            }
        }
    }
}
