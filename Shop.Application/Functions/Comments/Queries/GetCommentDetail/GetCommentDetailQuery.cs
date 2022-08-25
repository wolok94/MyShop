using MediatR;
using Shop.Application.Functions.Comments.Queries.GetInList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Comments.Queries.GetCommentDetail
{
    public class GetCommentDetailQuery : IRequest<CommentsView>
    {
        public int Id { get; set; }
    }
}
