using Microsoft.AspNetCore.Mvc;
using ReactionAPI.Models.Dtos;
using ReactionAPI.Services;
using SharedLib.ControllerBases;

namespace ReactionAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReactionController : CustomBaseController
{
    private readonly IReactionService _reactionService;

    public ReactionController(IReactionService reactionService)
    {
        _reactionService = reactionService;
    }

    [HttpPost("Like")]
    public async Task<IActionResult> Create(LikeCreateDto likeCreateDto)
    {
        var response = await _reactionService.Like(likeCreateDto);

        return CreateActionResultInstance(response);
    }

}
