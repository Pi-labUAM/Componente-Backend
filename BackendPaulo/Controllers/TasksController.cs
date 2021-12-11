using Microsoft.AspNetCore.Mvc;
using System;

using BackendPaulo.Models;

namespace BackendPaulo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return null;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return null;
        }

        [HttpPost]
        public IActionResult Post(Talk model)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    Talk oTalk = new Talk();
                    oTalk.CreateDate = model.CreateDate;
                    oTalk.Date = model.Date;
                    oTalk.Name = model.Name;
                    oTalk.Speaker = model.Speaker;
                    oTalk.Place = model.Place;

                    db.Talks.Add(oTalk);
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

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return null;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return null;
        }
    }
}