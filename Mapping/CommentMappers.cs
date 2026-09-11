using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Comment;
using API.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace API.Mapping
{
    public static class CommentMappers
    {
       public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId
            };
        } 

        public static Comment ToCreateCommentDto(this  CreateCommentDto CreateCommentModel, int stockid)
        {
            return new Comment
            {
                Title = CreateCommentModel.Title,
                Content = CreateCommentModel.Content,
                StockId = stockid
            };
        } 
    }
}