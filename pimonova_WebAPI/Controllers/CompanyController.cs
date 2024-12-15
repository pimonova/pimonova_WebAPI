﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.DTOs.Company;
using pimonova_WebAPI.Interfaces;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using static pimonova_WebAPI.Mappers.CompanyMappers;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/Companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICompanyRepository _companyRepo;
        public CompanyController(ApplicationDbContext context, ICompanyRepository CompanyRepo)
        {
            _companyRepo = CompanyRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Companies = await _companyRepo.GetAllAsync();
            var CompanyDTO = Companies.Select(s => s.ToCompanyDTO());

            return Ok(Companies);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Company = await _companyRepo.GetByIdAsync(Id);

            if (Company == null)
            {
                return NotFound("Company is not found");
            }

            return Ok(Company.ToCompanyDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyRequestDTO CompanyDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var CompanyModel = CompanyDTO.ToCompanyFromCreateDTO();
            await _companyRepo.CreateAsync(CompanyModel);

            return CreatedAtAction(nameof(GetById), new {Id = CompanyModel.Id}, CompanyModel.ToCompanyDTO());
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateCompanyRequestDTO UpdateCompanyDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var CompanyModel = await _companyRepo.UpdateAsync(Id, UpdateCompanyDTO);

            if (CompanyModel == null)
            {
                return NotFound("Company is not found");
            }

            return Ok(CompanyModel.ToCompanyDTO());
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var CompanyModel = await _companyRepo.DeleteAsync(Id);

            if(CompanyModel == null)
            {
                return NotFound("Company is not found");
            }

            return NoContent();
        }
    }
}
