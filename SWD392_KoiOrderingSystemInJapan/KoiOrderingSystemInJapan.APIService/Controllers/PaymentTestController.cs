using KoiOrderingSystemInJapan.Data.Abstractions.Setting;
using KoiOrderingSystemInJapan.Data.Contract.Interfaces;
using KoiOrderingSystemInJapan.Data.Dtos.PaymentDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;

namespace KoiOrderingSystemInJapan.APIService.Controllers;

[ApiController]
[Route("/paymentest")]
public class PaymentTestController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly PayOSSetting _payOSSetting;

    public PaymentTestController(IPaymentService paymentService, IOptions<PayOSSetting> payOSConfig)
    {
        _paymentService = paymentService;
        _payOSSetting = payOSConfig.Value;
    }

    [HttpGet]
    public async Task<ActionResult> PaymentTest()
    {
        List<ItemDTO> itemDtos = new List<ItemDTO> { new ItemDTO("Mi li", 1, 2000) };
        long orderId = new Random().Next(1,100000);
        var createPaymentDto = new CreatePaymentDTO(orderId, "Donate", itemDtos, _payOSSetting.ErrorUrl, _payOSSetting.ErrorUrl + _payOSSetting.SuccessUrl);
        var result = await _paymentService.CreatePaymentLink(createPaymentDto);
        return Ok(result);
    }
}
