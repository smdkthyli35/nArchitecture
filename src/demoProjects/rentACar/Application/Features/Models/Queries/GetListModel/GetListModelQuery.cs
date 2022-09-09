using Application.Features.Models.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetListModel
{
    public class GetListModelQuery : IRequest<ModelListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
