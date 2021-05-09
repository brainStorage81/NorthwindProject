using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
	{
		IProductImageService _productImageService;
		public ProductImagesController(IProductImageService productImageService)
		{
			_productImageService = productImageService;
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			Thread.Sleep(1000);
			var result = _productImageService.GetAll();

			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbyid")]
		public IActionResult GetById([FromForm(Name = ("Id"))] int id)
		{
			Thread.Sleep(1000);
			var result = _productImageService.GetById(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getallbyproductid")]
		public IActionResult GetAllByProductId(int productId)
		{
			Thread.Sleep(1000);
			var result = _productImageService.GetAllByProductId(productId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("add")]
		public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] ProductImage productImages)
		{
			var result = _productImageService.Add(file, productImages);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("update")]
		public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int id)
		{
			var productImages = _productImageService.Get(p => p.Id == id).Data;
			var result = _productImageService.Update(file, productImages);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete([FromForm(Name = ("Id"))] int id)
		{
			
			var productImage = _productImageService.Get(p=>p.Id == id).Data;
			var result = _productImageService.Delete(productImage);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		
	}
}
