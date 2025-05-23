# ExportDemo - ASP.NET Core MVC

Aplikasi sederhana untuk menampilkan daftar karyawan dan mengekspor data ke format PDF dan Excel.

## 📌 Deskripsi

Aplikasi ini dibuat sebagai bagian dari tes teknis Junior .NET Developer. Aplikasi berbasis ASP.NET Core MVC ini menyediakan fitur export data ke PDF menggunakan Rotativa dan ke Excel menggunakan ClosedXML.

## 🧰 Teknologi

- ASP.NET Core MVC
- Rotativa.AspNetCore (Export PDF)
- ClosedXML (Export Excel)
- Visual Studio Code / .NET CLI

## 🚀 Cara Menjalankan

```bash
dotnet restore
dotnet run
```

Buka browser dan akses:
http://localhost:5151/Employee

## 📁 Struktur Proyek
```
├── Controllers
│   └── EmployeeController.cs
├── Models
│   └── Employee.cs
├── Views
│   └── Employee
│       └── Index.cshtml
├── wwwroot
│   └── Rotativa (berisi wkhtmltopdf.exe)
├── Program.cs
├── ExportDemo.csproj
└── README.md

```
## 📤 Fitur
- Menampilkan data karyawan (dummy)
- Export ke PDF ```(/Employee/ExportPdf)```
- Export ke Excel ```(/Employee/ExportExcel)```

## 📌 Catatan
- File PDF menggunakan ```Rotativa```, pastikan ```wkhtmltopdf.exe``` tersedia di ```wwwroot/Rotativa```.
- Data masih hardcoded. Untuk tahap selanjutnya akan disambungkan ke database dengan stored procedure.
