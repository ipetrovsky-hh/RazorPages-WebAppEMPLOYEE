using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Web.Http;
using System.Web.Http.Results;
using WebAppEMPLOYEE.Models;


namespace WebAppEMPLOYEE.Pages
{
    public class EmployeePage : PageModel
    {
        private readonly ILogger<EmployeePage> _logger;

        public EmployeePage(ILogger<EmployeePage> logger)
        {
            _logger = logger;
        }
        
        public void OnGet()
        {
            var len = "";
        }
        
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(@"File_json\\Employee.json"))
            {
                string json = r.ReadToEnd();
                List<EmployeeModel> EmployeeModel = JsonConvert.DeserializeObject<List<EmployeeModel>>(json);
            }
        }

        /*
         https://localhost:7170/EmployeePage?handler=StaticEmployees&id=3
         */
        public IActionResult OnGetStaticEmployees()
        {
            List<EmployeeModel> EModel = new List<EmployeeModel>();

            string fileFirst = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files_json", "Employee.json");

            using (StreamReader r = new StreamReader(fileFirst))
            {
                EModel = JsonConvert.DeserializeObject<List<EmployeeModel>>(r.ReadToEnd());
            }

            return new JsonResult(EModel);
        }
        /*
         * https://localhost:7170/EmployeePage?handler=StaticEmployeesByLN&id=text
         */
        public IActionResult OnGetStaticEmployeesByLN(string lastname)
        {
            List<EmployeeModel> EModel = new List<EmployeeModel>();

            EmployeeModel resultMethod;

            string fileFirst = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files_json", "Employee.json");

            using (StreamReader r = new StreamReader(fileFirst))
            {
                EModel = JsonConvert.DeserializeObject<List<EmployeeModel>>(r.ReadToEnd());

                resultMethod = EModel.Find(p => p.LastName == lastname); // Tom
            }

            return new JsonResult(resultMethod);
        }

        public IActionResult OnGetSaveEmployeeRow(string text, string LastName, string Name, string MiddleName, string WorkPlace)
        {
            List<EmployeeModel> EModel = new List<EmployeeModel>();

            EmployeeModel resultMethod;

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files_json", "Employee.json");

            string contextFile = System.IO.File.ReadAllText(filePath);

            string jsonOld = "";
            
            string jsonNew = "";

            using (StreamReader sw = new StreamReader(filePath))
            {
                EModel = JsonConvert.DeserializeObject<List<EmployeeModel>>(sw.ReadToEnd());

                resultMethod = EModel.Find(p => p.LastName == text); // Tom

                jsonOld = System.Text.Json.JsonSerializer.Serialize(resultMethod).ToString();

                if (resultMethod != null)
                {
                    if ((LastName is not null)&&(LastName != " "))
                    {
                        resultMethod.LastName = LastName;
                    }
                    
                    if ((Name is not null) && (Name != " "))
                    {
                        resultMethod.Name = Name;
                    }
                    
                    if ((MiddleName is not null) && (MiddleName != " "))
                    {
                        resultMethod.MiddleName = MiddleName;
                    }

                    if ((WorkPlace is not null) && (WorkPlace != " "))
                    { 
                        resultMethod.WorkPlace = WorkPlace;
                    }
                }

                jsonNew = System.Text.Json.JsonSerializer.Serialize(resultMethod).ToString();                        
            }

            // Выполняем замену

            contextFile = contextFile.Replace(" ", "");

            contextFile = contextFile.Replace("\r", "");
            contextFile = contextFile.Replace("\n", "");

            string modifiedContent = contextFile.Replace(jsonOld, jsonNew);

            System.IO.File.WriteAllText(filePath, modifiedContent);

            var result = new ResultActionModelcs("OK","Successful");

            return new JsonResult(result);
        }

        public IActionResult OnGetEmployees(string id)
        {
            EmployeeListModel EModel = new EmployeeListModel();

            EmployeeModel resultMethod;

            string fileFirst = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files_json", "EmployeeList.json");

            return new JsonResult(EModel);

        }
    }
}