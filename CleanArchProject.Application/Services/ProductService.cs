﻿using AutoMapper;
using CleanArchProject.Application.DTOs;
using CleanArchProject.Application.Interfaces;
using CleanArchProject.Application.Products.Commands;
using CleanArchProject.Application.Products.Queries;
using CleanArchProject.Domain.Entities;
using CleanArchProject.Domain.Interfaces;
using MediatR;

namespace CleanArchProject.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new Exception($"Entity coud not be loaded.");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetProductById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductByCategoryId(int? id)
        {
            var productByCategoryIdQuery = new GetProductByCategoryIdQuery(id.Value);

            if (productByCategoryIdQuery == null)
                throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(productByCategoryIdQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task Add(ProductDTO dto)
        {
            // convert dto to productCreateCommand
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(dto);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO dto)
        {
            // convert dto to productCreateCommand
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(dto);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Delete(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }
    }
}
