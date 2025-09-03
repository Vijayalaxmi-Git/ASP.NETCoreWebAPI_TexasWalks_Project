using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TexasWalks.API.CustomActionFilters;
using TexasWalks.API.Data;
using TexasWalks.API.Models.Domain;
using TexasWalks.API.Models.DTO;
using TexasWalks.API.Repository;

namespace TexasWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        #region CRUD operation
        
        private readonly TexasWalksDbContext dBContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionController(TexasWalksDbContext dBContext,IMapper mapper,
            IRegionRepository regionRepository)
        {
            this.dBContext = dBContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        //Get all regions
        //Get : https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data from database
            //var regionsDomain = await dBContext.Regions.ToListAsync();

            #region
            //Map domain models to DTOs
            //var regionDto = new List<RegionDto>();
            //foreach (var regionDomain in regionsDomain)
            //{
            //    regionDto.Add(new RegionDto()
            //    {
            //        Code = regionDomain.Code,
            //        Id = regionDomain.Id,
            //        Name = regionDomain.Name,
            //        RegionImageUrl = regionDomain.RegionImageUrl
            //    });
            //}
            #endregion

            //Map Domain Models to DTOs
            //var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);

            //Returns DTOs
            //return Ok(regionsDomain);

            //return Ok(mapper.Map<List<RegionDto>>(regionsDomain));

            // Get Data From Database - Domain models
            var regionsDomain = await regionRepository.GetAllAsync();

            // Return DTOs
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        //Get by Id
        //Search by Id
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region=dbContext.Regions.Find(id);
            //var regionDomain =await dBContext.Regions.FirstOrDefaultAsync(x=>x.Id==id);
            //if (regionDomain == null) 
            //{
            //    return NotFound();
            //}

            ////Map/Convert Region Domain Model to Region DTO
            //var regionDto = new RegionDto
            //{
            //    Code = regionDomain.Code,
            //     Id = regionDomain.Id,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};
            //return Ok(regionDto);

            #region Using Auto Mapper
            //var regionDomain = await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            //return regionDomain == null ? NotFound() : Ok(mapper.Map<RegionDto>(regionDomain));
            #endregion

            //var region = dbContext.Regions.Find(id);
            // Get Region Domain Model From Database
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        //Post to create new region
        //Post : https://localhost:portnumber/api/regions
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            try
            {
                #region Comment
                //if (ModelState.IsValid)
                //{
                //    //Map or convert DTO to Domain Model
                //    var regionDomainModel = new Region
                //    {
                //        Code = addRegionRequestDto.Code,
                //        Name = addRegionRequestDto.Name,
                //        RegionImageUrl = addRegionRequestDto.RegionImageUrl
                //    };

                //    //Use Domain model to create region

                //    dBContext.Regions.Add(regionDomainModel);
                //    await dBContext.SaveChangesAsync();

                //    //Map Domain Model back to DTO
                //    var regionDto = new RegionDto
                //    {
                //        Code = regionDomainModel.Code,
                //        Id = regionDomainModel.Id,
                //        Name = regionDomainModel.Name,
                //        RegionImageUrl = regionDomainModel.RegionImageUrl
                //    };
                //    return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
                //}
                //else
                //{
                //    return BadRequest(ModelState);
                //}
                #endregion

                //Using Auto Mapper
                // Map or Convert DTO to Domain Model
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);    
                // Use Domain Model to create Region
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);
                // Map Domain model back to DTO
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }

        //Update region
        //Post : https://localhost:portnumber/api/regions/{Id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            //Check if region exist
            var regionDomainModel =await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomainModel == null)
                return NotFound();


            //Map DTO to Domain Model
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name=updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl=updateRegionRequestDto.RegionImageUrl;

           await dBContext.SaveChangesAsync();

            //Map Domain Model back to DTO
            var regionDto = new RegionDto
            {
                Code = regionDomainModel.Code,
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
        }

        //Delete region
        //Delete : https://localhost:portnumber/api/regions/{Id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) 
        {
            //Check if region exist
            var regionDomainModel =await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomainModel == null)
                return NotFound();

            //delete region
            dBContext.Regions.Remove(regionDomainModel);
            dBContext.SaveChanges();

            //Return Delete region back
            //Map Domain Model back to DTO
            var regionDto = new RegionDto
            {
                Code = regionDomainModel.Code,
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            return Ok(regionDto);
        }
        
        #endregion
    }
}