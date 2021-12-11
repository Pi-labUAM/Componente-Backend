using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using BackendPaulo.Models;
using System.Collections.Generic;

namespace BackendPaulo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response<List<Publication>> oResponse = new Response<List<Publication>>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    var lst = db.Publications.ToList();
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
            Response<Publication> oResponse = new Response<Publication>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    var lst = db.Publications.Find(createDate);
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
            Response<List<Publication>> oResponse = new Response<List<Publication>>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    var lst = db.Publications.ToList();
                    List<Publication> lstFilter = new List<Publication> { };

                    foreach (Publication oFilter in lst)
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
        public IActionResult Post(Publication model)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    Publication oPublication = new Publication();

                    oPublication.CreateDate = model.CreateDate;
                    oPublication.PublicationDate = model.PublicationDate;
                    oPublication.Title = model.Title;
                    oPublication.Link = model.Link;

                    db.Publications.Add(oPublication);
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
        public IActionResult Put(Publication model)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    Publication oPublication = db.Publications.Find(model.CreateDate);

                    oPublication.PublicationDate = model.PublicationDate;
                    oPublication.Title = model.Title;
                    oPublication.Link = model.Link;

                    db.Entry(oPublication).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Publication oPublication = db.Publications.Find(createDate);
                    db.Remove(oPublication);
                    db.SaveChanges();

                    oResponse .Success = 1;
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