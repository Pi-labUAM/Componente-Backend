using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using BackendPaulo.Models;

namespace BackendPaulo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscriptionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response<List<Inscription>> oResponse = new Response<List<Inscription>>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    var lst = db.Inscriptions.ToList();
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
            Response<List<Inscription>> oResponse = new Response<List<Inscription>>();
            return Ok(oResponse);
        }

        [HttpPost]
        public IActionResult Post(Inscription model)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {

                    var lst = db.Inscriptions.ToList();

                    foreach (Inscription oFilter in lst)
                    {
                        if (oFilter.Research.Equals(model.Research) && oFilter.Participant.Equals(model.Participant))
                        {
                            oResponse.Message = "Participant whit document " + model.Participant + " already exists";
                            return Ok(oResponse);
                        }
                    }

                    Inscription oInscription = new Inscription();

                    oInscription.Participant = model.Participant;
                    oInscription.Research = model.Research;
                    oInscription.CreateDate = model.CreateDate;
                    
                    db.Inscriptions.Add(oInscription);
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

        [HttpDelete("{createDate}/{document}")]
        public IActionResult Delete(string createDate , string document)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (dbpauloContext db = new dbpauloContext())
                {
                    List<Inscription> lst = db.Inscriptions.ToList();

                    foreach (Inscription oFilter in lst)
                    {
                        if (oFilter.Research.Equals(createDate) && oFilter.Participant.Equals(document))
                        {
                            Inscription oParticipant = oFilter;
                            db.Remove(oParticipant);
                            db.SaveChanges();
                            break;
                        }
                    }

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