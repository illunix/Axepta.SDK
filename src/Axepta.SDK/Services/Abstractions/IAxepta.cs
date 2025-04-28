namespace Axepta.SDK;

/// <summary>
/// Defines the operations for handling Axepta payments, including creating payments and processing refunds.
/// This interface outlines the contract for implementing Axepta payment services.
/// </summary>
public interface IAxepta
{
    /// <summary>
    /// Creates a payment asynchronously.
    /// </summary>
    /// <param name="payment">The payment details required to process the payment.</param>
    /// <param name="ct">An optional cancellation token to cancel the request.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="ResponseRoot"/> object with the payment response.</returns>
    Task<ResponseRoot> CreatePaymentAsync(
        Payment payment,
        CancellationToken ct = default
    );

    /// <summary>
    /// Creates a refund asynchronously.
    /// </summary>
    /// <param name="paymentId">The unique identifier of the payment to be refunded.</param>
    /// <param name="refund">The refund details required to process the refund.</param>
    /// <param name="ct">An optional cancellation token to cancel the request.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="ResponseRoot"/> object with the refund response.</returns>
    Task<ResponseRoot> CreateRefundAsync(
        Guid paymentId,
        Refund refund,
        CancellationToken ct = default
    );

    /// <summary>
    /// Retrieves the details of a specific transaction asynchronously.
    /// </summary>
    /// <param name="transactionId">The unique identifier of the transaction to retrieve.</param>
    /// <param name="ct">An optional cancellation token to cancel the request.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the <see cref="Transaction"/> object with the details of the requested transaction.
    /// </returns>
    Task<Transaction> GetTransactionAsync(
        Guid transactionId,
        CancellationToken ct = default
    );

    /// <summary>
    /// Retrieves the details of a specific payment asynchronously.
    /// </summary>
    /// <param name="paymentId">The unique identifier of the payment to retrieve.</param>
    /// <param name="ct">An optional cancellation token to cancel the request.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the <see cref="PaymentResponse"/> object with the details of the requested payment.
    /// </returns>
    Task<PaymentResponse> GetPaymentAsync(
        Guid paymentId,
        CancellationToken ct = default
    );
}
