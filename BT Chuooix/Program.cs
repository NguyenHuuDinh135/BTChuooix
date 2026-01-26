// See https://aka.ms/new-console-template for more information
/*Bài 1. Chuẩn hoá chuỗi họ tên
   
   Yêu cầu:
   
       Nhập vào một chuỗi họ tên (có thể dư khoảng trắng)
   
       Chuẩn hoá:
   
           Xoá khoảng trắng đầu/cuối
   
           Viết hoa chữ cái đầu mỗi từ
   
       Nếu chuỗi null hoặc rỗng → thông báo lỗi
   
   Yêu cầu kỹ thuật:
   
       Dùng string.IsNullOrWhiteSpace()
   
       Dùng Split(), Trim()
   
   Bài 2. Đếm số từ trong chuỗi
   
   Yêu cầu:
   
       Nhập chuỗi bất kỳ
   
       Đếm số từ trong chuỗi
   
       Nếu chuỗi null → in 0
   
   Ràng buộc:
   
       Không dùng LINQ (cho SV mới học)
   
       Phải kiểm tra null trước khi xử lý
   
   Bài 3. Kiểm tra chuỗi đối xứng
   
   Yêu cầu:
   
       Nhập một chuỗi
   
       Kiểm tra chuỗi có phải đối xứng không (bỏ qua khoảng trắng)
   
       Nếu chuỗi null → kết luận không đối xứng*/

Console.WriteLine("Bai 1 ");
Console.Write("Nhap ho ten: ");
string fullName = Console.ReadLine();

if (string.IsNullOrWhiteSpace(fullName))
{
    Console.WriteLine("Loi: Chuoi null hoac rong!");
}
else
{
    fullName = fullName.Trim();
    string[] words = fullName.Split(' ');
    string result = "";

    foreach (string word in words)
    {
        if (word != "")
        {
            string w = word.ToLower();
            result += char.ToUpper(w[0]) + w.Substring(1) + " ";
        }
    }

    Console.WriteLine("Ho ten chuan hoa: " + result.Trim());
}


Console.WriteLine("Bai 2");
Console.Write("Nhap chuoi: ");
string input = Console.ReadLine();

if (input == null)
{
    Console.WriteLine("So tu: 0");
}
else
{
    input = input.Trim();
    if (input == "")
    {
        Console.WriteLine("So tu: 0");
    }
    else
    {
        string[] words = input.Split(' ');
        int count = 0;

        foreach (string word in words)
        {
            if (word != "")
                count++;
        }

        Console.WriteLine("So tu: " + count);
    }
}


Console.WriteLine("Bai 3");
Console.Write("Nhap chuoi: ");
string str = Console.ReadLine();

if (str == null)
{
    Console.WriteLine("Chuoi KHONG doi xung");
}
else
{
    string s = "";

    foreach (char c in str)
    {
        if (c != ' ')
            s += c;
    }

    bool doiXung = true;
    int left = 0;
    int right = s.Length - 1;

    while (left < right)
    {
        if (s[left] != s[right])
        {
            doiXung = false;
            break;
        }
        left++;
        right--;
    }

    if (doiXung)
        Console.WriteLine("Chuoi DOI XUNG");
    else
        Console.WriteLine("Chuoi KHONG doi xung");
}
