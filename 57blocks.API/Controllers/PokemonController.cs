using _57blocks.Logic.Core;
using _57blocks.Logic.Models;
using _57blocks.Model.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace _57blocks.API.Controllers
{
    /// <summary>
    /// PokemonController
    /// </summary>
    public class PokemonController : ApiController
    {
        protected TaskFactory _taskFactory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());

        /// <summary>Inserta un nuevo pokemon</summary>
        /// <remarks> El email es el registro insertado en UserLogin - InsertLogin</remarks>
        /// <param name="item"></param>
        /// <returns>Devuelve un httpCode</returns>
        /// <response code="200">Ok. Pokemon insertado </response>
        /// <response code="400">Solicitud erronea </response>
        [HttpPost]
        public async Task<IHttpActionResult> Create(PokemonModel item)
        {
            bool valid = await _taskFactory.StartNew(() => PokemonHelper.Create(item));
            if (valid)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error in Insert");
            }
        }

        /// <summary>
        /// Obtiene todos los pokemon
        /// </summary>
        /// <returns>Listado de pokemon</returns>
        /// <response code="200">Ok. Devuelve el listado de todos los pokemon </response>
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            string jsonString = await _taskFactory.StartNew(() => PokemonHelper.GetAll());
            return Ok(jsonString);
        }

        /// <summary> Obtiene todos los pokemon privados</summary>
        /// <remarks>
        /// El email es el registro insertado en UserLogin - InsertLogin
        /// </remarks>
        /// <param name="email"></param>
        /// <returns>Listado de pokemon privados</returns>
        /// <response code="200">Ok. Devuelve el listado de todos los pokemon </response>
        [HttpGet]
        public async Task<IHttpActionResult> GetMyElements(string email)
        {
            string jsonString = await _taskFactory.StartNew(() => PokemonHelper.GetMyElements(email));
            return Ok(jsonString);
        }


        /// <summary>
        /// Actualiza un pokemon privado
        /// </summary>
        /// <remarks>
        /// El email es con el que se creo el pokemon
        /// </remarks>
        /// <param name="pokemonModel"></param>
        /// <returns>Devuelve un httpCode</returns>
        /// <response code="200">Ok. Pokemon insertado </response>
        /// <response code="400">Solicitud erronea, El item es privado no se puede modificar</response>
        [HttpPut]
        public async Task<IHttpActionResult> Update(PokemonModel pokemonModel)
        {
            bool result = await _taskFactory.StartNew(() => PokemonHelper.Update(pokemonModel));
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Item is private");
            }
        }

        /// <summary>
        /// Elimina un pokemon privado
        /// </summary>
        /// <param name="pokemonModel"></param>
        /// <returns>Devuelve un httpCode</returns>
        /// <response code="200">Ok. Pokemon insertado </response>
        /// <response code="400">Solicitud erronea, El item es privado no se puede eliminar </response>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(PokemonModel pokemonModel)
        {
            bool result = await _taskFactory.StartNew(() => PokemonHelper.Delete(pokemonModel));
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Item is private");
            }
        }

        /// <summary>
        /// Elimina todos los pokemon privados
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Devuelve un httpCode</returns>
        /// <response code="200">Ok. Pokemon insertado </response>
        /// <response code="400">Solicitud erronea, se presento un error </response>
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAll(string email)
        {
            bool result = await _taskFactory.StartNew(() => PokemonHelper.DeleteAll(email));
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Items are private");
            }
        }


    }
}