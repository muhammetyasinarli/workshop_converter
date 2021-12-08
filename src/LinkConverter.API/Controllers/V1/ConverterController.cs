using LinkConverter.API.Model;
using LinkConverter.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace LinkConverter.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ConverterController:ControllerBase
    {
        private readonly IConverterService _converterService;

        public ConverterController(IConverterService converterService)
        {
            _converterService = converterService;
        }

        [HttpPost("weburl-to-deeplink")]
        [ProducesResponseType(typeof(ConversionResponse), (int)HttpStatusCode.OK)]
        public ActionResult<ConversionResponse> ConvertWebUrlToDeeplink([FromBody] ConversionRequest linkConversionRequest)
        {
            return Ok(_converterService.ConvertWebUrlToDeeplink(linkConversionRequest.Link));
        }

        [HttpPost("deeplink-to-weburl")]
        [ProducesResponseType(typeof(ConversionResponse), (int)HttpStatusCode.OK)]
        public ActionResult<string> ConvertDeeplinkToWebUrl([FromBody] ConversionRequest linkConversionRequest)
        {
            return Ok(_converterService.ConvertDeeplinkToWebUrl(linkConversionRequest.Link));
        }

        [HttpGet("all-link-conversions")]
        [ProducesResponseType(typeof(IEnumerable<LinkConversion>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<LinkConversion>> GetLinkConversion()
        {
            return Ok(_converterService.GetLinkConversion());
        }
    }
}
