using System;
using System.Collections.Generic;

class Program
{
    static List<SinhVien> dsSV = new List<SinhVien>();

    static void Main(string[] args)
    {
        testData(); 
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("==MENU==");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Xuat danh sach sinh vien");
            Console.WriteLine("3. Xuat SV thuoc khoa CNTT");
            Console.WriteLine("4. Xuat SV co DTB >= 5");
            Console.WriteLine("5. Sap xep SV theo DTB tang dan");
            Console.WriteLine("6. Xuat SV co DTB >= 5 va thuoc khoa CNTT");
            Console.WriteLine("7. Xuat SV co DTB cao nhat va thuoc khoa CNTT");
            Console.WriteLine("8. Thong ke xep loai SV");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon chuc nang (0-8): ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    addSVList();
                    break;
                case "2":
                    outSVList();
                    break;
                case "3":
                    outSVCNTT();
                    break;
                case "4":
                    outSVDTB5();
                    break;
                case "5":
                    sortSVDTB();
                    break;
                case "6":
                    outSVDTB5CNTT();
                    break;
                case "7":
                    outSVCNTTMaxDTB();
                    break;
                case "8":
                    countRankSV();
                    break;
                case "0":
                    Console.WriteLine("Ket thuc chuong trinh.");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                    break;
            }
            Console.WriteLine();
        }
    }

    static void testData()
    {
        dsSV.Add(new SinhVien("SV001", "Nguyen Van A", "CNTT", 8.5));
        dsSV.Add(new SinhVien("SV002", "Le Thi B", "Dien", 6.0));
        dsSV.Add(new SinhVien("SV003", "Tran Van C", "CNTT", 9.2));
        dsSV.Add(new SinhVien("SV004", "Pham Thi D", "Kinh te", 4.5));
        dsSV.Add(new SinhVien("SV005", "Nguyen Van E", "CNTT", 7.8));
        dsSV.Add(new SinhVien("SV006", "Hoang Thi F", "Dien", 9.2));
        dsSV.Add(new SinhVien("SV007", "Vu Van G", "CNTT", 3.1));
        dsSV.Add(new SinhVien("SV008", "Dao Thi H", "Kinh te", 5.0));
    }

    static void addSVList()
    {
        Console.WriteLine("===Nhap thong tin sinh vien==");
        SinhVien sv = new SinhVien();
        sv.addSV();
        dsSV.Add(sv);
        Console.WriteLine("Them sinh vien thanh cong!");
    }

    static void outSVList()
    {
        Console.WriteLine("===Danh sach chi tiet sinh vien===");
        foreach (var sv in dsSV)
        {
            sv.outSV();
        }
    }

    //Xuat ra thong tin cac SV thuoc khoa CNTT
    static void outSVCNTT()
    {
        Console.WriteLine("===Danh sach sinh vien khoa CNTT===");
        var cnttStudents = dsSV.Where(sv => sv.Khoa.Equals("CNTT", StringComparison.OrdinalIgnoreCase)).ToList();
        foreach (var sv in cnttStudents)
        {
            sv.outSV();
        }
    }

    //Xuat ra thong tin sv co dtb >= 5
    static void outSVDTB5()
    {
        Console.WriteLine("===Danh sach sinh vien co DTB >= 5===");
        var students = dsSV.Where(sv => sv.DTB >= 5.0).ToList();
        foreach (var sv in students)
        {
            sv.outSV();
        }
    }

    //Xuat ra dssv sap xep theo dtb tang dan
    static void sortSVDTB()
    {
        Console.WriteLine("===Danh sach sinh vien sap xep theo DTB tang dan===");
        var sortedStudents = dsSV.OrderBy(sv => sv.DTB).ToList();
        foreach (var sv in sortedStudents)
        {
            sv.outSV();
        }
    }

    // dssv co DTB >=5 va thuoc khoa CNTT
    static void outSVDTB5CNTT()
    {
        Console.WriteLine("===Danh sach sinh vien khoa CNTT co DTB >= 5===");
        var students = dsSV.Where(sv => sv.DTB >= 5.0 && sv.Khoa.Equals("CNTT", StringComparison.OrdinalIgnoreCase)).ToList();
        foreach (var sv in students)
        {
            sv.outSV();
        }
    }

    //dssv co dtb cao nhat va thuoc khoa CNTT
    static void outSVCNTTMaxDTB()
    {
        Console.WriteLine("===Sinh vien khoa CNTT co DTB cao nhat===");
        var cnttStudents = dsSV.Where(sv => sv.Khoa.Equals("CNTT", StringComparison.OrdinalIgnoreCase)).ToList();
        var maxDTB = cnttStudents.Max(sv => sv.DTB);
        var topStudents = cnttStudents.Where(sv => sv.DTB == maxDTB).ToList();
        foreach (var sv in topStudents)
        {
            sv.outSV();
        }
    }

    static void countRankSV()
    {
        Console.WriteLine("===Thong ke xep loai sinh vien===");
        int xuatSacCount = 0;
        int gioiCount = 0;
        int khaCount = 0;
        int trungBinhCount = 0;
        int yeuCount = 0;
        int kemCount = 0;
        foreach (var sv in dsSV)
        {
            if (sv.DTB >= 9.0)
            {
                xuatSacCount++;
            }
            else if (sv.DTB >= 8.0)
            {
                gioiCount++;
            }
            else if (sv.DTB >= 7.0)
            {
                khaCount++;
            }
            else if (sv.DTB >= 5.0)
            {
                trungBinhCount++;
            }
            else if (sv.DTB >= 4.0)
            {
                yeuCount++;
            }
            else
            {
                kemCount++;
            }
        }

        Console.WriteLine("Xuat sac: {0} sinh vien", xuatSacCount);
        Console.WriteLine("Gioi: {0} sinh vien", gioiCount);
        Console.WriteLine("Kha: {0} sinh vien", khaCount);
        Console.WriteLine("Trung binh: {0} sinh vien", trungBinhCount);
        Console.WriteLine("Yeu: {0} sinh vien", yeuCount);
        Console.WriteLine("Kem: {0} sinh vien", kemCount);
    }
}
