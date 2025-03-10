using AutoMapper;
using EcommerceApi.Server.Interfaces.PaymentInterfaces;
using EcommerceApi.Server.Models;

namespace EcommerceApi.Server.Services  
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Payment>> GetAllPayments()
        {
            return await _paymentRepository.GetAllAsync(); // Match interface return type
        }

        public async Task<Payment> GetPaymentById(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment == null)
            {
                throw new KeyNotFoundException($"Payment with ID {id} not found.");
            }
            return payment; // Match interface return type
        }

        public async Task<Payment> ProcessPayment(Payment payment)
        {
            if (payment.Amount <= 0)
            {
                throw new ArgumentException("Payment amount must be greater than zero.");
            }

            payment.PaymentDate = DateTime.UtcNow;
            payment.PaymentStatus = Constants.PaymentStatuses.paid;

            return await _paymentRepository.AddAsync(payment); // Match interface return type
        }

        public async Task<Payment> UpdatePayment(Payment payment)
        {
            var existingPayment = await _paymentRepository.GetByIdAsync(payment.Id);
            if (existingPayment == null)
            {
                throw new KeyNotFoundException($"Payment with ID {payment.Id} not found.");
            }

            existingPayment.Amount = payment.Amount;
            existingPayment.PaymentStatus = payment.PaymentStatus;
            existingPayment.PaymentDate = payment.PaymentDate;

            return await _paymentRepository.UpdateAsync(existingPayment); // Match interface return type
        }

        public async Task<bool> DeletePayment(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment == null)
            {
                throw new KeyNotFoundException($"Payment with ID {id} not found.");
            }

            return await _paymentRepository.DeleteAsync(id);
        }
    }
}
