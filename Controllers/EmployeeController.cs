using Microsoft.AspNetCore.Mvc;
using ExportDemo.Models;
using Rotativa.AspNetCore;
using ClosedXML.Excel;
using System.IO;

namespace ExportDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private List<Employee> GetDummyData()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "Budi", Position = "Developer", Salary = 5000 },
                new Employee { Id = 2, Name = "Ani", Position = "Designer", Salary = 4500 },
                new Employee { Id = 3, Name = "Joko", Position = "Manager", Salary = 7000 },
            };
        }

        public IActionResult Index()
        {
            var data = GetDummyData();
            return View(data);
        }

        public IActionResult ExportPdf()
        {
            var data = GetDummyData();
            return new ViewAsPdf("Index", data)
            {
                FileName = "Employees.pdf"
            };
        }

        public IActionResult ExportExcel()
        {
            var data = GetDummyData();
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Employees");
            worksheet.Cell(1, 1).Value = "Id";
            worksheet.Cell(1, 2).Value = "Name";
            worksheet.Cell(1, 3).Value = "Position";
            worksheet.Cell(1, 4).Value = "Salary";

            int row = 2;
            foreach (var emp in data)
            {
                worksheet.Cell(row, 1).Value = emp.Id;
                worksheet.Cell(row, 2).Value = emp.Name;
                worksheet.Cell(row, 3).Value = emp.Position;
                worksheet.Cell(row, 4).Value = emp.Salary;
                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Employees.xlsx");
        }
    }
}
