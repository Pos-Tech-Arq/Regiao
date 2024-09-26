using MassTransit;
using Regiao.Domain.Command;
using Regiao.Domain.Contracts;
using Regiao.Worker.Message;

namespace Regiao.Worker.Consumer
{
    public class CriarRegiaoConsumer : IConsumer<CriarRegiaoMessage>
    {
        private readonly ICriaRegiaoService _criaRegiaoService;
        
        public CriarRegiaoConsumer(ICriaRegiaoService criaRegiaoService) {
            _criaRegiaoService = criaRegiaoService;
        }

        public async Task Consume(ConsumeContext<CriarRegiaoMessage> context)
        {
            var message = context.Message;

            string ddd = message.DDD;
            string numero = message.Numero;

            _criaRegiaoService.Handle(new CriaRegiaoCommand(ddd, numero));
        }
    }
}
