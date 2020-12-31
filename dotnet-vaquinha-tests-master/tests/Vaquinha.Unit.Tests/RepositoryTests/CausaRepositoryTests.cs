using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Vaquinha.Domain;
using Vaquinha.Repository;
using Vaquinha.Repository.Context;
using Vaquinha.Tests.Common.Fixtures;
using Xunit;

namespace Vaquinha.Unit.Tests.RepositoryTests
{
    public class CausaRepositoryTests : IClassFixture<CausaFixture>
    {
        private readonly Mock<ICausaRepository> _iCausaRepository = new Mock<ICausaRepository>();
        
        private readonly CausaFixture _causaFixture;

        private CausaRepository _causaRepository;
        private readonly ICausaRepository _causaIRepository;

        private Mock<IMapper> _mapper;

        private readonly VaquinhaOnlineDBContext _dbContext;

        public CausaRepositoryTests(CausaFixture causaFixture)
        {
            _causaFixture = causaFixture;

            _mapper = new Mock<IMapper>();
            
            _causaIRepository = new CausaRepository(_dbContext);
        }

        #region Testes método "Adicionar"

        [Fact]
        [Trait("CausaRepository", "Causa_Adicionar_CausaValida")]
        public void Causa_Adicionar_CausaValida()
        {
            // Arrange
            _causaRepository = new CausaRepository(_dbContext);

            // Act
            var retorno = _causaRepository.Adicionar(_causaFixture.CausaValida());
            
            Assert.True(retorno.IsCompleted);
        }

        [Fact]
        [Trait("CausaRepository", "Causa_Adicionar_CausaInvalida")]
        public void Causa_Adicionar_CausaInvalida()
        {
            // Arrange
            _causaRepository = new CausaRepository(_dbContext);

            // Act
            var retorno = _causaRepository.Adicionar(null);

            Assert.False(retorno == null);
        }

        #endregion

        #region Testes método "RecuperarCausas"

        [Fact]
        [Trait("CausaRepository", "Causa_RecuperarCausas_CausaValida")]
        public void Causa_RecuperarCausas_CausaValida()
        {
            // Arrange
            _causaRepository = new CausaRepository(_dbContext);

            // Act
            var retorno = _causaRepository.RecuperarCausas();

            Assert.True(retorno.IsCompleted);
        }
        
        #endregion


    }
}
