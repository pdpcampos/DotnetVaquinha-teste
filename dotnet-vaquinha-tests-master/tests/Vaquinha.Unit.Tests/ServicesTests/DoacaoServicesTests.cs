using AutoMapper;
using Moq;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Text;
using Vaquinha.Domain;
using Vaquinha.Domain.Entities;
using Vaquinha.Domain.ViewModels;
using Vaquinha.Service;
using Vaquinha.Tests.Common.Fixtures;
using Xunit;

namespace Vaquinha.Unit.Tests.ServicesTests
{
    [Collection(nameof(DoacaoFixtureCollection))]
    public class DoacaoServicesTests : IClassFixture<DoacaoFixture>,
                              IClassFixture<EnderecoFixture>,
                              IClassFixture<CartaoCreditoFixture>
    {

        private readonly Mock<IDoacaoRepository> _doacaoRepository = new Mock<IDoacaoRepository>();

        private IDomainNotificationService _domainNotificationService = new DomainNotificationService();

        private readonly DoacaoFixture _doacaoFixture;
        private readonly EnderecoFixture _enderecoFixture;
        private readonly CartaoCreditoFixture _cartaoCreditoFixture;

        private DoacaoService _doacaoServices;
        private readonly IDoacaoService _doacaoIService;

        private Mock<IMapper> _mapper;

        private Mock<IToastNotification> _toastNotification = new Mock<IToastNotification>();

        private readonly DoacaoViewModel _doacaoModelValida;

        public DoacaoServicesTests(DoacaoFixture doacaoFixture, EnderecoFixture enderecoFixture, CartaoCreditoFixture cartaoCreditoFixture)
        {
            _doacaoFixture = doacaoFixture;
            _enderecoFixture = enderecoFixture;
            _cartaoCreditoFixture = cartaoCreditoFixture;

            _mapper = new Mock<IMapper>();

            _doacaoModelValida = doacaoFixture.DoacaoModelValida();
            _doacaoModelValida.EnderecoCobranca = enderecoFixture.EnderecoModelValido();
            _doacaoModelValida.FormaPagamento = cartaoCreditoFixture.CartaoCreditoModelValido();

            _doacaoIService = new DoacaoService(_mapper.Object, _doacaoRepository.Object, _domainNotificationService);
        }

        #region Testes método "RealizarDoacaoAsync"

        [Fact]
        [Trait("DoacaoService", "Doacao_RealizarDoacao_DoacaoValida")]
        public void Doacao_RealizarDoacao_DoacaoValida()
        {
            // Arrange
            _doacaoServices = new DoacaoService(_mapper.Object, _doacaoRepository.Object, _domainNotificationService);

            // Act
            var retorno = _doacaoServices.RealizarDoacaoAsync(_doacaoModelValida);

            Assert.True(retorno.IsCompleted);
        }

        [Fact]
        [Trait("DoacaoService", "Doacao_RealizarDoacao_DoacaoInvalida")]
        public void Doacao_RealizarDoacao_DoacaoInvalida()
        {
            // Arrange
            var doacao = _doacaoFixture.DoacaoInvalida();
            var doacaoModelInvalida = new DoacaoViewModel();
            _mapper.Setup(a => a.Map<DoacaoViewModel, Doacao>(doacaoModelInvalida)).Returns(doacao);

            _doacaoServices = new DoacaoService(_mapper.Object, _doacaoRepository.Object, _domainNotificationService);

            // Act
            var retorno = _doacaoServices.RealizarDoacaoAsync(doacaoModelInvalida);

            Assert.False(retorno == null);
        }

        #endregion

        #region Testes método "RecuperarDoadoresAsync"

        [Fact]
        [Trait("DoacaoService", "Doacao_RecuperarDoadores_DoadorValido")]
        public void Doacao_RecuperarDoadores_DoadorValido()
        {
            // Arrange
            _doacaoServices = new DoacaoService(_mapper.Object, _doacaoRepository.Object, _domainNotificationService);

            // Act
            var retorno = _doacaoServices.RecuperarDoadoresAsync(0);

            Assert.True(retorno.IsCompletedSuccessfully);
        }

        [Fact]
        [Trait("DoacaoService", "Doacao_RecuperarDoadores_DoadorInvalido")]
        public void Doacao_RecuperarDoadores_DoadorInvalido()
        {
            // Arrange
            _doacaoServices = new DoacaoService(_mapper.Object, _doacaoRepository.Object, _domainNotificationService);

            // Act
            var retorno = _doacaoServices.RecuperarDoadoresAsync(-1);

            Assert.False(retorno == null);
        }
        
        #endregion
    }
}
