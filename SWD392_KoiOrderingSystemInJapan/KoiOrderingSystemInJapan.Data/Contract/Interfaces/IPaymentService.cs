using KoiOrderingSystemInJapan.Data.Dtos.PaymentDTOs;

namespace KoiOrderingSystemInJapan.Data.Contract.Interfaces;

public interface IPaymentService
{
    Task<CreatePaymentResponseDTO> CreatePaymentLink(CreatePaymentDTO paymentData);

}
