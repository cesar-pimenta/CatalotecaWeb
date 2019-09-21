using System;
using System.Net;
using System.Threading.Tasks;
using CatalotecaWeb.Domain.Entities;
using CatalotecaWeb.Domain.Interfaces.Services.Product;
using Microsoft.AspNetCore.Mvc;


namespace CatalotecaWeb.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad request - Solicitação Invalida
            }
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException errors)
            {
                // tive que sair ...  Amanha continuo 
                return StatusCode((int)HttpStatusCode.InternalServerError, errors.Message);
            }
        }
        [HttpGet]
        [Route("{id}", Name = "Getid")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException erros)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, erros.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductEntity product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Post(product);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("Getid", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException erros)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, erros.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProductEntity product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Put(product);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException errors)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, errors.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException errors)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, errors.Message);
            }
        }
    }
}
