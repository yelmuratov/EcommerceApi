using EcommerceApi.Server.Models;

namespace EcommerceApi.Server.Interfaces.PaymentInterfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAllPayments();
        Task<Payment> GetPaymentById(int id);
        Task<Payment> ProcessPayment(Payment payment);
        Task<Payment> UpdatePayment(Payment payment);
        Task<bool> DeletePayment(int id);
    }
}
