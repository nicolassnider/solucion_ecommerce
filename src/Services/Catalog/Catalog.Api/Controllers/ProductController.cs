using Catalog.Service.Queries;
using Catalog.Service.Queries.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Service.EventHandlers.Commands;
using MediatR;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("/products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;
        private readonly IProductQueryService _productQueryService;
        private readonly IMediator _mediator;

        public ProductController(
            ILogger<DefaultController> logger,
            IProductQueryService productQueryService,
            IMediator mediator)

        {
            _logger = logger;
            _productQueryService = productQueryService;
            _mediator = mediator;
        }

        //  products
        [HttpGet]
        public async Task<DataCollection<ProductDTO>> GetAll(int page=1,int take=10,string ids = null)
        {
            IEnumerable<int> products = null;

            if (!string.IsNullOrEmpty(ids))
            {
                products = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _productQueryService.GetAllAsync(page,take,products);
        }

        //  products/{id}
        [HttpGet("{id}")]
        public async Task<ProductDTO> Get(int id)
        {
            return await _productQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult>Create(ProductCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }

    }
}
