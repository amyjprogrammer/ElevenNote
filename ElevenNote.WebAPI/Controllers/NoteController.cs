using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    [Authorize]//security layer
    public class NoteController : ApiController
    {
        //Get or Read
        public IHttpActionResult Get()
        {
            NoteService noteService = CreateNoteService();
            var notes = noteService.GetNotes();
            return Ok(notes);
        }

        //Create or Put
        public IHttpActionResult Post(NoteCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.CreateNote(note))
                return InternalServerError();

            return Ok();
        }

        //Get by Id
        public IHttpActionResult Get(int id)
        {
            NoteService noteService = CreateNoteService();
            var note = noteService.GetNoteById(id);
            return Ok(note);
        }

        //Put or Update
        public IHttpActionResult Put(NoteEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.UpdateNote(note))
                return InternalServerError();

            return Ok();
        }

        //Delete
        //not asyn
        public IHttpActionResult Delete(int id)
        {
            var service = CreateNoteService();

            if (!service.DeleteNote(id))
                return InternalServerError();

            return Ok();
        }

        //helper method
        //needs the private, because this could be used as a put
        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new NoteService(userId);
            return noteService;
        }
        //ask on Monday why this was on the bottom and about [HttpPost] not being included


    }
}
