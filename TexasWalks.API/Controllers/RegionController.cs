using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TexasWalks.API.Data;
using TexasWalks.API.Models.Domain;
using TexasWalks.API.Models.DTO;

namespace TexasWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        #region CRUD operation
        
        private readonly TexasVoxDBContext dBContext;

        public RegionController(TexasVoxDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        //Get all regions
        //Get : https://localhost:portnumber/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            //Get Data from database
            var regionsDomain = dBContext.Regions.ToList();


            //Map domain models to DTOs
            var regionDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionDto.Add(new RegionDto()
                {
                    Code = regionDomain.Code,
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }

            //Returns DTOs
            return Ok(regionsDomain);
        }

        //Get by Id
        //Search by Id
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //var region=dbContext.Regions.Find(id);
            var regionDomain = dBContext.Regions.FirstOrDefault(x=>x.Id==id);
            if (regionDomain == null) 
            {
                return NotFound();
            }

            //Map/Convert Region Domain Model to Region DTO
            var regionDto = new RegionDto
            {
                Code = regionDomain.Code,
                 Id = regionDomain.Id,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return Ok(regionDto);
        }

        //Post to create new region
        //Post : https://localhost:portnumber/api/regions
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {

            //Map or convert DTO to Domain Model
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,               
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            //Use Domain model to create region

            dBContext.Regions.Add(regionDomainModel);
            dBContext.SaveChanges();

            //Map Domain Model back to DTO
            var regionDto = new RegionDto
            {
                Code = regionDomainModel.Code,
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };


            return CreatedAtAction(nameof(GetById), new {id= regionDto.Id},regionDto);

        }

        //Update region
        //Post : https://localhost:portnumber/api/regions/{Id}
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            //Check if region exist
            var regionDomainModel = dBContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomainModel == null)
                return NotFound();


            //Map DTO to Domain Model
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name=updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl=updateRegionRequestDto.RegionImageUrl;

            dBContext.SaveChanges();

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
        public IActionResult Delete([FromRoute] Guid id) 
        {
            //Check if region exist
            var regionDomainModel = dBContext.Regions.FirstOrDefault(x => x.Id == id);
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