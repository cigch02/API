using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Mapping;
using API.DTOs;
using API.Models;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;

namespace API.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepository;
        public StockController(ApplicationDBContext context, IStockRepository stockRepository)
        {
            _context = context;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var stock = await _stockRepository.GetAllAsync();

            var stockDTo = stock.Select(s => s.ToStockDto());

            return Ok(stockDTo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStockDto stockDto)
        {
            var stock = stockDto.ToStockFromCreateDTO();
            await _stockRepository.CreateAsync(stock);
            return CreatedAtAction(nameof(GetByIdAsync), new {id=stock.Id}, stock.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateStockDTO updateStock)
        {
            var  stock = await _stockRepository.UpdateAsync(id, updateStock);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());


        }

        [HttpDelete]
        [Route ("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var stock = await _stockRepository.DeleteAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}