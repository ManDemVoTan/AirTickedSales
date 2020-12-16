using AirTickedSales.Data.Extensions;
using AirTickedSales.ViewModel.Catalog.System.Timekeeping;
using Microsoft.AspNetCore.Mvc;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static AirTickedSales.Data.Entities.TimeKeeping;

namespace AirTickedSales.BackEndWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeKeepingsController : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> OnPostUploadAsync([FromForm] TimeKeepingImport model)
        {
            var template = "ListTimeKeepingError.xlsx";
            var directoryBase = Directory.GetCurrentDirectory();
            var folder = Path.Combine(directoryBase, "wwwroot", "upload", "excelTemplate");
            foreach(var formFile in model.file)
            {
                var wb = new XSSFWorkbook(formFile.OpenReadStream());
                var sheet = wb.GetSheetAt(0);
                int? dayOfMonth;
                int month;
                int year;
                var RowDeparment = sheet.GetRow(0);
                var Deparmentvalue = RowDeparment.GetCell(0).ToString();
                if (!string.IsNullOrEmpty(Deparmentvalue))
                {
                    Deparmentvalue.Substring(0, 8);
                }
                var rowDate = sheet.GetRow(3);
                var contentDate = rowDate.GetCell(0).ToString();
                var RowDeparment2 = sheet.GetRow(7);
                var Deparment2value = RowDeparment2.GetCell(0).ToString();
                if (!string.IsNullOrEmpty(contentDate))
                {
                    string replace = contentDate.Replace(" ", "").Substring(6, 10);
                    DateTime olDate = Convert.ToDateTime(replace);
                    month = olDate.Month;
                    year = olDate.Year;
                    dayOfMonth = DateTime.DaysInMonth(year, month);
                }else
                {
                    return BadRequest(contentDate);
                }
                var lastRows = sheet.LastRowNum;
                var rowIndex = 8;
                var listInput = new List<TimeKeepingViewModel>();
                var listSuccess = new List<TimeKeepingViewModel>();
                var listError = new List<TimeKeepingViewModel>();
                for (int i = rowIndex; i < lastRows; i+=2)
                {
                    var nowRow = sheet.GetRow(i);
                    var nowRow2 = sheet.GetRow(i + 2);
                    var UserCode = nowRow.GetCell(1).ToString();
                    var UserName = nowRow.GetCell(2).ToString();
                    var Type = nowRow.GetCell(3).ToString();
                    var array = new List<DataCheckTime>();
                    for (int k = 1; k < dayOfMonth; k++)
                    {
                        var record = new DataCheckTime
                        {
                            Day = k,
                            Type = nowRow
                            CheckIn = nowRow.GetCell(k + 3).ToString(),
                            CheckOut = nowRow2.GetCell(k + 3).ToString()
                        };
                        array.Add(record);

                    }

                }

            }


            return Ok();

        }

    }
}