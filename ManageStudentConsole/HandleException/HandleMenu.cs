using ManageStudentConsole.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudentConsole.HandleException
{
    internal class HandleMenu
    {
        StudentRepository studentRepo = new StudentRepository();

        public HandleMenu() { }
        public int InputNumber()
        {
            int numberChoice;
            while (true)
            {
                Console.Write("Nhập lựa chọn (0-6): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out numberChoice) && numberChoice >= 0 && numberChoice <= 6)
                {
                    return numberChoice;
                }
                Console.WriteLine("Vui lòng nhập số trong khoảng từ 0 đến 6.");
            }
        }


        public string InputString()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("Y", StringComparison.OrdinalIgnoreCase) ||
                    input.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    return input.ToUpper();
                }
                Console.WriteLine("Vui lòng nhập Y hoặc N.");
            }
        }


        public void handleContinueProgram(int numberChoice)
        {
            while (numberChoice != 0)
            {
                SelectFunction(numberChoice);
                Console.WriteLine("Bạn có muốn tiếp tục không ? (Y/N)");
                string choice = InputString();
                if (choice.Equals("Y"))
                {
                    ShowMenu();
                    numberChoice = InputNumber();
                }
                else
                {
                    Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                    return;
                }

            }
        }

        public void SelectFunction(int numberChoice)
        {
            switch (numberChoice)
            {
                case 1:
                    studentRepo.Show();
                    break;

                case 2:
                    studentRepo.Add();
                    break;
                case 3:
                    Console.WriteLine("Nhập MSSV muốn thay đổi: ");
                    studentRepo.Update();
                    break;
                case 4:
                    Console.WriteLine("Nhập MSSV muốn xóa: ");
                    if (studentRepo.Delete())
                    {
                        Console.WriteLine("Đã xóa thành công sinh viên");
                    }
                    break;
                case 5:
                    studentRepo.SortByName();
                    break;
                case 6:
                    studentRepo.DisplayFindById();
                    break;
                case 0:
                    Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                    break;
            }
        }

        public void ShowMenu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write(new String('-', 20));
            Console.Write("***");
            Console.Write(new String('-', 20));
            Console.WriteLine();
            Console.WriteLine("DANH SÁCH CHỨC NĂNG QUẢN LÝ SINH VIÊN");
            Console.WriteLine("1. Xem danh sách sinh viên");
            Console.WriteLine("2. Thêm mới sinh viên");
            Console.WriteLine("3. Chỉnh sửa thông tin sinh viên");
            Console.WriteLine("4. Xóa sinh viên");
            Console.WriteLine("5. Sắp xếp dữ liệu sinh viên theo tên");
            Console.WriteLine("6. Tìm kiếm sinh viên theo Mã số sinh viên");
            Console.WriteLine("0. Kết thúc chương trình");
            Console.Write(new String('-', 20));
            Console.Write("***");
            Console.Write(new String('-', 20));
            Console.WriteLine();
        }
    }
}
