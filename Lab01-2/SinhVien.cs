using System;
using System.Collections.Generic;
using System.Linq;

class SinhVien
{
    public string MaSo { get; set; }
    public string HoTen { get; set; }
    public string Khoa { get; set; }
    public double DTB { get; set; }

    public SinhVien(string maSo, string hoTen, string khoa, double dtb){
        MaSo = maSo;
        HoTen = hoTen;
        Khoa = khoa;
        DTB = dtb;
    }

    public SinhVien() { }

    public void addSV(){
        Console.Write("Nhap MSSV: ");
        this.MaSo = Console.ReadLine();

        Console.Write("Nhap ho ten SV: ");
        this.HoTen = Console.ReadLine();

        Console.Write("Nhap khoa: ");
        this.Khoa = Console.ReadLine();

        Console.Write("Nhap diem trung binh: ");
        double diemTrungBinh;
        while (!double.TryParse(Console.ReadLine(), out diemTrungBinh)){
            Console.Write("Diem khong hop le. Vui long nhap lai: ");
        }
        this.DTB = diemTrungBinh;
    }

    public void outSV(){
        Console.WriteLine("MSSV: {0}, Ho Ten: {1}, Khoa: {2}, DTB: {3}", this.MaSo, this.HoTen, this.Khoa, this.DTB);
    }
}
