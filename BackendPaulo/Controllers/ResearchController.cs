using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using BackendPaulo.Models;
using System.Collections.Generic;

namespace BackendPaulo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response<List<Research>> oResponse = new Response<List<Research>>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    var lst = db.Researches.ToList();
                    oResponse.Success = 1;
                    oResponse.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }

        [HttpGet("{createDate}")]
        public IActionResult Get(string createDate)
        {
            Response<Research> oResponse = new Response<Research>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    var lst = db.Researches.Find(createDate);
                    oResponse.Success = 1;
                    oResponse.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }

        [HttpGet("search/{Texto}")]
        public IActionResult Search(string Texto)
        {
            Response<List<Research>> oResponse = new Response<List<Research>>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    var lst = db.Researches.ToList();
                    List<Research> lstFilter = new List<Research> { };

                    foreach (Research oFilter in lst)
                    {
                        if (oFilter.Title.Contains(Texto))
                        {
                            lstFilter.Add(oFilter);
                        }
                    }
                    oResponse.Success = 1;
                    oResponse.Data = lstFilter;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }

        [HttpPost]
        public IActionResult Post(Research model)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    Research oResearch = new Research();

                    oResearch.CreateDate = model.CreateDate;
                    oResearch.Picture = model.Picture;
                    oResearch.Title = model.Title;
                    oResearch.Abstract = model.Abstract;
                    oResearch.Objectives = model.Objectives;
                    oResearch.Results = model.Results;
                    oResearch.Bibliography = model.Bibliography;
                    oResearch.State = model.State;

                    db.Researches.Add(oResearch);
                    db.SaveChanges();

                    oResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }

        [HttpPut]
        public IActionResult Put(Research model)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    Research oResearch = db.Researches.Find(model.CreateDate);

                    oResearch.Picture = model.Picture;
                    oResearch.Title = model.Title;
                    oResearch.Abstract = model.Abstract;
                    oResearch.Objectives = model.Objectives;
                    oResearch.Results = model.Results;
                    oResearch.Bibliography = model.Bibliography;
                    oResearch.State = model.State;

                    db.Entry(oResearch).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    oResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }

        [HttpDelete("{createDate}")]
        public IActionResult Delete(string createDate)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    Research oResearch = db.Researches.Find(createDate);
                    db.Remove(oResearch);
                    db.SaveChanges();

                    oResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }
    }
}