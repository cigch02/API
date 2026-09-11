using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Models;

namespace API.Mapping
{
    public static class StockMappers
    {
        public static StockDTO ToStockDto (this Stock stockModel)
        {
            return new StockDTO
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                marketCap = stockModel.marketCap,
                Comments = stockModel.Comment.Select(c => c.ToCommentDto()).ToList()
                
            };
        }

        public static Stock ToStockFromCreateDTO(this CreateStockDto createStockDto)
        {
            return new Stock
            {
                Symbol = createStockDto.Symbol,
                CompanyName = createStockDto.CompanyName,
                Purchase = createStockDto.Purchase,
                LastDiv = createStockDto.LastDiv,
                Industry = createStockDto.Industry,
                marketCap = createStockDto.marketCap 
            };
        }
    }
}