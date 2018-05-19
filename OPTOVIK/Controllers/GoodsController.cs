using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OPTOVIK.Models;
using Microsoft.AspNetCore.Authorization;

namespace OPTOVIK.Controllers
{
    [Produces("application/json")]
    [Route("api/Goods")]
    public class GoodsController : Controller
    {
        private readonly OptovikContext _context;

        public GoodsController(OptovikContext context)
        {
            _context = context;
        }

        //    // GET: api/Goods
        //    [HttpGet]
        //    public IEnumerable<Goods> GetGoods()
        //    {
        //        return _context.Goods;
        //    }

        //    // GET: api/Goods/5
        //    [HttpGet("{id}")]
        //    public async Task<IActionResult> GetGoods([FromRoute] int id)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        var goods = await _context.Goods.SingleOrDefaultAsync(m => m.GoodId == id);

        //        if (goods == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(goods);
        //    }

        //    // PUT: api/Goods/5
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutGoods([FromRoute] int id, [FromBody] Goods goods)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        if (id != goods.GoodId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(goods).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!GoodsExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Goods
        //    [HttpPost]
        //    public async Task<IActionResult> PostGoods([FromBody] Goods goods)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        _context.Goods.Add(goods);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetGoods", new { id = goods.GoodId }, goods);
        //    }

        //    // DELETE: api/Goods/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteGoods([FromRoute] int id)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        var goods = await _context.Goods.SingleOrDefaultAsync(m => m.GoodId == id);
        //        if (goods == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Goods.Remove(goods);
        //        await _context.SaveChangesAsync();

        //        return Ok(goods);
        //    }

        //    private bool GoodsExists(int id)
        //    {
        //        return _context.Goods.Any(e => e.GoodId == id);
        //    }
        //}
        // GET: api/OrderObjects
        [HttpGet]
        public IEnumerable<Goods> GetOrderObject()
        {
            return _context.Goods
                .Include(obj => obj.Manufacturer)
                .Include(obj => obj.Type)
                ;
        }

        //// GET: api/OrderObjects/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetOrderObject([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var orderObject = await _context.OrderObject.SingleOrDefaultAsync(m => m.ObjectId == id);

        //    if (orderObject == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(orderObject);
        //}


        [HttpGet("{id}", Name = "GetObj")]
        public IActionResult GetById(int id)
        {

            var item = _context.Goods.FirstOrDefault(t => t.GoodId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        #region snippet_Create
        [HttpPost]
        public IActionResult Create([FromBody] Goods item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Goods.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetObj", new { id = item.GoodId }, item);
        }
        #endregion

        #region snippet_Update
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Goods item)
        {
            if (item == null || item.GoodId != id)
            {
                return BadRequest();
            }

            var todo = _context.Goods.FirstOrDefault(t => t.GoodId == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.GoodId = item.GoodId;
            todo.Name = item.Name;
            todo.Price = item.Price;
            //todo. = item.Availability;
            todo.ManufacturerId = item.ManufacturerId;
            todo.TypeId = item.TypeId;
            todo.Image = item.Image;
            //todo.Pengine = item.Pengine;
            //todo.Punishments = item.Punishments;

            _context.Goods.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
        #endregion

        #region snippet_Delete
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var todo = _context.Goods.FirstOrDefault(t => t.GoodId == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Goods.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
        #endregion
    }
}