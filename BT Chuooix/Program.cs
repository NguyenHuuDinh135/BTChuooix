using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public double AverageScore { get; set; }
        public int Year { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Student> students = GenerateRandomStudents(50);
            Console.WriteLine($"Đã tạo ngẫu nhiên {students.Count} sinh viên.\n");

            // ==========================================
            // 1. MAX TUỔI, MIN TUỔI
            // ==========================================
            
            // [CÁCH 1 - HIỆU QUẢ NHẤT] Method Syntax: Gọi trực tiếp hàm tổng hợp, tối ưu hiệu suất.
            int maxAge = students.Max(s => s.Age);
            int minAge = students.Min(s => s.Age);

            // [CÁCH 2] Query Syntax: Phải bọc Query lại rồi mới gọi được hàm Max/Min.
            // int maxAge = (from s in students select s.Age).Max();
            // int minAge = (from s in students select s.Age).Min();

            // [CÁCH 3] Mixed Syntax: Sắp xếp bằng Query rồi lấy phần tử đầu/cuối (Cách này chạy rất chậm vì tốn chi phí sort).
            // int maxAge = (from s in students orderby s.Age descending select s.Age).FirstOrDefault();
            // int minAge = (from s in students orderby s.Age ascending select s.Age).FirstOrDefault();

            Console.WriteLine($"1. Tuổi lớn nhất: {maxAge} | Tuổi nhỏ nhất: {minAge}");
            Console.WriteLine("--------------------------------------------------");


            // ==========================================
            // 2. KIỂM TRA CÓ SV KHOA CNS
            // ==========================================
            
            // [CÁCH 1 - HIỆU QUẢ NHẤT] Method Syntax: Dùng Any() sẽ dừng duyệt danh sách ngay khi tìm thấy SV đầu tiên thỏa mãn.
            bool hasCNS = students.Any(s => s.Department == "CNS");

            // [CÁCH 2] Query Syntax + Any: Lọc bằng Query rồi kiểm tra, hơi rườm rà.
            // bool hasCNS = (from s in students where s.Department == "CNS" select s).Any();

            // [CÁCH 3] Mixed Syntax: Lấy ra danh sách các khoa rồi dùng Contains để kiểm tra.
            // bool hasCNS = (from s in students select s.Department).Contains("CNS");

            Console.WriteLine($"2. Có sinh viên khoa CNS không? -> {(hasCNS ? "Có" : "Không")}");
            Console.WriteLine("--------------------------------------------------");


            // ==========================================
            // 3. LẤY 10 SV CÓ ĐIỂM TB CAO NHẤT
            // ==========================================
            
            // [CÁCH 1 - HIỆU QUẢ NHẤT] Method Syntax: Viết theo chuỗi (Fluent API) rất mượt mà và dễ đọc.
            var top10Students = students.OrderByDescending(s => s.AverageScore).Take(10).ToList();

            // [CÁCH 2] Mixed Syntax: Dùng Query để sort, rồi bọc ngoặc dùng Method để Take (Do Query thuần không có từ khóa Take).
            // var top10Students = (from s in students orderby s.AverageScore descending select s).Take(10).ToList();

            // [CÁCH 3] Query Syntax thuần: Không thể thực hiện được lấy Top 10 chỉ bằng 100% Query Syntax trong C#. 
            // Cú pháp này bắt buộc phải kết hợp với Method Syntax như Cách 2.

            Console.WriteLine("3. Danh sách 10 SV có điểm trung bình cao nhất:");
            foreach (var s in top10Students)
            {
                Console.WriteLine($"   - {s.Name} | Khoa: {s.Department} | Điểm TB: {s.AverageScore:F2}");
            }
            Console.WriteLine("--------------------------------------------------");


            // ==========================================
            // 4. BỎ QUA SV NĂM CUỐI (NĂM 4) -> LẤY DS CÒN LẠI
            // ==========================================
            
            // [CÁCH 1 - HIỆU QUẢ NHẤT] Method Syntax: Ngắn gọn, đúng chuẩn Lambda expression của C# hiện đại.
            var remainingStudents = students.Where(s => s.Year != 4).ToList();

            // [CÁCH 2] Query Syntax: Cách viết truyền thống, dễ hiểu với người quen SQL.
            // var remainingStudents = (from s in students where s.Year != 4 select s).ToList();

            // [CÁCH 3] Mixed Syntax: Cố tình kết hợp Select của Query với Where của Method (Không khuyến khích vì thừa thãi).
            // var remainingStudents = (from s in students select s).Where(s => s.Year != 4).ToList();

            Console.WriteLine($"4. Danh sách SV sau khi bỏ qua năm cuối (Còn lại {remainingStudents.Count} SV):");
            foreach (var s in remainingStudents.Take(50)) 
            {
                Console.WriteLine($"   - {s.Name} | Năm học: {s.Year} | Tuổi: {s.Age}");
            }
            Console.WriteLine("   ... (Đã rút gọn hiển thị)");

            Console.ReadLine();
        }

        // Hàm tạo dữ liệu ảo
        static List<Student> GenerateRandomStudents(int count)
        {
            var random = new Random();
            var departments = new[] { "CNS", "CoDienTu", "KinhTe", "NgoaiNgu" };
            var list = new List<Student>();

            for (int i = 1; i <= count; i++)
            {
                list.Add(new Student
                {
                    Id = "SV" + i.ToString("D3"),
                    Name = "Sinh viên " + i,
                    Age = random.Next(18, 24),
                    Department = departments[random.Next(departments.Length)],
                    AverageScore = random.NextDouble() * 10,
                    Year = random.Next(1, 5)
                });
            }
            return list;
        }
    }
}