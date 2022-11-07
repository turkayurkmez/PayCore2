using Orders.API.Commands;

namespace Orders.API.Handlers
{
    public class OrdersCommandHandler :
                                        ICommandHandler<ChangeInvoiceAddress>
    {

        public void Handle(ChangeInvoiceAddress command)
        {
            throw new NotImplementedException();
        }
    }


}
