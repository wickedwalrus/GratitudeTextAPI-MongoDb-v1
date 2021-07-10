using GratitudeTextAPI_v1.Models;
using GratitudeTextAPI_v1.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GratitudeTextAPI_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextsController : ControllerBase
    {
        private TextService _textService;
        public TextsController(TextService textService)
        {
            _textService = textService;
        } 

        // GET: api/<TextsController>
        [HttpGet]
        public ActionResult<List<Text>> Get()
        {
            return _textService.Get();
        }

        // GET api/<TextsController>/5
        [HttpGet("{id:length(24)}", Name = "GetText")]
        public ActionResult<Text> Get(string id)
        {
            var text = _textService.Get(id);
            if (text == null)
            {
                return NotFound();
            }

            return text;
        }

        // POST api/<TextsController>
        [HttpPost]
        public ActionResult<Text> Create(Text text)
        {
            _textService.Create(text);
            return CreatedAtRoute("GetText", new { id = text.Id.ToString() }, text);
        }

        // PUT api/<TextsController>/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Text textIn)
        {
            var text = _textService.Get(id);

            if (text == null)
            {
                return NotFound();
            }

            _textService.Update(id, textIn);

            return NoContent();
        }


        // DELETE api/<TextsController>/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var text = _textService.Get(id);

            if (text == null)
            {
                return NotFound();
            }

            _textService.Remove(text.Id);
            return NoContent();
        }
    }
}
