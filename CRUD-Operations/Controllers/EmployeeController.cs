using CRUD_Operations.Data;
using EmployeeMaster.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeMaster.Controllers
{
    public class EmployeeController : Controller
    {

        EmployeeEntities dbContext = new EmployeeEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEmpData(JqueryDatatableParams param)
        {
            try
            {
                var resultData = dbContext.TBL_Employee.Select(x => new EmployeeViewModel
                {
                    City = x.TBL_City.Name,
                    Country = x.TBL_Country.Name,
                    DOB = x.DOB.Day + "/" + x.DOB.Month + "/" + x.DOB.Year,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Gender = x.Gender,
                    EmpID = x.EmpID,
                    Hobbies = x.Hobbies,
                    Zipcode = x.ZipCode,
                    State = x.TBL_State.Name,
                    EmployeePhoto = x.EmployeePhoto,
                    Salary = x.Salary,
                    Address = x.Address,
                    MaritalStatus = x.MaritalStatus,
                    Password = x.Password
                }).ToList();
                if (!string.IsNullOrEmpty(param.sSearch))
                {
                    resultData = resultData.Where(x => x.FirstName.ToLower().Contains(param.sSearch.ToLower())
                                                  || x.LastName.ToLower().Contains(param.sSearch.ToLower())
                                                  || x.Email.ToLower().Contains(param.sSearch.ToLower())
                                                  || x.Gender.ToString().Contains(param.sSearch.ToLower())
                                                  || x.DOB.ToString().Contains(param.sSearch.ToLower())
                                                  || x.Hobbies.ToString().Contains(param.sSearch.ToLower())
                                                  || x.Salary.ToString().Contains(param.sSearch.ToLower())
                                                  || x.Address.ToString().Contains(param.sSearch.ToLower())
                                                  || x.City.ToString().Contains(param.sSearch.ToLower())
                                                  || x.State.ToString().Contains(param.sSearch.ToLower())
                                                  || x.Country.ToString().Contains(param.sSearch.ToLower())
                                                  || x.Zipcode.Contains(param.sSearch.ToLower())).ToList();
                }

                var sortColumnIndex = Convert.ToInt32(HttpContext.Request.QueryString["iSortCol_0"]);
                var sortDirection = HttpContext.Request.QueryString["sSortDir_0"];

                if (sortColumnIndex == 7)
                {
                    resultData = sortDirection == "asc" ? resultData.OrderBy(c => c.Salary).ToList() : resultData.OrderByDescending(c => c.Salary).ToList();
                }
                else if (sortColumnIndex == 3)
                {
                    resultData = sortDirection == "asc" ? resultData.OrderBy(c => c.MaritalStatus).ToList() : resultData.OrderByDescending(c => c.MaritalStatus).ToList();
                }
                else
                {
                    Func<EmployeeViewModel, string> orderingFunction = e => sortColumnIndex == 0 ? e.FirstName :
                                                                   sortColumnIndex == 1 ? e.Email :
                                                                   sortColumnIndex == 2 ? e.Gender :
                                                                   sortColumnIndex == 4 ? e.DOB :
                                                                   sortColumnIndex == 5 ? e.Hobbies :
                                                                   e.Address;

                    resultData = sortDirection == "asc" ? resultData.OrderBy(orderingFunction).ToList() : resultData.OrderByDescending(orderingFunction).ToList();
                }

                var displayResult = resultData.Skip(param.iDisplayStart)
                    .Take(param.iDisplayLength).ToList();
                var totalRecords = resultData.Count();
                return Json(new
                {
                    isSuccess = true,
                    param.sEcho,
                    iTotalRecords = totalRecords,
                    iTotalDisplayRecords = totalRecords,
                    aaData = displayResult
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { isSuccess = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetSingleEmployee(int id)
        {
            var resultData = dbContext.TBL_Employee.Where(x => x.EmpID == id).Select(x => new EmployeeViewModel
            {
                City = x.TBL_City.Name,
                Country = x.TBL_Country.Name,
                DOB = x.DOB.Day + "/" + x.DOB.Month + "/" + x.DOB.Year,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = x.Gender,
                EmpID = x.EmpID,
                Hobbies = x.Hobbies,
                Zipcode = x.ZipCode,
                State = x.TBL_State.Name,
                EmployeePhoto = x.EmployeePhoto,
                Salary = x.Salary,
                Address = x.Address,
                MaritalStatus = x.MaritalStatus,
                Password = x.Password
            }).FirstOrDefault();
            return PartialView("_EmployeeDetails", resultData);
        }

        public ActionResult GetStateData(int id)
        {
            try
            {
                var resultData = dbContext.TBL_State.Where(x => x.CountryID == id).Select(x => new SelectListItem
                {
                    Value = x.StateID.ToString(),
                    Text = x.Name,
                }).ToList();

                return Json(new { isSuccess = true, result = resultData }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { isSuccess = false }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetCityData(int id)
        {
            try
            {
                var resultData = dbContext.TBL_City.Where(x => x.StateID == id).Select(x => new SelectListItem
                {
                    Value = x.CityID.ToString(),
                    Text = x.Name,
                }).ToList();

                return Json(new { isSuccess = true, result = resultData }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { isSuccess = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Create(int? id)
        {
            var model = new EmployeeCreateModel();
            if (id > 0)
            {
                var EmpData = dbContext.TBL_Employee.FirstOrDefault(x => x.EmpID == id);
                model.CityID = EmpData.CityID;
                model.CountryID = EmpData.CountryID;
                model.DOB = EmpData.DOB;
                model.Email = EmpData.Email;
                model.EmpID = EmpData.EmpID;
                model.EmployeePhoto = EmpData.EmployeePhoto;
                model.FirstName = EmpData.FirstName;
                model.Gender = EmpData.Gender;
                model.Hobbies = EmpData.Hobbies.Split(',').ToArray();
                model.LastName = EmpData.LastName;
                model.StateID = EmpData.StateID;
                model.Zipcode = EmpData.ZipCode;
                model.Salary = EmpData.Salary;
                model.Address = EmpData.Address;
                model.Password = EmpData.Password;
                ViewBag.State = dbContext.TBL_State.Where(x => x.CountryID == EmpData.CountryID).Select(x => new SelectListItem
                {
                    Value = x.StateID.ToString(),
                    Text = x.Name,
                }).ToList();
                ViewBag.City = dbContext.TBL_City.Where(x => x.StateID == EmpData.StateID).Select(x => new SelectListItem
                {
                    Value = x.CityID.ToString(),
                    Text = x.Name,
                }).ToList();
            }
            ViewBag.HobbieList = new List<SelectListItem>() {
                new SelectListItem { Text = "Reading", Value = "Reading" },
                new SelectListItem { Text = "Singing", Value = "Singing" },
                new SelectListItem { Text = "Surfing", Value = "Surfing" },
            }.ToList();
            ViewBag.Country = dbContext.TBL_Country.Select(x => new SelectListItem { Text = x.Name, Value = x.CountryID.ToString() }).ToList();
            return PartialView("Create", model);
        }

        public ActionResult DeleteEmp(int? id)
        {
            try
            {
                var EmpData = dbContext.TBL_Employee.Where(x => x.EmpID == id).FirstOrDefault();

                dbContext.TBL_Employee.Remove(EmpData);
                dbContext.SaveChanges();
                return Json(new { isSuccess = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { isSuccess = false }, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public ActionResult Create(EmployeeCreateModel model)
        {
            try
            {
                var imageName = string.Empty;

                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var EmpPhoto = System.Web.HttpContext.Current.Request.Files["empPic"];
                    if (EmpPhoto.ContentLength > 0)
                    {
                        var profileName = Path.GetFileName(EmpPhoto.FileName);
                        var ext = Path.GetExtension(EmpPhoto.FileName);
                        imageName = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ext;
                        var comPath = Server.MapPath("/Images/") + imageName;
                        EmpPhoto.SaveAs(comPath);
                    }
                }
                else
                {
                    imageName = model.EmployeePhoto;
                }

                var datamodel = new TBL_Employee
                {
                    CityID = model.CityID,
                    StateID = model.StateID,
                    ZipCode = model.Zipcode,
                    CountryID = model.CountryID,
                    Email = model.Email,
                    EmpID = model.EmpID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    Hobbies = string.Join(",", model.Hobbies),
                    DOB = model.DOB,
                    EmployeePhoto = imageName,
                    Password = model.Password,
                    MaritalStatus = model.MaritalStatus,
                    Address = model.Address,
                    Salary = model.Salary
                };

                if (model.EmpID > 0)
                {
                    dbContext.Entry(datamodel).State = System.Data.Entity.EntityState.Modified;
                    TempData["Message"] = "Emplyoyee Updated Suceessfully";

                }
                else
                {
                    dbContext.TBL_Employee.Add(datamodel);
                    TempData["Message"] = "Emplyoyee Added Suceessfully";
                }
                dbContext.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { isSuccess = true }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
                //return Json(new { isSuccess = false }, JsonRequestBehavior.AllowGet);

            }

        }

    }
}