using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using BackendPaulo.Models;

namespace BackendPaulo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response<List<Participant>> oResponse = new Response<List<Participant>>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    var lst = db.Participants.ToList();
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

        [HttpGet("{document}")]
        public IActionResult Get(string document)
        {
            Response<Participant> oResponse = new Response<Participant>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    var lst = db.Participants.Find(document);

                    if (lst == null) 
                    {
                        oResponse.Message = "Participant with Document = "+ document + " not found";
                        return Ok(oResponse);
                    }

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

        [HttpPost]
        public IActionResult Post(Participant model)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {

                    Participant oParticipant = db.Participants.Find(model.Document);

                    if (oParticipant != null) 
                    {
                        oResponse.Message = "Participant whit document " + model.Document + " already exists";
                        return Ok(oResponse);
                    }

                    var lst = db.Participants.ToList();

                    foreach (Participant oFilter in lst)
                    {
                        if (oFilter.Email.Equals(model.Email))
                        {
                            oResponse.Message = "Participant whit email " + model.Email + " already exists";
                            return Ok(oResponse);
                        }
                    }

                    oParticipant = new Participant();

                    oParticipant.Document = model.Document;
                    oParticipant.Picture = model.Picture;
                    oParticipant.Fullname = model.Fullname;
                    oParticipant.Email = model.Email;

                    db.Participants.Add(oParticipant);
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
        public IActionResult Put(Participant model)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    var lst = db.Participants.ToList();

                    foreach (Participant oFilter in lst)
                    {
                        if (!oFilter.Document.Equals(model.Document) && oFilter.Email.Equals(model.Email))
                        {
                            oResponse.Message = "Participant whit email " + model.Email + " already exists";
                            return Ok(oResponse);
                        }
                    }

                    Participant oParticipant = db.Participants.Find(model.Document);

                    oParticipant.Picture = model.Picture;
                    oParticipant.Fullname = model.Fullname;
                    oParticipant.Email = model.Email;

                    db.Entry(oParticipant).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        [HttpDelete("{document}")]
        public IActionResult Delete(string document)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    Participant oParticipant = db.Participants.Find(document);
                    db.Remove(oParticipant);
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