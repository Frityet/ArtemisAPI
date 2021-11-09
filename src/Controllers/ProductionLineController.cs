using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ArtemisAPI.Models;
using ArtemisAPI.Services;

namespace ArtemisAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionLineController : ControllerBase
    {
        public ProductionLineController() {}

        [HttpGet]
        public ActionResult<IEnumerable<ProductionLine>> GetAll() => new ActionResult<IEnumerable<ProductionLine>>(FactoryMachineService.AllFactories);

        [HttpGet("{name}")]
        public ActionResult<ProductionLine> Get(string name)
        {
            ProductionLine factory = FactoryMachineService.Select(name);
            return factory == null ? NotFound() : factory;
        }

        [HttpPost]
        public ActionResult Post(ProductionLine factory)
        {
            FactoryMachineService.Add(factory);
            return CreatedAtAction(nameof(Post), new { Name = factory.Name }, factory);
        }

        [HttpPut("name")]
        public ActionResult Put(string name, ProductionLine update)
        {
            if (name != update.Name)
                return BadRequest();
            
            ProductionLine factory = FactoryMachineService.Select(name);
            if (factory is null)
                return NotFound();
            FactoryMachineService.Update(update);
            return NoContent();
        }

        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            ProductionLine factory = FactoryMachineService.Select(name);
            if (factory is null)
                return NotFound();
            FactoryMachineService.Delete(name);
            return NoContent();
        }

        // [HttpGet("{materials}")]
        // public ActionResult<IEnumerable<ProductionLine>> Get(string[] materials)
        // {
        //     IEnumerable<ProductionLine> factories = FactoryMachineService.FactoriesFromMaterials(materials);
        //     return factories == null ? NotFound() : new ActionResult<IEnumerable<ProductionLine>>(factories);
        // }
    }

}