﻿using AutoMapper;
using BookStore.Application.Books.Commands.CreateBook;
using BookStore.Application.Books.Commands.DeleteBook;
using BookStore.Application.Books.Commands.UpdateBook;
using BookStore.Application.Ratings.Commands.CreateRating;
using BookStore.Application.Ratings.Commands.DeleteRating;
using BookStore.Application.Ratings.Commands.UpdateRating;
using BookStore.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RatingController : BaseController
    {
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;

        public RatingController(IMapper mapper, UserManager<IdentityUser> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRatingDto createRatingDto)
        {
            var command = mapper.Map<CreateRatingCommand>(createRatingDto);
            command.UserId = Guid.Parse((await userManager.FindByEmailAsync(User.Identity.Name)).Id); //TODO fix
            var ratingId = await Mediator.Send(command);
            return Ok(ratingId);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Update([FromBody] UpdateRatingDto updateRatingDto)
        {
            var command = mapper.Map<UpdateRatingCommand>(updateRatingDto);
            command.UserId = Guid.Parse((await userManager.FindByEmailAsync(User.Identity.Name)).Id); //TODO fix
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteRatingCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
