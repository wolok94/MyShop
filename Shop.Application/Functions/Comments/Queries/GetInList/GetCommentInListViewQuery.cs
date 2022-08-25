using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Comments.Queries.GetInList
{
    public class GetCommentInListViewQuery : IRequest<List<CommentsView>>
    {

    }
}
